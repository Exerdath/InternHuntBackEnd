using System.Collections.Generic;

namespace StudentsInternships.Models
{
    public class StudentModel: UserModel
    {
        public CityModel City { get; set; }
        public TechnologyModel Technology { get; set; }
    }
}
