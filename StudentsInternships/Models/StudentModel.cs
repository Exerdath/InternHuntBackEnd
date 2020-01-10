using System.Collections.Generic;

namespace StudentsInternships.Models
{
    public class StudentModel: UserModel
    {
        public CityModel City { get; set; }
        public ICollection<TechnologyModel> Technologies { get; set; }
    }
}
