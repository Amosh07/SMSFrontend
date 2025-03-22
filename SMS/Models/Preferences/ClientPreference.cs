using Microsoft.VisualBasic;

namespace SMS.Models.Preferences
{
    public class ClientPreference : IPreferences
    {
        public string Font { get; set; } = Constants.Constants.FontFamily.Poppins;
    }
}
