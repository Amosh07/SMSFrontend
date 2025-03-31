using Microsoft.AspNetCore.Components;
using MudBlazor;
using SMS.Layout.Application;
using SMS.Models.Constants;
using SMS.Models.Responses.Dashboard;
using SMS.Models.Responses.Identity;

namespace SMS.Pages.Administrator.Dashboard
{
    public partial class Dashboard : ComponentBase
    {
        private bool IsTriggered { get; set; }

        protected override async Task OnInitializedAsync()
        {
            SetPageTitle();
            await GetUserName();
            await GetAdminDashboardCount();
        }

        #region Dashboard Time Period Count
        private int TimePeriod { get; set; } = Constants.TimePeriod.All;

        private async Task OnStatusFilter(int timePeriod)
        {
            TimePeriod = timePeriod;
           await GetAdminDashboardCount();
        }
        #endregion

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                IsTriggered = !IsTriggered;
            }
        }

        #region Page Title
        [CascadingParameter] public MainLayout Layout { get; set; } = new();

        private void SetPageTitle()
        {
            Layout.PageTitle = PageTitle.Dashboard;
        }
        #endregion

        #region Dashboard Count
        private GetAdminCountDto AdminDashboardCount { get; set; } = new();

        private async Task GetAdminDashboardCount()
        {
            var response = await DashboardService.GetAdminDashboardCount(TimePeriod);

            if (response?.Result is null)
            {
                SnackbarService.ShowSnackbar(response?.Message ?? Constants.Message.ExceptionMessage, Severity.Error, Variant.Outlined);
                return;
            }

            AdminDashboardCount = response.Result;
        }
        #endregion

        #region Assign Username
        private UserDetail UserDetail { get; set; } = new();

        private async Task GetUserName()
        {
            var response = await ProfileService.GetUserProfile();

            if (response?.Result is null)
            {
                SnackbarService.ShowSnackbar(response?.Message ?? Constants.Message.ExceptionMessage, Severity.Error, Variant.Outlined);
                return;
            }

            UserDetail = response.Result;
        }

        #endregion
    }
}