namespace StudentsInternships.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public CityModel City { get; set; }
        public string CompanyDescription { get; set; }
    }
}
