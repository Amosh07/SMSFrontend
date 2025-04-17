using SMS.Models.Base;
using SMS.Models.Requests.Result;
using SMS.Models.Responses.Result;
using SMS.Service.Dependency;

namespace SMS.Service.Interface
{
    public interface IResultService : ITransientService
    {
        Task<ResponseDto<bool?>?> AddResult(InsertResultDto insertResult);

        Task<ResponseDto<List<GetResultDetailDto>?>?> GetAllResultDetails();
    }
}
