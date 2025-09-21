using ContactList.Business.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ContactList.Business.Services;

public class AuthService(
    UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager,
    ILogger<AuthService> logger)
    : IAuthService
{
    public async Task<(bool Success, string Message)> RegisterAsync(string email, string password)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return (false, "Email and password are required");

            var user = new IdentityUser { UserName = email, Email = email };
            var result = await userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                return (false, errors);
            }

            await signInManager.SignInAsync(user, isPersistent: false);
            return (true, "Registration successful");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error during registration");
            return (false, "Unexpected error during registration");
        }
    }

    public async Task<(bool Success, string Message)> LoginAsync(string email, string password)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return (false, "Email and password are required");

            var result = await signInManager.PasswordSignInAsync(email, password, false, false);

            if (!result.Succeeded)
                return (false, "Invalid email or password");

            return (true, "Login successful");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error during login");
            return (false, "Unexpected error during login");
        }
    }

    public async Task LogoutAsync()
    {
        await signInManager.SignOutAsync();
    }
}