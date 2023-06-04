using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aldebaran.Api.Controllers;

[ApiController, 
 Route("[controller]")]
public sealed class AccountsController : ControllerBase
{

    [HttpPost("authenticate"), 
     AllowAnonymous]
    public ActionResult Authenticate([FromBody] UserLoginCommand userLogin)
    {
        return default;
    }
}