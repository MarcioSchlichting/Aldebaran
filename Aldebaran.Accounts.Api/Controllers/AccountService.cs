using Aldebaran.Accounts.Commands;
using Aldebaran.Accounts.Repositories;
using Aldebaran.Accounts.Services;
using Aldebaran.Domain.ApiResponses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Aldebaran.Domain.ApiResponses.ServiceResponseExtensions;

namespace Aldebaran.Accounts.Api.Controllers;

public sealed class AccountService : IAccountService
{
    private readonly IUserRepository _userRepository;

    public AccountService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<ServiceResponse<UserLoginResponse>> LoginAsync(UserLoginCommand command)
    {
        var emailAddress = command.SanitizeEmailAddress();
        
        var existsEmail = await _userRepository.ExistsEmailAsync(emailAddress);

        if (!existsEmail)
        {
            return NotFound<UserLoginResponse>(nameof(emailAddress));
        }
        
        
        
        return default;
    }
}