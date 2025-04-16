using Microsoft.AspNetCore.Components;

namespace SMS.Pages
{
    public partial class Index : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            var isUserLoggedIn = await AuthenticationService.IsUserLoggedIn();

            NavigationManager.NavigateTo(isUserLoggedIn ? "/home" : "/login");
        }

    }
}