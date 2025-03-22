using Microsoft.AspNetCore.Components;
using MudBlazor;
using SMS.Models.Base;
using SMS.Models.LightTheme;
using SMS.Models.Preferences;

namespace SMS.Layout
{
    public partial class MainLayout
    {
        public string PageTitle { get; set; } = "School Management";

        public GlobalState? GlobalState { get; set; }

        private bool DrawerOpen { get; set; } = true;

        private ClientPreference? ClientPreference { get; set; }

        private MudTheme Theme { get; } = new LightTheme();

       // private List<RoleMenuResponseDto> AssignedMenus { get; set; } = [];

        private static bool RightToLeft => false;

        // private static bool OpenThemeDrawer { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ClientPreference = await ClientPreferenceManager.GetPreference() as ClientPreference ?? new ClientPreference();

            SetCurrentTheme(ClientPreference);

            var isUserLoggedIn = await AuthenticationService.IsUserLoggedIn();

            if (isUserLoggedIn)
            {
                var userResponse = await ProfileService.GetUserProfile();

               // var roleResponse = await MenuService.GetAllAssignedMenus();

                if (userResponse?.Result == null) return;

               // if (roleResponse?.Result == null) return;

                var userDetails = userResponse.Result;

               // var roleDetails = roleResponse.Result;

                GlobalState = new GlobalState()
                {
                    UserId = userDetails.Id,
                    Name = userDetails.Name,
                    EmailAddress = userDetails.Email,
                    RoleName = userDetails.RoleName,
                    RoleId = userDetails.RoleId,
                    ImageUrl = userDetails.ImageUrl
                };

               // AssignedMenus = roleDetails;
            }
            else
            {
                var returnUrl = NavigationManager.Uri;

                if (returnUrl.Contains("subordinate-answer-upload-form")) return;

                if (!returnUrl.Contains("login") && !returnUrl.Contains("register")) await AuthenticationService.SetUpReturnUrl(returnUrl);

                NavigationManager.NavigateTo("/login");
            }
        }

        // private async Task ThemePreferenceChanged(ClientPreference? themePreference)
        // {
        //     SetCurrentTheme(themePreference ?? new ClientPreference());
        //     
        //     await ClientPreferenceManager.SetPreference(themePreference ?? new ClientPreference());
        // }

        private void SetCurrentTheme(ClientPreference clientPreference)
        {
            Theme.Typography = CustomTypography.CmsTypography(clientPreference.Font);
        }

        private async Task LogoutHandler()
        {
            await AuthenticationService.LogOut();

            NavigationManager.NavigateTo("/login", true);
        }

        private void DrawerToggle()
        {
            DrawerOpen = !DrawerOpen;
        }

    }
}