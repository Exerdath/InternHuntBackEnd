using System.Collections.Generic;

namespace StudentsInternships.Data.Entities
{
    public class Technology
    {
        public int TechnologyId { get; set; }
        public string Interest { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Internship> Internships { get; set; }
    }
}
