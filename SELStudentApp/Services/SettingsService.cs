using System.Collections.Immutable;
using System.Net.Http.Headers;
using System.Text.Json;
using SELStudentApp.Core.Models;
using Windows.Security.Credentials;

namespace SELStudentApp.Core.Services;

public class SettingsService : ISettingsService
{
    private readonly HttpClient _httpClient;

    public SettingsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public SELStudent? Student { get; set; }

    public string? UserToken { get; private set; }

    public void SetToken(string token)
    {
        UserToken = token;
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public bool Load()
    {
        using ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        if (localSettings.Values["Student"] is string studentJson)
        {
            Student = JsonSerializer.Deserialize<SELStudent>(studentJson);

#if HAS_UNO_SKIA
            // PasswordVault is not implemented on Skia.
            SetToken((string)localSettings.Values["Token"]);
#else
            var passwordVault = new PasswordVault();
            SetToken(passwordVault.Retrieve("SEL", "Token").Password);
#endif
            return true;
        }
        return false;
    }

    public void Save()
    {
        using ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        localSettings.Values["Student"] = JsonSerializer.Serialize(Student);

#if HAS_UNO_SKIA
        // PasswordVault is not implemented on Skia.
        localSettings.Values["Token"] = UserToken;
#else
        var passwordVault = new PasswordVault();
        passwordVault.Add(new PasswordCredential("SEL", "Token", UserToken));
#endif
    }

    public void Clear()
    {
        UserToken = null;
        Student = null;

        using ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        localSettings.Values.Remove("Student");

#if HAS_UNO_SKIA
        localSettings.Values.Remove("Token");
#else
        var passwordVault = new PasswordVault();
        passwordVault.Persist(ImmutableList<PasswordCredential>.Empty);
#endif
    }
}
