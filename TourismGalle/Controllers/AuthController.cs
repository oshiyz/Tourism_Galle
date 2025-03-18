using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TourismGalle.Models;

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
        Console.WriteLine("Register request received for email: " + user.Email); // Add this line
        bool isRegistered = await _authService.Register(user);
        if (!isRegistered)
            return BadRequest("Email already exists");

        return Ok("User registered successfully");
    }

    // ✅ Login API
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var authenticatedUser = await _authService.Login(request.Email, request.Password);
        if (authenticatedUser == null)
            return Unauthorized("Invalid email or password");

        return Ok(authenticatedUser);
    }
}

// Login Request DTO
public class LoginRequest
{
    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}