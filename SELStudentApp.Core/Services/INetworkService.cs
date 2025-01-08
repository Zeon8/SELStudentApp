namespace SELStudentApp.Core.Services;

public interface INetworkService
{
    Task<T?> Get<T>(string url);
}
