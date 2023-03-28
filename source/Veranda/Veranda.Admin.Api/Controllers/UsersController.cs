using Grpc.Core;
using GrpcUsersService;
using Microsoft.AspNetCore.Mvc;

namespace Veranda.Admin.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly Users.UsersClient _usersClient;

    public UsersController(Users.UsersClient usersClient)
    {
        _usersClient = usersClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _usersClient.GetUsersAsync(new GetUsersRequest
        {
            Skip = 0,
            Take = 10
        }, new CallOptions()));
    }
}
