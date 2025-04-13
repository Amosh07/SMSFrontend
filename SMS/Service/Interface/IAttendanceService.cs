using SMS.Models.Base;
using SMS.Models.Requests.Attendance;
using SMS.Models.Responses.Attendance;
using SMS.Service.Dependency;

namespace SMS.Service.Interface
{
    public interface IAttendanceService : ITransientService
    {
        Task<ResponseDto<bool?>?> AddAttendance(InsertAttendanceDto insertAttendance);

        Task<ResponseDto<List<GetAttendanceDetailsDto>?>?> GetAllAttendanceDetails();
    }
}
