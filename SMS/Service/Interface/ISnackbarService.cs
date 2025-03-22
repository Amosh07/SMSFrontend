using MudBlazor;
using SMS.Service.Dependency;

namespace SMS.Service.Interface
{
    public interface ISnackbarService : IScopedService
    {
        void ShowSnackbar(string message, Severity severity, Variant variant);
    }
}
