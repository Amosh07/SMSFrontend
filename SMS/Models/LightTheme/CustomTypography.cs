using MudBlazor;

namespace SMS.Models.LightTheme
{
    public static class CustomTypography
    {
        public static Typography CmsTypography(string fontFamily = Constants.Constants.FontFamily.Poppins)
        {
            return new Typography
            {
                Default = new DefaultTypography
                {
                    FontFamily = [fontFamily, "Helvetica", "Arial", "sans-serif"],
                    FontSize = "clamp(14px, calc(0.875rem + ((1vw - 7.68px) * 0.1736)), 16px)",
                },
                H1 = new H1Typography
                {
                    FontFamily = [fontFamily, "Helvetica", "Arial", "sans-serif"],
                    FontSize = "clamp(20px, calc(1.25rem + ((1vw - 3.2px) * 0.625)), 30px)",
                },
                H2 = new H2Typography
                {
                    FontFamily = [fontFamily, "Helvetica", "Arial", "sans-serif"],
                    FontSize = "clamp(18px, calc(1.125rem + ((1vw - 3.2px) * 0.5)), 26px)",
                },
                H3 = new H3Typography
                {
                    FontFamily = [fontFamily, "Helvetica", "Arial", "sans-serif"],
                    FontSize = "clamp(18px, calc(1.125rem + ((1vw - 3.2px) * 0.375)), 24px)",
                },
                H4 = new H3Typography
                {
                    FontFamily = [fontFamily, "Helvetica", "Arial", "sans-serif"],
                    FontSize = "clamp(16px, calc(1rem + ((1vw - 3.2px) * 0.375)), 22px)",
                },
                H5 = new H5Typography
                {
                    FontFamily = [fontFamily, "Helvetica", "Arial", "sans-serif"],
                    FontSize = "clamp(15px, calc(0.9375rem + ((1vw - 3.2px) * 0.25)), 19px)",
                },
                H6 = new H6Typography
                {
                    FontFamily = [fontFamily, "Helvetica", "Arial", "sans-serif"],
                    FontSize = "clamp(14px, calc(0.875rem + ((1vw - 3.2px) * 0.1875)), 17px)",
                },
                Body1 = new Body1Typography
                {
                    FontFamily = [fontFamily, "Helvetica", "Arial", "sans-serif"],
                    FontSize = "clamp(13px, calc(0.8125rem + ((1vw - 3.2px) * 0.125)), 15px)",
                },
                Body2 = new Body2Typography
                {
                    FontFamily = [fontFamily, "Helvetica", "Arial", "sans-serif"],
                    FontSize = "13px",
                },
                Caption = new CaptionTypography
                {
                    FontFamily = [fontFamily, "Helvetica", "Arial", "sans-serif"],
                    FontSize = "12px",
                },
                Subtitle1 = new Subtitle1Typography
                {
                    FontFamily = [fontFamily, "Helvetica", "Arial", "sans-serif"],
                    FontSize = "clamp(13px, calc(0.8125rem + ((1vw - 3.2px) * 0.125)), 15px)",
                },
                Subtitle2 = new Subtitle2Typography
                {
                    FontFamily = [fontFamily, "Helvetica", "Arial", "sans-serif"],
                    FontSize = "13px",
                }
            };
        }
    }
}
