using System.Collections.Generic;

namespace StudentsInternships.Data.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Internship> Internships { get; set; }

    }
}
