using Blazored.LocalStorage;
using SMS.Models.Base;
using SMS.Models.Constants;
using SMS.Service.HTTP;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SMS.Service.Base
{
    public class BaseService(ApiHttpClient apiHttpClient, ILocalStorageService localStorageService) : IBaseService
    {
        private readonly HttpClient _httpClient = apiHttpClient.HttpClient;
        public async Task<ResponseDto<T?>?> GetAsync<T>(string endpoint,
         IList<string>? path = null,
         IDictionary<string, string?>? parameters = null,
         IDictionary<string, string>? headersValue = null)
        {
            try
            {
                if (path is { Count: > 0 })
                {
                    endpoint = path.Aggregate(endpoint, (current, parameter) => current + ("/" + parameter));
                }

                if (parameters is { Count: > 0 })
                {
                    var queryString = string.Join("&",
                        parameters.Where(kvp => kvp.Value != null)
                            .Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value ?? string.Empty)}"));

                    endpoint += "?" + queryString;
                }

                _httpClient.DefaultRequestHeaders.Clear();

                SetNgrokAccessibility();

                if (headersValue is { Count: > 0 })
                {
                    foreach (var header in headersValue)
                    {
                        _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                await SetAuthorizationHeader();

                var response = await _httpClient.GetAsync($"/api/{endpoint}");

                return await response.Content.ReadFromJsonAsync<ResponseDto<T?>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured while handing your request: {ex.Message}");
            }

            return default;
        }

        public async Task<CollectionDto<T>?> GetPagedAsync<T>(string endpoint,
            IList<string>? path = null,
            IDictionary<string, string?>? parameters = null,
            IDictionary<string, string>? headersValue = null)
        {
            try
            {
                if (path is { Count: > 0 })
                {
                    endpoint = path.Aggregate(endpoint, (current, parameter) => current + ("/" + parameter));
                }

                if (parameters is { Count: > 0 })
                {
                    var queryString = string.Join("&",
                        parameters.Where(kvp => kvp.Value != null)
                            .Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value ?? string.Empty)}"));

                    endpoint += "?" + queryString;
                }

                _httpClient.DefaultRequestHeaders.Clear();

                SetNgrokAccessibility();

                if (headersValue is { Count: > 0 })
                {
                    foreach (var header in headersValue)
                    {
                        _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                await SetAuthorizationHeader();

                var response = await _httpClient.GetAsync($"/api/{endpoint}");

                return await response.Content.ReadFromJsonAsync<CollectionDto<T>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured while handing your request: {ex.Message}");
            }

            return default;
        }

        public async Task<ResponseDto<T?>?> PostAsync<T>(string endpoint, StringContent stringContent, IList<string>? path = null)
        {
            try
            {
                if (path is { Count: > 0 })
                {
                    endpoint = path.Aggregate(endpoint, (current, parameter) => current + ("/" + parameter));
                }

                await SetAuthorizationHeader();

                SetNgrokAccessibility();

                var response = await _httpClient.PostAsync($"/api/{endpoint}", stringContent);

                return await response.Content.ReadFromJsonAsync<ResponseDto<T?>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured while handing your request: {ex.Message}");
            }

            return default;
        }

        public async Task<ResponseDto<T?>?> UploadAsync<T>(string endpoint, string uploadType, MultipartFormDataContent formDataContent, IList<string>? path = null)
        {
            try
            {
                if (path is { Count: > 0 })
                {
                    endpoint = path.Aggregate(endpoint, (current, parameter) => current + ("/" + parameter));
                }

                await SetAuthorizationHeader();

                SetNgrokAccessibility();

                var response = uploadType == Constants.UploadType.Post
                    ? await _httpClient.PostAsync($"/api/{endpoint}", formDataContent)
                    : uploadType == Constants.UploadType.Put
                        ? await _httpClient.PutAsync($"/api/{endpoint}", formDataContent)
                        : await _httpClient.PatchAsync($"/api/{endpoint}", formDataContent);

                return await response.Content.ReadFromJsonAsync<ResponseDto<T?>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured while handing your request: {ex.Message}");
            }

            return default;
        }

        public async Task<ResponseDto<T?>?> UpdateAsync<T>(string endpoint, string updateType, StringContent stringContent, IList<string>? path = null)
        {
            try
            {
                if (path is { Count: > 0 })
                {
                    endpoint = path.Aggregate(endpoint, (current, parameter) => current + ("/" + parameter));
                }

                await SetAuthorizationHeader();

                SetNgrokAccessibility();

                var response = updateType == Constants.UpdateType.Patch
                    ? await _httpClient.PatchAsync($"/api/{endpoint}", stringContent)
                    : await _httpClient.PutAsync($"/api/{endpoint}", stringContent);

                return await response.Content.ReadFromJsonAsync<ResponseDto<T?>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured while handing your request: {ex.Message}");
            }

            return default;
        }

        public async Task<ResponseDto<T?>?> DeleteAsync<T>(string endpoint, string deleteType, IList<string>? path = null)
        {
            try
            {
                await SetAuthorizationHeader();

                if (path is { Count: > 0 })
                {
                    endpoint = path.Aggregate(endpoint, (current, parameter) => current + ("/" + parameter));
                }

                SetNgrokAccessibility();

                var response = deleteType == Constants.DeleteType.Delete
                    ? await _httpClient.DeleteAsync($"api/{endpoint}")
                    : await _httpClient.PatchAsync($"api/{endpoint}", null);

                return await response.Content.ReadFromJsonAsync<ResponseDto<T?>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured while handing your request: {ex.Message}");
            }

            return default;
        }

        public async Task<(byte[]? content, HttpResponseMessage? response)> DownloadAsync(string endpoint, IList<string>? path = null, IDictionary<string, string>? parameters = null, IDictionary<string, string>? headersValue = null)
        {
            try
            {
                if (path is { Count: > 0 })
                {
                    endpoint = path.Aggregate(endpoint, (current, parameter) => current + ("/" + parameter));
                }

                if (parameters is { Count: > 0 })
                {
                    var queryString = string.Join("&", parameters.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));

                    endpoint += "?" + queryString;
                }

                _httpClient.DefaultRequestHeaders.Clear();

                SetNgrokAccessibility();

                if (headersValue is { Count: > 0 })
                {
                    foreach (var header in headersValue)
                    {
                        _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                await SetAuthorizationHeader();

                var response = await _httpClient.GetAsync($"/api/{endpoint}");

                if (!response.IsSuccessStatusCode) return (null, response);

                var content = await response.Content.ReadAsByteArrayAsync();

                return (content, response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured while handing your request: {ex.Message}");
            }

            return (null, null);
        }

        public async Task<(byte[]? content, HttpResponseMessage? response)> DownloadAsync(string endpoint,
            MultipartFormDataContent formDataContent,
            IList<string>? path = null,
            IDictionary<string, string>? parameters = null,
            IDictionary<string, string>? headersValue = null)
        {
            try
            {
                if (path is { Count: > 0 })
                {
                    endpoint = path.Aggregate(endpoint, (current, parameter) => current + ("/" + parameter));
                }

                if (parameters is { Count: > 0 })
                {
                    var queryString = string.Join("&", parameters.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));

                    endpoint += "?" + queryString;
                }

                _httpClient.DefaultRequestHeaders.Clear();

                SetNgrokAccessibility();

                if (headersValue is { Count: > 0 })
                {
                    foreach (var header in headersValue)
                    {
                        _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                await SetAuthorizationHeader();

                var response = await _httpClient.PostAsync($"/api/{endpoint}", formDataContent);

                if (!response.IsSuccessStatusCode) return (null, response);

                var content = await response.Content.ReadAsByteArrayAsync();

                return (content, response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured while handing your request: {ex.Message}");
            }

            return (null, null);
        }

        public async Task<(byte[]? content, HttpResponseMessage? response)> DownloadAsync(string endpoint,
            StringContent stringContent,
            IList<string>? path = null,
            IDictionary<string, string>? parameters = null,
            IDictionary<string, string>? headersValue = null)
        {
            try
            {
                if (path is { Count: > 0 })
                {
                    endpoint = path.Aggregate(endpoint, (current, parameter) => current + ("/" + parameter));
                }

                if (parameters is { Count: > 0 })
                {
                    var queryString = string.Join("&", parameters.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));

                    endpoint += "?" + queryString;
                }

                _httpClient.DefaultRequestHeaders.Clear();

                SetNgrokAccessibility();

                if (headersValue is { Count: > 0 })
                {
                    foreach (var header in headersValue)
                    {
                        _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                await SetAuthorizationHeader();

                var response = await _httpClient.PostAsync($"/api/{endpoint}", stringContent);

                if (!response.IsSuccessStatusCode) return (null, response);

                var content = await response.Content.ReadAsByteArrayAsync();

                return (content, response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured while handing your request: {ex.Message}");
            }

            return (null, null);
        }

        private async Task SetAuthorizationHeader()
        {
            var token = await localStorageService.GetItemAsync<string>(Constants.LocalStorage.Token);

            if (token != null)
            {
                var accessToken = StringCipher.Decrypt(token, Constants.Encryption.Key);

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
        }

        private void SetNgrokAccessibility()
        {
            _httpClient.DefaultRequestHeaders.Add("ngrok-skip-browser-warning", "true");
        }
    }
}
