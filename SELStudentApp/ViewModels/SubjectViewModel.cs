using SELStudentApp.Core.Models.Curriculum;

namespace SELStudentApp.ViewModels;

public record SubjectViewModel(CurriculumSubject Model)
{
    public bool HasHours => Model.Hours > 0;

    public bool HasCredits => Model.Credits > 0;

    public bool HasHoursOrCredits => HasHours || HasCredits;

    public bool HasHoursAndCredits => HasHours && HasCredits;

    public string SubjectType => Model.Type switch
    {
        "exam" => "Екзамен",
        _ => "Залік"
    };
}
