using SMS.Models.Base;
using SMS.Models.Requests.Identity;
using SMS.Models.Responses.Identity;
using SMS.Service.Dependency;

namespace SMS.Service.Interface
{
    public interface IAuthenticationService : ITransientService
    {
        Task<bool> IsUserLoggedIn();

        Task SetUpAccessToken(string accessToken);

        Task SetUpReturnUrl(string returnUrl);

        Task<string?> GetReturnUrl();

        Task<ResponseDto<UserLoginResponseDto?>?> Login(LoginDto loginDto);

        Task LogOut();
    }
}
