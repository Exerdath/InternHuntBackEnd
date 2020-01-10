using System.Collections.Generic;

namespace StudentsInternships.Data.Entities
{
    public class Internship
    {
        public int InternshipId { get; set; }
        public string InternshipName { get; set; }
        public string InternshipDescription { get; set; }
        public Company Company { get; set; }
        public City City { get; set; }
        public ICollection<InternshipTechnology> InternshipTechnologies { get; set; }
        public ICollection<Application> Applications { get; set; }

    }
}
