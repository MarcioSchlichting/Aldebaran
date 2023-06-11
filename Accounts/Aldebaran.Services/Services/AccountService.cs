﻿using System.Reflection.Metadata.Ecma335;
using Aldebaran.Accounts.Commands;
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
        {
            return NotFound<UserLoginResponse>(nameof(emailAddress));
        }

        var userInfo = await _userRepository.GetUserInfoAsync(emailAddress);

        var jwtResponse = _jwtGeneratorService.GenerateToken(userInfo);
        
        return new ServiceResponse<UserLoginResponse>(new UserLoginResponse()
        {
            Token = jwtResponse.Token
        });
    }
}