using Microsoft.AspNetCore.Components;
using SMS.Models.Responses.Menu;

namespace SMS.Layout.Menus
{
    public partial class NavMenu
    {
        public string Search { get; set; } = "";

        [Parameter] public List<RoleMenuResponseDto>? MenuItems { get; set; }
    }
}