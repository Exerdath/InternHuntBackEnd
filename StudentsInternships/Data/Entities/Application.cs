namespace StudentsInternships.Data.Entities
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public Student Student { get; set; }
        public Internship Internship { get; set; }
        public Cv Cv { get; set; }
        public string Status { get; set; }

    }
}
