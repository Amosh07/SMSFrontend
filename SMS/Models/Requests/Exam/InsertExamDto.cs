namespace SMS.Models.Requests.Exam
{
    public class InsertExamDto
    {
        public Guid SubjectId { get; set; }

        public Guid ClassId { get; set; }
    }
}
