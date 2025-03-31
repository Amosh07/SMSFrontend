using SMS.Models.Base;
using SMS.Models.Responses.Dashboard;
using SMS.Service.Dependency;

namespace SMS.Service.Interface
{
    public interface IDashboardService : ITransientService
    {
        Task<ResponseDto<GetAdminCountDto?>?> GetAdminDashboardCount(int periodAction);
    }
}
