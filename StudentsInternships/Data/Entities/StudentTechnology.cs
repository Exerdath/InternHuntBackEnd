using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsInternships.Data.Entities
{
    public class StudentTechnology
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }
    }
}
