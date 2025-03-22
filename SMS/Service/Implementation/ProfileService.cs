using SMS.Models.Base;
using SMS.Models.Constants;
using SMS.Models.Responses.Identity;
using SMS.Service.Base;
using SMS.Service.Interface;

namespace SMS.Service.Implementation
{
    public class ProfileService(IBaseService baseService) : IProfileService
    {
        public async Task<ResponseDto<UserDetail?>?> GetUserProfile()
        {
            var response = await baseService.GetAsync<UserDetail?>(ApiEndpoints.Profile.GetUserProfile);

            return response;
        }
    }
}
