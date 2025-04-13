namespace SMS.Models.Requests.Result
{
    public class InsertResultDto
    {
        public string Grade { get; set; }

        public Guid ExamId { get; set; }

        public Guid StudentId { get; set; }
    }
}
