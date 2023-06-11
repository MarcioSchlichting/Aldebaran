using System.Reflection.Metadata.Ecma335;
using Aldebaran.Accounts.Commands;
using Aldebaran.Accounts.Models;
using Aldebaran.Accounts.Models.ValueObjects;
using Aldebaran.Domain.ApiResponses;
using Aldebaran.Domain.Repositories.Abstractions;
using static Aldebaran.Domain.ApiResponses.ServiceResponseExtensions;

namespace Aldebaran.Services.Services;

public sealed class AccountService : IAccountService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtGeneratorService _jwtGeneratorService;

    public AccountService(
        IUserRepository userRepository,
        IJwtGeneratorService jwtGeneratorService)
    {
        _userRepository = userRepository;
        _jwtGeneratorService = jwtGeneratorService;
    }
    
    public async Task<ServiceResponse<UserLoginResponse>> LoginAsync(UserLoginCommand command)
    {
        var emailAddress = command.SanitizeEmailAddress();

        var existsEmail = await _userRepository.ExistsEmailAsync(emailAddress);

        if (!existsEmail)
            return NotFound<UserLoginResponse>(nameof(emailAddress));

        var userInfo = await _userRepository.GetUserInfoAsync(emailAddress);

        var jwtResponse = _jwtGeneratorService.GenerateToken(userInfo);
        
        return new ServiceResponse<UserLoginResponse>(new UserLoginResponse()
        {
            Token = jwtResponse.Token
        });
    }

    public async Task<ServiceResponse<UserRegisterResponse>> RegisterAsync(UserRegisterCommand command)
    {
        var user = new User(
            Password: command.Password,
            Name: command.Name,
            EmailAddress: command.EmailAddress,
            IsAuthenticated: false,
            Role: command.Role);
        
        var result = user.Validate();
        
        if (!result.IsValid)
            return BadRequest<UserRegisterResponse>(string.Join('.', result.Errors));

        var passwordEncrypted = Password.EncryptPassword(user.Password);
        
        user = user with { Password = passwordEncrypted };
        
        var alreadyExists = await _userRepository.AlreadyExistsAsync(user);

        if (alreadyExists)
            return BadRequest<UserRegisterResponse>("The email address or password or username already exists.");

        var guid = await _userRepository.AddAsync(user);

        await _userRepository.SaveChangesAsync();
        
        return new ServiceResponse<UserRegisterResponse>(new UserRegisterResponse()
        {
            Id = guid
        });
    }

    public async Task<ServiceResponse<GetUserResponse>> GetUserByIdAsync(Guid id)
    {
        if (id == default)
            return BadRequest<GetUserResponse>("The id is invalid.");
        
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return NotFound<GetUserResponse>(nameof(id));

        return new ServiceResponse<GetUserResponse>(new GetUserResponse()
        {
            Name = user.Name,
            Role = user.Role,
            EmailAddress = user.EmailAddress,
            LastLogin = user.LastLogin
        });
    }
}