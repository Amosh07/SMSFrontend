namespace SMS.Models.Responses.Dashboard
{
    public class GetAdminCountDto
    {
        public int TotalUser { get; set; }

        public double? UserGrowthPercent { get; set; }

        public int TotalTeacher { get; set; }

        public double? TotalTeacherGrowth { get; set; }

        public int TotalStudent { get; set; }

        public double? TotalStudentGrowth { get; set; }

        public int TotalPendingRequests { get; set; }

        public double? TotalPendingRequestsGrowth { get; set; }
    }
}
