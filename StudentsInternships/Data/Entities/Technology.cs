using System.Collections.Generic;

namespace StudentsInternships.Data.Entities
{
    public class Technology
    {
        public int TechnologyId { get; set; }
        public string Interest { get; set; }
        public ICollection<StudentTechnology> StudentTechnologies { get; set; }
        public ICollection<InternshipTechnology> InternshipTechnologies { get; set; }
    }
}
