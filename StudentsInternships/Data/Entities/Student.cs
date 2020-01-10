using System.Collections.Generic;

namespace StudentsInternships.Data.Entities
{
    public class Student:User
    {
        public City City { get; set; }
        public Cv Cv { get; set; }
        public ICollection<Application> Applications { get; set; }
        public ICollection<StudentTechnology> StudentTechnologies { get; set; }

    }
}
