using MudBlazor;

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

        public abstract class RoleRights
        {
            public const string GetAllRoleMenus = "role-rights";
            public const string AssignRoleMenus = "role-rights";
            public const string GetAllAssignedMenus = "role-rights";
        }

        public abstract class Class
        {
            public const string AddClass = "InsertClass";
            public const string GetAllClassDetails = "GetAll";
        }
        public abstract class Subject
        {
            public const string AddSubject = "InsertSubject";
            public const string GetAllSubjectDetails = "GetAll";
        }

        public abstract class Exam
        {
            public const string AddExam = "InsertExam";
            public const string GetAllExamDetails = "GetAll";
        }

        public abstract class Result
        {
            public const string AddResult = "InsertResult";
            public const string GetAllResultDetails = "GetAll";
        }

        public abstract class Attendance
        {
            public const string AddAttendance = "InsertAttendance";
            public const string GetAllAttendanceDetails = "GetAll";
        }

        public abstract class Student
        {
            public const string GetAllStudentById = "Dashboad/Student/StudentDashboard-count";
        }

        public abstract class Teacher
        {
            public const string GetAllTeacherById = "Dashboad/Teacher/TeacherDashboard-count";
        }

        public abstract class User
        {
            public const string GetUserProfileById = "Dashboad/User/TeacherDashboard-count";
        }
    }
}
