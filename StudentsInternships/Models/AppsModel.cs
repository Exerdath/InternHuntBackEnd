namespace StudentsInternships.Models
{
    public class AppsModel
    {
        public int ApplicationId { get; set; }
        public StudentModel Student  { get; set; }
        public InternshipModel Internship { get; set; }
        public string Status { get; set; }
    }
}
