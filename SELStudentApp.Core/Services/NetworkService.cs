using System.Net.Http.Json;
using System.Text.Json;

namespace SELStudentApp.Core.Services;

public class NetworkService : INetworkService
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
    };

    public NetworkService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T?> Get<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<T>(_options);
    }
}
