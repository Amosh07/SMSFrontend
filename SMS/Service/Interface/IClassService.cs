using SMS.Models.Base;
using SMS.Models.Requests.Class;
using SMS.Models.Responses.Class;
using SMS.Service.Dependency;

namespace SMS.Service.Interface
{
    public interface IClassService : ITransientService
    {
        Task<ResponseDto<bool?>?> AddClass(InsertClassDto insertClass);

        Task<ResponseDto<List<GetClassDetailDto>?>?> GetAllClassDetails();
    }
}
