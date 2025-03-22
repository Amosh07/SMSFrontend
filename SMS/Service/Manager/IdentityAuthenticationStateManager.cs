using Microsoft.AspNetCore.Components.Authorization;
using SMS.Models.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SMS.Service.Manager
{
    public class IdentityAuthenticationStateManager(ILocalStorageManager localStorageManager, JwtSecurityTokenHandler jwtSecurityTokenHandler) : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());

            var token = await localStorageManager.GetItemAsync<string>(Constants.LocalStorage.Token);

            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(user);
            }

            var accessToken = StringCipher.Decrypt(token, Constants.Encryption.Key);

            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(accessToken);

            if (tokenContent.ValidTo < DateTime.UtcNow)
            {
                await localStorageManager.ClearItemAsync(Constants.LocalStorage.Token);

                return new AuthenticationState(user);
            }

            var claims = await GetClaims();

            user = new ClaimsPrincipal(new ClaimsIdentity(claims, Constants.LocalStorage.Jwt));

            return new AuthenticationState(user);
        }

        public async Task LoggedIn()
        {
            var claims = await GetClaims();

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, Constants.LocalStorage.Jwt));

            var authState = Task.FromResult(new AuthenticationState(user));

            NotifyAuthenticationStateChanged(authState);
        }

        public async Task LoggedOut()
        {
            await localStorageManager.ClearItemAsync(Constants.LocalStorage.Token);

            var nobody = new ClaimsPrincipal(new ClaimsIdentity());

            var authState = Task.FromResult(new AuthenticationState(nobody));

            NotifyAuthenticationStateChanged(authState);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var token = await localStorageManager.GetItemAsync<string>(Constants.LocalStorage.Token);

            if (string.IsNullOrEmpty(token)) return [];

            var accessToken = StringCipher.Decrypt(token, Constants.Encryption.Key);

            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(accessToken);

            return tokenContent.Claims.ToList();
        }

    }
}
