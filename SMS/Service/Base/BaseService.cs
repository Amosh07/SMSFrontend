using SMS.Models.Base;

namespace SMS.Service.Base
{
    public class BaseService() : IBaseService
    {
        public Task<ResponseDto<T?>?> DeleteAsync<T>(string endpoint, string deleteType, IList<string>? path = null)
        {
            throw new NotImplementedException();
        }

        public Task<(byte[]? content, HttpResponseMessage? response)> DownloadAsync(string endpoint, IList<string>? path = null, IDictionary<string, string>? parameters = null, IDictionary<string, string>? headersValue = null)
        {
            throw new NotImplementedException();
        }

        public Task<(byte[]? content, HttpResponseMessage? response)> DownloadAsync(string endpoint, MultipartFormDataContent formDataContent, IList<string>? path = null, IDictionary<string, string>? parameters = null, IDictionary<string, string>? headersValue = null)
        {
            throw new NotImplementedException();
        }

        public Task<(byte[]? content, HttpResponseMessage? response)> DownloadAsync(string endpoint, StringContent stringContent, IList<string>? path = null, IDictionary<string, string>? parameters = null, IDictionary<string, string>? headersValue = null)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<T?>?> GetAsync<T>(string endpoint, IList<string>? path = null, IDictionary<string, string?>? parameters = null, IDictionary<string, string>? headersValue = null)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionDto<T>?> GetPagedAsync<T>(string endpoint, IList<string>? path = null, IDictionary<string, string?>? parameters = null, IDictionary<string, string>? headersValue = null)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<T?>?> PostAsync<T>(string endpoint, StringContent stringContent, IList<string>? path = null)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<T?>?> UpdateAsync<T>(string endpoint, string updateType, StringContent stringContent, IList<string>? path = null)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<T?>?> UploadAsync<T>(string endpoint, string uploadType, MultipartFormDataContent formDataContent, IList<string>? path = null)
        {
            throw new NotImplementedException();
        }
    }
}
