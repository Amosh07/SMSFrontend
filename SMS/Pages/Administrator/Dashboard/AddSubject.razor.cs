using Microsoft.AspNetCore.Components;
using MudBlazor;
using SMS.Layout.Application;
using SMS.Models.Constants;
using SMS.Models.Requests.Subject;
using SMS.Models.Responses.Subject;

namespace SMS.Pages.Administrator.Dashboard
{
    public partial class AddSubject : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            SetPageTitle();
            await GetAllSubjectDetails();
        }

        #region Page Title
        [CascadingParameter] public MainLayout Layout { get; set; } = new();

        private void SetPageTitle()
        {
            Layout.PageTitle = PageTitle.Dashboard;
        }
        #endregion

        #region Add Subject

        private InsertSubjectDto InsertSubjectDto { get; set; } = new();

        private bool BusySubmitting { get; set; }

        private async Task InsertSubject()
        {
            BusySubmitting = true;

            try
            {
                var result = await SubjectService.AddSubject(InsertSubjectDto);

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
                    case StatusCode.Status400BadRequest:
                    case StatusCode.Status401Unauthorized:
                    case StatusCode.Status404NotFound:
                        SnackbarService.ShowSnackbar(result.Message, Severity.Warning, Variant.Outlined);
                        break;
                    case StatusCode.Status500InternalServerError:
                        SnackbarService.ShowSnackbar(result.Message, Severity.Error, Variant.Outlined);
                        break;
                }

                await GetAllSubjectDetails();
                IsCreateModalOpen = false; 
                InsertSubjectDto = new(); 
            }
            catch (Exception ex)
            {
                SnackbarService.ShowSnackbar(ex.Message, Severity.Error, Variant.Outlined);
            }

            BusySubmitting = false;
        }

        #endregion

        private bool IsCreateModalOpen { get; set; }

        private async Task OpenRegisterSubjectModal()
        {
            IsCreateModalOpen = true;
            StateHasChanged();
        }

        private async Task OnUserFilter()
        {
            await GetAllSubjectDetails();
        }

        private bool? IsActive { get; set; } = Constants.ActivationStatus.Active;

        private async Task OnStatusFilter(bool? isActive)
        {
            IsActive = isActive;
            await GetAllSubjectDetails();
        }

        #region GetAll Subject Details

        private List<GetSubjectDetailDto> GetSubjectDetails { get; set; } = new();

        private async Task GetAllSubjectDetails()
        {
            var response = await SubjectService.GetAllSubjectDetails();

            if (response?.Result is null)
            {
                SnackbarService.ShowSnackbar(response?.Message ?? Constants.Message.ExceptionMessage, Severity.Error, Variant.Outlined);
                return;
            }

            GetSubjectDetails = response.Result;
        }

        #endregion

        #region Get All Subject

        private List<GetSubjectDetailDto> AllSubject { get; set; } = new();

        private async Task GetAllSubject()
        {
            var response = await SubjectService.GetAllSubjectDetails();

            if (response?.Result is null)
            {
                SnackbarService.ShowSnackbar(response?.Message ?? Constants.Message.ExceptionMessage, Severity.Error, Variant.Outlined);
                return;
            }

            AllSubject = response.Result;
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
            await GetAllSubjectDetails();
            StateHasChanged();
        }

        #endregion
    }
}
