namespace TourismGalle.Controllers;
using Microsoft.AspNetCore.Mvc;
using TourismGalle.Models;
using TourismGalle.Services;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    // ✅ Register API
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        bool isRegistered = await _authService.Register(user);
        if (!isRegistered)
            return BadRequest("Email already exists");

        return Ok("User registered successfully");
    }

    // ✅ Login API
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User user)
    {
        var authenticatedUser = await _authService.Login(user.Email, user.PasswordHash);
        if (authenticatedUser == null)
            return Unauthorized("Invalid email or password");

        return Ok(authenticatedUser);
    }
}

