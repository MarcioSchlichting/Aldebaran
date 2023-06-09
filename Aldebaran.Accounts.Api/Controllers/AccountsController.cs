using Aldebaran.Domain.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aldebaran.Accounts.Api.Controllers;

[ApiController, 
 Route("[controller]")]
public sealed class AccountsController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountsController(AccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpPost("authenticate"), 
     AllowAnonymous]
    public async Task<ActionResult<ServiceResponse<UserLoginResponse>>> LoginAsync([FromBody] UserLoginCommand userLogin)
    {
        var result = await _accountService.LoginAsync(userLogin);
        
        return default;
    }
}