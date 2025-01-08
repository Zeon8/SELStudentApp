using SELStudentApp.Core.Models;

namespace SELStudentApp.Core.Services;

public interface ISettingsService
{
    SELStudent? Student { get; set; }
    string? UserToken { get; }

    void SetToken(string token);
    bool Load();
    void Save();
    void Clear();
}
