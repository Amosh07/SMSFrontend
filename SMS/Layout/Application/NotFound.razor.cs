using MudBlazor;
using SMS.Models.LightTheme;

namespace SMS.Layout.Application
{
    public partial class NotFound
    {
        private MudTheme _currentTheme = new LightTheme();

        protected override void OnInitialized()
        {
            _currentTheme = new LightTheme();
        }

    }
}