using SMS.Models.Preferences;
using SMS.Service.Dependency;

namespace SMS.Service.Manager
{
    public interface IPreferenceManager : ITransientService
    {
        Task<IPreferences> GetPreference();

        Task SetPreference(IPreferences preference);
    }
}
