using MudBlazor;
using SMS.Models.LightTheme;

namespace SMS.Layout
{
    public partial class EmptyLayout
    {
        private MudTheme MudTheme { get; } = new LightTheme();
    }
}