using Aldebaran.Accounts.Commands;
using Aldebaran.Accounts.Responses;
using Aldebaran.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aldebaran.Accounts.Api.Controllers;

[ApiController, 
 Route("[controller]")]
public sealed class AccountsController : Controller
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpPost("authenticate"), 
     AllowAnonymous]
    public async Task<ActionResult<UserLoginResponse>> LoginAsync([FromBody] UserLoginCommand userLogin)
    {
        var result = await _accountService.LoginAsync(userLogin);
        
        return result.ToResponse();
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<UserRegisterResponse>> RegisterAsync([FromBody] UserRegisterCommand userRegister)
    {
        var result = await _accountService.RegisterAsync(userRegister);
        
        return result.ToResponse();
    }
    
    [HttpGet]
    public async Task<ActionResult<GetUserResponse>> GetUserByIdAsync([FromQuery] Guid id)
    {
        var result = await _accountService.GetUserByIdAsync(id);
        
        return result.ToResponse();
    }
}