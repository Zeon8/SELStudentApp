using SELStudentApp.Core.Models.Curriculum;

namespace SELStudentApp.Core.Services;
public interface ICurriculumService
{
    Task<Curriculum?> GetCurriculum();
}
