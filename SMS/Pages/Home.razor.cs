using Microsoft.AspNetCore.Components;
using MudBlazor;
using SMS.Models.Constants;
using SMS.Models.Requests.Identity;

namespace SMS.Pages
{
    public partial class Home : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            var role = await GetUserRole();

            NavigateRoleToDashboard(role);
        }

        private async Task<RolesDto> GetUserRole()
        {
            try
            {
                var result = await ProfileService.GetUserRole();

                if (result?.Result is null)
                {
                    SnackbarService.ShowSnackbar(result?.Message ?? Constants.Message.ExceptionMessage, Severity.Warning, Variant.Outlined);

                    return new RolesDto();
                }

                var role = result.Result;

                return role;
            }
            catch (Exception ex)
            {
                SnackbarService.ShowSnackbar(ex.Message, Severity.Warning, Variant.Outlined);
            }

            return new RolesDto();
        }

        private void NavigateRoleToDashboard(RolesDto role)
        {
            var route = role.Name switch
            {
                Constants.Roles.SuperAdmin => "/home/admin-dashboard",
                Constants.Roles.User => "/home/User",
                Constants.Roles.Teacher => "/home/Teacher",
                Constants.Roles.Student => "/home/Student",
                _ => "/login"
            };

            NavigationManager.NavigateTo(route);
        }

    }
}