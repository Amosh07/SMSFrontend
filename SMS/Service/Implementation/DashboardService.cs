using SMS.Models.Base;
using SMS.Models.Constants;
using SMS.Models.Responses.Dashboard;
using SMS.Service.Base;
using SMS.Service.Interface;

namespace SMS.Service.Implementation
{
    public class DashboardService(IBaseService baseService) : IDashboardService
    {
        public async Task<ResponseDto<GetAdminCountDto?>?> GetAdminDashboardCount(int periodAction)
        {
            var pathParameter = new List<string>
        {
            periodAction.ToString()
        };

            var response = await baseService.GetAsync<GetAdminCountDto>(ApiEndpoints.Dashboard.GetAdminDashboardCount, pathParameter);

            return response;
        }
    }
}
