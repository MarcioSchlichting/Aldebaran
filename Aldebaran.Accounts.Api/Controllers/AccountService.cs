using Aldebaran.Accounts.Repositories;
using Aldebaran.Domain.ApiResponses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Aldebaran.Accounts.Api.Controllers;

public class AccountService
{
    private readonly IUserRepository _userRepository;

    public AccountService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<ActionResult<ServiceResponse<UserLoginResponse>>> LoginAsync(UserLoginCommand command)
    {
        var emailAddress = command.SanitizeEmailAddress();
        
        var existsEmail = await _userRepository.ExistsEmailAsync(emailAddress);

        if (!existsEmail)
        {
            
        }
        
        return user;
    }
}