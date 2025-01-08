
namespace SELStudentApp.Core.Models;

public record LoginRequest(string Email, string Password);

public record LoginResponse(string Token, SELStudent Student);
