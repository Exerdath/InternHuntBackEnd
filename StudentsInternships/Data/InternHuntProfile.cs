using AutoMapper;
using StudentsInternships.Data.Entities;
using StudentsInternships.Models;

namespace StudentsInternships.Data
{
    public class InternHuntProfile:Profile
    {
        public InternHuntProfile()
        {
            CreateMap<Student, StudentModel>()
                .ReverseMap();

            CreateMap<Internship, InternshipModel>()
                .ReverseMap();

            CreateMap<Company, CompanyModel>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;

            CreateMap<Application, AppsModel>()
                .ReverseMap();

            CreateMap<Technology, TechnologyModel>()
                .ReverseMap();

            CreateMap<City, CityModel>()
                .ReverseMap();

            CreateMap<User, UserModel>()
                .ReverseMap();

            CreateMap<Student, UserModel>().ReverseMap();
            CreateMap<Company, UserModel>().ReverseMap();

        }
    }
}
