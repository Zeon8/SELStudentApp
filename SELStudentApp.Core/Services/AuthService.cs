using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using SELStudentApp.Core.Models;
namespace SELStudentApp.Core.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _client;
    private readonly ISettingsService _settingsService;

    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
    };

    public AuthService(HttpClient client, ISettingsService settingsService)
    {
        _client = client;
        _settingsService = settingsService;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        LoginResponse? response = await LoginAsync(new LoginRequest(email, password));
        if (response is not null)
        {
            _settingsService.SetToken(response.Token);
            _settingsService.Student = response.Student;
            _settingsService.Save();
        }
        return response is not null;
    }

    private async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        HttpResponseMessage response = await _client.PostAsJsonAsync("api/student/login", request, _options);
        if (response.StatusCode == HttpStatusCode.Unauthorized)
            return null;

        return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<LoginResponse>();
    }
}
