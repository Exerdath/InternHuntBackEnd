using System.Collections.Generic;

namespace StudentsInternships.Data.Entities
{
    public class Company:User
    {
        public string CompanyDescription { get; set; }
        public ICollection<Internship> Interships { get; set; }


    }
}
