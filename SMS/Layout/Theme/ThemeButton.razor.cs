using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

namespace SMS.Layout.Theme
{
    public partial class ThemeButton
    {
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

    }
}