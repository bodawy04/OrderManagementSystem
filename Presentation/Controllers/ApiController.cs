global using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]

public abstract class ApiController : ControllerBase
{
    protected string GetEmailFromToken() => User.FindFirst("Email")?.Value!;
}
