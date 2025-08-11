using OrderManagementSystem.SharedDTO.DataTransferObjects.Identity;
using ServicesAbstractions;

namespace Presentation.Controllers;

public class UsersController(IServiceManager serviceManager) : ApiController
{
    [HttpPost("Login")]
    public async Task<ActionResult<UserDTO>> Login(LoginDTO login)
    {
        var user = await serviceManager.AuthenticationService.LoginAsync(login);
        return Ok(user);
    }
    [HttpPost("Register")]
    public async Task<ActionResult<UserDTO>> Register(RegisterDTO register)
    {
        var user = await serviceManager.AuthenticationService.RegisterAsync(register);
        return Ok(user);
    }
}
