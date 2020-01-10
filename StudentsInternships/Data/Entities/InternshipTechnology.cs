using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsInternships.Data.Entities
{
    public class InternshipTechnology
    {
        public int InternshipId { get; set; }
        public Internship Internship { get; set; }
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }
    }
}
