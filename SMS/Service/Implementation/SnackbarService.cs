using MudBlazor;
using SMS.Service.Interface;

namespace SMS.Service.Implementation
{
    public class SnackbarService(ISnackbar snackbar) : ISnackbarService
    {
        public void ShowSnackbar(string message, Severity severity, Variant variant)
        {
            snackbar.Add(message, severity, c => c.SnackbarVariant = variant);
        }
    }
}
