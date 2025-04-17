namespace SMS.Models.Requests.Attendance
{
    public class InsertAttendanceDto
    {
        public Guid StudentId { get; set; }

        public Guid TeacherId { get; set; }

        public Guid ClassId { get; set; }

        public DateTime Date { get; set; }
    }
}
