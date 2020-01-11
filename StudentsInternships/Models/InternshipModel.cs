namespace StudentsInternships.Models
{
    public class InternshipModel
    {
        public int InternshipId { get; set; }
        public string InternshipName { get; set; }
        public string InternshipDescription { get; set; }
        public UserModel User { get; set; }
        public CityModel City { get; set; }
        public TechnologyModel Technology { get; set; }


    }
}
