using SELStudentApp.Core.Models;

namespace SELStudentApp.Core.Services;

public interface IDashboardService
{
    Task<DashboardData?> GetDashboardData();
}