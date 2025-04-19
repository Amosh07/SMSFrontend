//using Microsoft.AspNetCore.Components;
//using MudBlazor;
//using SMS.Layout.Application;
//using SMS.Models.Constants;
//using SMS.Models.Responses.Identity;

//public partial class Student : ComponentBase
//{
//    private bool IsTriggered { get; set; }

//    protected override async Task OnInitializedAsync()
//    {
//        SetPageTitle();
//        await GetStudentDetails();
//        await GetAllStudentById();
//    }

//    #region Dashboard Time Period Count
//    private int TimePeriod { get; set; } = Constants.TimePeriod.All;

//    private async Task OnStatusFilter(int timePeriod)
//    {
//        TimePeriod = timePeriod;
//        await GetAllStudentById();
//    }
//    #endregion

//    protected override void OnAfterRender(bool firstRender)
//    {
//        if (firstRender)
//        {
//            IsTriggered = !IsTriggered;
//        }
//    }

//    #region Page Title
//    [CascadingParameter] public MainLayout Layout { get; set; } = new();

//    private void SetPageTitle()
//    {
//        Layout.PageTitle = PageTitle.Student;
//    }
//    #endregion

//    #region Dashboard Count
//    private StudentDetails StudentDashboardCount { get; set; } = new();

//    private async Task GetAllStudentById()
//    {
//        var response = await DashboardService.GetAllStudentById(TimePeriod);

//        if (response?.Result is null)
//        {
//            SnackbarService.ShowSnackbar(response?.Message ?? Constants.Message.ExceptionMessage, Severity.Error, Variant.Outlined);
//            return;
//        }

//        StudentDashboardCount = response.Result;
//    }
//    #endregion

//    #region Student Details
//    private StudentDetails StudentDetails { get; set; } = new();

//    private async Task GetStudentDetails()
//    {
//        var response = await ProfileService.GetStudentProfile();

//        if (response?.Result is null)
//        {
//            SnackbarService.ShowSnackbar(response?.Message ?? Constants.Message.ExceptionMessage, Severity.Error, Variant.Outlined);
//            return;
//        }

//        StudentDetails = response.Result;
//    }
//    #endregion
//}