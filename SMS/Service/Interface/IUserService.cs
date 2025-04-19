using SMS.Models.Base;
using SMS.Models.Responses.Identity;

namespace SMS.Service.Interface
{
    public interface IUserService
    {
        Task<ResponseDto<UserDetail?>?> GetUserProfileById(int periodAction);
    }
}
