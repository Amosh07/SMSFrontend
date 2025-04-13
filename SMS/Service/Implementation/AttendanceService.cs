using SMS.Models.Base;
using SMS.Models.Constants;
using SMS.Models.Requests.Attendance;
using SMS.Models.Responses.Attendance;
using SMS.Service.Base;
using SMS.Service.Interface;
using System.Text.Json;

namespace SMS.Service.Implementation
{
    public class AttendanceService(IBaseService baseService) : IAttendanceService
    {
        public async Task<ResponseDto<bool?>?> AddAttendance(InsertAttendanceDto insertAttendance)
        {
            var jsonRequest = JsonSerializer.Serialize(insertAttendance);

            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

            var response = await baseService.PostAsync<bool?>(ApiEndpoints.Attendance.AddAttendance, content);

            return response;
        }

        public async Task<ResponseDto<List<GetAttendanceDetailsDto>?>?> GetAllAttendanceDetails()
        {
            var response = await baseService.GetAsync<List<GetAttendanceDetailsDto>?>(ApiEndpoints.Attendance.GetAllAttendanceDetails);

            return response;
        }
    }
}
