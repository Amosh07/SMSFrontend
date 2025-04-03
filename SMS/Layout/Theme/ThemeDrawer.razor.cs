using Microsoft.AspNetCore.Components;
using SMS.Models.Preferences;

namespace SMS.Layout.Theme
{
    public partial class ThemeDrawer
    {
        [Parameter]
        public bool ThemeDrawerOpen { get; set; }

        [Parameter]
        public EventCallback<bool> ThemeDrawerOpenChanged { get; set; }

        [Parameter]
        [EditorRequired]
        public ClientPreference ThemePreference { get; set; } = default!;

        [EditorRequired]
        [Parameter]
        public EventCallback<ClientPreference?> ThemePreferenceChanged { get; set; }

        private async Task UpdateFontFamily()
        {
            await ThemePreferenceChanged.InvokeAsync(ThemePreference);
        }

    }
}