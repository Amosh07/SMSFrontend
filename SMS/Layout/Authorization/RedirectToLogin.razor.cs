namespace SMS.Layout.Authorization
{
    public partial class RedirectToLogin
    {
        protected override void OnInitialized()
        {

          NavigationManager.NavigateTo("/login");
            
        }

    }
}