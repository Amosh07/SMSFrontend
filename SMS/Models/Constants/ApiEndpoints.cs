namespace SMS.Models.Constants
{
    public abstract class ApiEndpoints
    {
        public abstract class Authentication
        {
            public const string Login = "authentication/login";
            public const string Logout = "authentication/logout";
            public const string UserRegister = "authentication/user-registration";
        }

        public abstract class Profile
        {
            public const string GetUserProfile = "profile";
            public const string GetUserRole = "profile/role";
        }

        public abstract class Dashboard
        {
            public const string GetAdminDashboardCount = "dashboard/admin/dashboard-count";
        }
    }
}
