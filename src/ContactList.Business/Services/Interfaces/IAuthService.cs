using ContactList.Business.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ContactList.Business.Services.Interfaces;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(RegisterDto dto);
    Task<AuthResponseDto?> LoginAsync(LoginDto dto);   
}