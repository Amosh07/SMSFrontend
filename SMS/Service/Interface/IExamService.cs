using SMS.Models.Base;
using SMS.Models.Requests.Exam;
using SMS.Models.Responses.Exam;
using SMS.Service.Dependency;

namespace SMS.Service.Interface
{
    public interface IExamService : ITransientService
    {
        Task<ResponseDto<bool?>?>AddExam(InsertExamDto insertExam);

        Task<ResponseDto<List<GetExamDetailDto>?>?> GetAllExamDetails();
    }
}
