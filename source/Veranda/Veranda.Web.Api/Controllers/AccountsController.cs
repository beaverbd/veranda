using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Veranda.Web.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    public AccountsController()
    {
        
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register()
    {
        return Ok();
    }
}
