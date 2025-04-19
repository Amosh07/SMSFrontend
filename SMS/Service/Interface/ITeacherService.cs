using SMS.Models.Base;
using SMS.Models.Responses.Identity;
using SMS.Service.Dependency;

namespace SMS.Service.Interface
{
    public interface ITeacherService : ITransientService
    {
        Task<ResponseDto<TeacherDetails?>?> GetAllTeacherById(int periodAction);

    }
}
