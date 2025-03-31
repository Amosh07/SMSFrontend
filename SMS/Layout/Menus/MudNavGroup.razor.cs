using Microsoft.AspNetCore.Components;
using SMS.Models.Responses.Menu;

namespace SMS.Layout.Menus
{
    public partial class MudNavGroup
    {
        [Parameter] public RoleMenuResponseDto? Group { get; set; }

    }
}