using Microsoft.AspNetCore.Components.Authorization;
using SMS.Models.Base;
using SMS.Models.Constants;
using SMS.Models.Requests.Identity;
using SMS.Models.Responses.Identity;
using SMS.Service.Base;
using SMS.Service.Interface;
using SMS.Service.Manager;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text.Json;

namespace SMS.Service.Implementation
{
    public class AuthenticationService(IBaseService baseService, ILocalStorageManager localStorageManager, AuthenticationStateProvider authenticationStateProvider) : IAuthenticationService
    {
        public async Task<string?> GetReturnUrl()
        {
            var returnUrl = await localStorageManager.GetItemAsync<string>(Constants.LocalStorage.Navigation);

            if (returnUrl != null) await localStorageManager.ClearItemAsync(Constants.LocalStorage.Navigation);

            return returnUrl;
        }

        public async Task<bool> IsUserLoggedIn()
        {
            var token = await localStorageManager.GetItemAsync<string>(Constants.LocalStorage.Token);

            if (token == null) return false;

            var accessToken = StringCipher.Decrypt(token, Constants.Encryption.Key);

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtToken = tokenHandler.ReadJwtToken(accessToken);

            var expiryDateTime = jwtToken.ValidTo;

            return expiryDateTime > DateTime.UtcNow;
        }

        public async Task<ResponseDto<UserLoginResponseDto?>?> Login(LoginDto loginDto)
        {
            var jsonRequest = JsonSerializer.Serialize(loginDto);

            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

            var response = await baseService.PostAsync<UserLoginResponseDto?>(ApiEndpoints.Authentication.Login, content);

            if (string.IsNullOrEmpty(response?.Result?.Token))
            {
                await((IdentityAuthenticationStateManager)authenticationStateProvider).LoggedIn();
            }

            return response;
        }

        public async Task<ResponseDto<RegistrationResponseDto?>?> UserRegister(UserRegisterDto userRegisterDto)
        {
            var formData = new MultipartFormDataContent();

            formData.Add(new StringContent(userRegisterDto.Name ?? ""), "Name");
            formData.Add(new StringContent(userRegisterDto.Email ?? ""), "Email");
            formData.Add(new StringContent(userRegisterDto.Password ?? ""), "Password");
            formData.Add(new StringContent(userRegisterDto.PhoneNumber ?? ""), "PhoneNumber");
            formData.Add(new StringContent(userRegisterDto.RoleId.ToString()), "RoleId");
            formData.Add(new StringContent(userRegisterDto.ConfirmPassword ?? ""), "ConfirmPassword");
            formData.Add(new StringContent(userRegisterDto.Gender.ToString() ?? ""), "Gender");
            formData.Add(new StringContent(userRegisterDto.Address ?? ""), "Address");

            if (userRegisterDto.ImageUrl != null)
            {
                var userImage = new StreamContent(userRegisterDto.ImageUrl!.OpenReadStream(long.MaxValue));

                userImage.Headers.ContentType = new MediaTypeHeaderValue(userRegisterDto.ImageUrl.ContentType);

                formData.Add(userImage, "ImageUrl", userRegisterDto.ImageUrl.Name);
            }

            var response = await baseService.UploadAsync<RegistrationResponseDto?>(ApiEndpoints.Authentication.UserRegister, Constants.UploadType.Post, formData);

            return response;
        }

        public async Task LogOut()
        {
            var content = new StringContent("", System.Text.Encoding.UTF8, "application/json");

            await baseService.PostAsync<bool>(ApiEndpoints.Authentication.Logout, content);

            await((IdentityAuthenticationStateManager)authenticationStateProvider).LoggedOut();
        }

        public async Task SetUpAccessToken(string accessToken)
        {
            await localStorageManager.ClearItemAsync(Constants.LocalStorage.Token);

            await localStorageManager.SetItemAsync(Constants.LocalStorage.Token, accessToken);
        }

        public async Task SetUpReturnUrl(string returnUrl)
        {
            await localStorageManager.SetItemAsync(Constants.LocalStorage.Navigation, returnUrl);
        }
    }
}
