using ContactList.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Web.Controllers;

[Route("[controller]")]
public class AuthController(IAuthService authService) : Controller
{
    [HttpGet("login")]
    public IActionResult Login() => PartialView("Login");

    [HttpGet("register")]
    public IActionResult Register() => PartialView("Register");

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var (success, message) = await authService.LoginAsync(dto.Email, dto.Password);
        if (!success)
            return BadRequest(new { Message = message });
        return Ok(new { Message = message });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var (success, message) = await authService.RegisterAsync(dto.Email, dto.Password);
        if (!success)
            return BadRequest(new { Message = message });
        return Ok(new { Message = message });
    }
    
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await authService.LogoutAsync();
        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet("is-logged-in")]
    public IActionResult IsLoggedIn()
    {
        return Ok(new { isLoggedIn = User.Identity?.IsAuthenticated ?? false });
    }
}

public record LoginDto(string Email, string Password);
public record RegisterDto(string Email, string Password);