using SELStudentApp.Models;

namespace SELStudentApp.Core.Services;
public interface IScheduleService
{
    Task<ScheduleData?> GetSchedule(DateTime dateTime);
}
