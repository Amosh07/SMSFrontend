using Microsoft.AspNetCore.Components;
using MudBlazor;
using SMS.Layout;
using SMS.Models.Constants;
using SMS.Models.Requests.Identity;

namespace SMS.Pages
{
    public partial class Login : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            SetPageTitle();

           // await LogoutHandler();
        }

        #region Page Title
        [CascadingParameter] public MainLayout Layout { get; set; } = new();

        private void SetPageTitle()
        {
            Layout.PageTitle = PageTitle.Login;
        }
        #endregion

        #region Password Visibility
        private bool PasswordVisibility { get; set; }

        private InputType PasswordInput { get; set; } = InputType.Password;

        private string PasswordInputIcon { get; set; } = Icons.Material.Filled.VisibilityOff;

        private void TogglePasswordVisibility()
        {
            if (PasswordVisibility)
            {
                PasswordVisibility = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                PasswordVisibility = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }
        #endregion

        #region Form Submission
        private LoginDto LoginDto { get; set; } = new();

        private bool BusySubmitting { get; set; }

        private async Task LoginHandler()
        {
            BusySubmitting = true;

            try
            {
                var result = await AuthenticationService.Login(LoginDto);

                if (result?.Result is null)
                {
                    SnackbarService.ShowSnackbar(result?.Message ?? Constants.Message.ExceptionMessage, Severity.Error, Variant.Outlined);
                    BusySubmitting = false;
                    return;
                }

                switch (result.StatusCode)
                {
                    case StatusCode.Status200Ok:
                        await AuthenticationService.SetUpAccessToken(result.Result.Token);
                        SnackbarService.ShowSnackbar(result.Message, Severity.Success, Variant.Outlined);
                        NavigationManager.NavigateTo(await AuthenticationService.GetReturnUrl() ?? "/home");
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

        #region Auto Logout
        private async Task LogoutHandler()
        {
            await AuthenticationService.LogOut();
        }
        #endregion
    }
}