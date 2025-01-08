namespace SELStudentApp.Core.Services;

public interface IAuthService
{
    Task<bool> LoginAsync(string email, string password);
}
