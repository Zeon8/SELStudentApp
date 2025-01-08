using SELStudentApp.Core.Models;
using SELStudentApp.Core.Services;

namespace SELStudentApp.ViewModels;

public partial class ProfileViewModel : ObservableObject
{
    public SELStudent Student { get; }

    public string Status => Student.Status switch
    {
        1 => "Активний",
        2 => "Неактивний",
        _ => "Невідомо"
    };

    public ProfileViewModel(ISettingsService settingsService)
    {
        Student = settingsService.Student
            ?? throw new InvalidOperationException("Student is null.");
    }
}
