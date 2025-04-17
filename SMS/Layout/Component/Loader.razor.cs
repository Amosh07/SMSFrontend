using Microsoft.AspNetCore.Components;

namespace SMS.Layout.Component
{
    public partial class Loader
    {
        [Parameter] public string Type { get; set; } = "GIF";
    }
}