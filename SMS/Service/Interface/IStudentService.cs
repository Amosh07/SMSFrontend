using SMS.Models.Base;
using SMS.Models.Responses.Identity;
using SMS.Service.Dependency;

namespace SMS.Service.Interface
{
    public interface IStudentService : ITransientService
    {
        Task<ResponseDto<StudentDetails?>?> GetAllStudentById(int periodAction);
    }
}
