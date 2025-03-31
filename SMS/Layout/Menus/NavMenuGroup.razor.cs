using Microsoft.AspNetCore.Components;
using SMS.Models.Responses.Menu;

namespace SMS.Layout.Menus
{
    public partial class NavMenuGroup
    {
        [Parameter] public RoleMenuResponseDto? Group { get; set; }
    }
}