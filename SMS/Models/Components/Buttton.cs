using MudBlazor;

namespace SMS.Models.Components
{
    public class Buttton : MudButton
    {
        protected override void OnParametersSet()
        {
            Class = $"{Class} btn btn--sm";
            DropShadow = false;
            base.OnParametersSet();
        }
    }
}
