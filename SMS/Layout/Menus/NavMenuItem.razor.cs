using Microsoft.AspNetCore.Components;
using SMS.Models.Constants;
using SMS.Models.Responses.Menu;

namespace SMS.Layout.Menus
{
    public partial class NavMenuItem
    {
        [Parameter] public RoleMenuResponseDto? Item { get; set; }

        private string Icon { get; set; } = Constants.Menu.DefaultIcon;

        protected override async Task OnInitializedAsync()
        {
            if (Item == null) return;

            var svgContent = await FileManager.RenderSvgContent(Constants.Menu.Path, $"{Item.Title.ToLower()}.svg");

            Icon = string.IsNullOrEmpty(svgContent) ? Constants.Menu.DefaultIcon : svgContent;
        }

    }
}