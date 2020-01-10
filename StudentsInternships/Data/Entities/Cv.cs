using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsInternships.Data.Entities
{
    public class Cv
    {
        public int CvId { get; set; }
        public string FileLocation { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
