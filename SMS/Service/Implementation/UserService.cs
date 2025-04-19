using SMS.Models.Base;
using SMS.Models.Constants;
using SMS.Models.Responses.Identity;
using SMS.Service.Base;
using SMS.Service.Interface;

namespace SMS.Service.Implementation
{
    public class UserService(IBaseService baseService) : IUserService
    {
        public async Task<ResponseDto<UserDetail?>?> GetUserProfileById(int periodAction)
        {
            var pathParameter = new List<string>
        {
                periodAction.ToString()
            };

            var response = await baseService.GetAsync<UserDetail>(ApiEndpoints.User.GetUserProfileById, pathParameter);

            return response;
        }
    }
}
