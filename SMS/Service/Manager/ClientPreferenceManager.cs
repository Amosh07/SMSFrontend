using Blazored.LocalStorage;
using SMS.Models.Constants;
using SMS.Models.Preferences;

namespace SMS.Service.Manager
{
    public class ClientPreferenceManager(ILocalStorageService localStorage) : IClientPreferenceManager
    {
        public async Task<IPreferences> GetPreference()
        {
            return await localStorage.GetItemAsync<ClientPreference>(Constants.LocalStorage.Preference) ?? new ClientPreference();
        }

        public async Task SetPreference(IPreferences preference)
        {
            await localStorage.SetItemAsync(Constants.LocalStorage.Preference, preference as ClientPreference);
        }
    }
}
