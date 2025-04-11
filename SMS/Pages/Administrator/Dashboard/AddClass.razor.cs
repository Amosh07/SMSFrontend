using Microsoft.AspNetCore.Components;
using MudBlazor;
using SMS.Layout.Application;
using SMS.Models.Constants;
using SMS.Models.Requests.Class;
using SMS.Models.Responses.Class;

namespace SMS.Pages.Administrator.Dashboard
{
    public partial class AddClass : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            SetPageTitle();
            await GetAllClassDetails();
        }

        #region Page Title
        [CascadingParameter] public MainLayout Layout { get; set; } = new();

        private void SetPageTitle()
        {
            Layout.PageTitle = PageTitle.Dashboard;
        }
        #endregion

        #region Add Class 

        private InsertClassDto InsertClassDto { get; set; } = new();

        private bool BusySubmitting { get; set; }
        private async Task InsertClass()
        {
            BusySubmitting = true;

            try
            {
                var result = await ClassService.AddClass(InsertClassDto);

                if (result?.Result is null)
                {
                    SnackbarService.ShowSnackbar(result?.Message ?? Constants.Message.ExceptionMessage, Severity.Error, Variant.Outlined);
                    BusySubmitting = false;
                    return;
                }

                switch (result.StatusCode)
                {
                    case StatusCode.Status200Ok:
                        SnackbarService.ShowSnackbar(result.Message, Severity.Success, Variant.Outlined);
                        break;
                    case StatusCode.Status404NotFound:
                    case StatusCode.Status400BadRequest:
                    case StatusCode.Status401Unauthorized:
                        SnackbarService.ShowSnackbar(result.Message, Severity.Warning, Variant.Outlined);
                        break;
                    case StatusCode.Status500InternalServerError:
                        SnackbarService.ShowSnackbar(result.Message, Severity.Error, Variant.Outlined);
                        break;
                }
            }
            catch (Exception ex)
            {
                SnackbarService.ShowSnackbar(ex.Message, Severity.Error, Variant.Outlined);
            }

            BusySubmitting = false;

        }
        #endregion

        private bool IsCreateModalOpen { get; set; }

        private async Task OpenRegisterClassModal()
        {
            
            IsCreateModalOpen = true;

            StateHasChanged();
        }
        private async Task OnUserFilter()
        {
            await GetAllClassDetails();
        }

        private bool? IsActive { get; set; } = Constants.ActivationStatus.Active;

        private async Task OnStatusFilter(bool? isActive)
        {
            IsActive = isActive;

            await GetAllClassDetails();
        }

        #region  GetAll Class Details 

        private List<GetClassDetailDto> GetClassDetails { get; set; } = new();

        private async Task GetAllClassDetails()
        {
            var response = await ClassService.GetAllClassDetails();

            if (response?.Result is null)
            {
                SnackbarService.ShowSnackbar(response?.Message ?? Constants.Message.ExceptionMessage, Severity.Error, Variant.Outlined);

                return;
            }

            GetClassDetails = response.Result;

        }
        #endregion

        #region Search and Filter
        private string _search = string.Empty;

        private string Search
        {
            get => _search;
            set
            {
                if (_search == value) return;
                _search = value;
                _ = OnSearchInputAsync(_search);
            }
        }

        private async Task OnSearchInputAsync(string search)
        {
            Search = search;

            await GetAllClassDetails();

            StateHasChanged();
        }

        #endregion

    }
}