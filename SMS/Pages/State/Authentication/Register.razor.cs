using Microsoft.AspNetCore.Components;
using MudBlazor;
using SMS.Layout;
using SMS.Layout.Application;
using SMS.Models.Constants;
using SMS.Models.Requests.Identity;

namespace SMS.Pages.State.Authentication
{
    public partial class Register : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            SetPageTitle();
        }

        #region Page Title
        [CascadingParameter] public MainLayout Layout { get; set; } = new();

        private void SetPageTitle()
        {
            Layout.PageTitle = PageTitle.Register;
        }
        #endregion

        #region Password Visibility
        private bool PasswordVisibility { get; set; }
        private InputType PasswordInput { get; set; } = InputType.Password;
        private string PasswordInputIcon { get; set; } = Icons.Material.Filled.VisibilityOff;

        private void TogglePasswordVisibility()
        {
            PasswordVisibility = !PasswordVisibility;
            PasswordInputIcon = PasswordVisibility ? Icons.Material.Filled.Visibility : Icons.Material.Filled.VisibilityOff;
            PasswordInput = PasswordVisibility ? InputType.Text : InputType.Password;
        }
        #endregion

        #region Form Submission
        private UserRegisterDto RegisterDto { get; set; } = new();
        private bool BusySubmitting { get; set; }

        private async Task RegisterHandler()
        {
            BusySubmitting = true;

            try
            {
                var result = await AuthenticationService.UserRegister(RegisterDto);

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
                        NavigationManager.NavigateTo(await AuthenticationService.GetReturnUrl() ?? "/login");
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
            }
            catch (Exception ex)
            {
                SnackbarService.ShowSnackbar(ex.Message, Severity.Error, Variant.Outlined);
            }

            BusySubmitting = false;
        }
        #endregion
    }
}