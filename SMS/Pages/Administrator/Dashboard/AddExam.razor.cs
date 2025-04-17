using Microsoft.AspNetCore.Components;
using MudBlazor;
using SMS.Layout.Application;
using SMS.Models.Constants;
using SMS.Models.Requests.Exam;
using SMS.Models.Responses.Exam;

namespace SMS.Pages.Administrator.Dashboard
{
    public partial class AddExam : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            SetPageTitle();
            await GetAllExamDetails();
        }

        [CascadingParameter] public MainLayout Layout { get; set; } = new();

        private void SetPageTitle()
        {
            Layout.PageTitle = PageTitle.Dashboard;
        }

        private InsertExamDto InsertExamDto { get; set; } = new();
        private bool BusySubmitting { get; set; }

        private async Task InsertExam()
        {
            BusySubmitting = true;

            try
            {
                var result = await ExamService.AddExam(InsertExamDto);

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

        private bool IsCreateModalOpen { get; set; }

        private async Task OpenRegisterExamModal()
        {
            IsCreateModalOpen = true;
            StateHasChanged();
        }

        private async Task OnUserFilter()
        {
            await GetAllExamDetails();
        }

        private bool? IsActive { get; set; } = Constants.ActivationStatus.Active;

        private async Task OnStatusFilter(bool? isActive)
        {
            IsActive = isActive;
            await GetAllExamDetails();
        }

        private List<GetExamDetailDto> GetExamDetails { get; set; } = new();

        private async Task GetAllExamDetails()
        {
            var response = await ExamService.GetAllExamDetails();

            if (response?.Result is null)
            {
                SnackbarService.ShowSnackbar(response?.Message ?? Constants.Message.ExceptionMessage, Severity.Error, Variant.Outlined);
                return;
            }

            GetExamDetails = response.Result;
        }

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
            await GetAllExamDetails();
            StateHasChanged();
        }
    }
}
