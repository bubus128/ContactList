namespace ContactList.Business.Services.Interfaces;

public interface IAuthService
{
    public Task<(bool Success, string Message)> RegisterAsync(string email, string password);

    public Task<(bool Success, string Message)> LoginAsync(string email, string password);
    
    
}