namespace SMS.Models.Requests.Subject
{
    public class InsertSubjectDto
    {
        public string SubjectName { get; set; }

        public Guid ClassId { get; set; }
    }
}
