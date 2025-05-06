using Domain.Entities;
using Domain.Ports;
using Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) =>
        _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login(Auth auth)
    {
        var response = await _authService.AuthenticateAsync(auth);

        if (response.Success)
            return Ok(response);

        return Unauthorized(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(Auth auth)
    {
        var response = await _authService.AddNewAuthAsync(auth);

        if (response.Success)
            return Ok(response);

        return BadRequest(response);
    }
}
