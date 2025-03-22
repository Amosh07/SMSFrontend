using SMS.Service.Dependency;

namespace SMS.Service.Manager
{
    public interface ILocalStorageManager : ITransientService
    {
        Task<T?> GetItemAsync<T>(string key);

        Task SetItemAsync<T>(string key, T value);

        Task ClearItemAsync(string key);
    }
}
