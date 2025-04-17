using Microsoft.AspNetCore.Components;
using MudBlazor;
using SMS.Models.Constants;

namespace SMS.Layout.Component
{
    public partial class Avatar
    {
        [Parameter] public string Name { get; set; } = "A";

        [Parameter] public GenderType? Gender { get; set; }

        [Parameter] public string? ImageUrl { get; set; } = "";

        [Parameter] public string? FilePath { get; set; } = "";

        [Parameter] public decimal Height { get; set; } = 77;

        [Parameter] public decimal Width { get; set; } = 77;

        [Parameter] public bool IsMarginRequired { get; set; } = true;

        private string AvatarStyle { get; set; } = "";

        private string GenderIcon { get; set; } = "";

        private Color GenderColor { get; set; } = new();

        protected override void OnInitialized()
        {
            AvatarStyle = $"width: {Width}px; height: {Height}px;";

            if (Gender == null) return;

            if (Gender == GenderType.male)
            {
                GenderIcon = Icons.Material.Filled.Male;
                GenderColor = Color.Info;
            }
            else if (Gender == GenderType.female)
            {
                GenderIcon = Icons.Material.Filled.Female;
                GenderColor = Color.Tertiary;
            }
            else if (Gender == GenderType.others)
            {
                GenderIcon = Icons.Material.Filled.Transgender;
                GenderColor = Color.Primary;
            }
        }

        private string GetFilePath()
        {
            if (!string.IsNullOrEmpty(ImageUrl) && !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(FilePath))
                return FileManager.FetchFileUrl(ImageUrl, FilePath);

            return string.Empty;
        }

    }
}