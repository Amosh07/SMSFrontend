using SMS.Models.Base;
using SMS.Models.Requests.Identity;
using SMS.Models.Responses.Identity;
using SMS.Service.Dependency;

namespace SMS.Service.Interface
{
    public interface IProfileService : ITransientService
    {
        Task<ResponseDto<UserDetail?>?> GetUserProfile();

        Task<ResponseDto<RolesDto?>?> GetUserRole();
    }
}
