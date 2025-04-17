using SMS.Models.Base;
using SMS.Models.Requests.Subject;
using SMS.Models.Responses.Subject;
using SMS.Service.Dependency;

namespace SMS.Service.Interface
{
    public interface ISubjectService : ITransientService
    {
        Task<ResponseDto<bool?>?> AddSubject(InsertSubjectDto insertSubject);

        Task<ResponseDto<List<GetSubjectDetailDto>?>?> GetAllSubjectDetails();
    }
}
