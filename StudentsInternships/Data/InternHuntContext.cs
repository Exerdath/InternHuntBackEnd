using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentsInternships.Data.Entities;

namespace StudentsInternships.Data
{
    public class InternHuntContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Cv> Cvs { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=InternHunt.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Applications)
                .WithOne(a => a.Student);


            modelBuilder.Entity<Internship>()
                .HasMany(i => i.Applications)
                .WithOne(a => a.Internship);


            modelBuilder.Entity<Company>()
                .HasMany(c => c.Interships)
                .WithOne(i => i.Company);

            modelBuilder.Entity<City>()
                .HasMany(c => c.Students)
                .WithOne(s => s.City);

            modelBuilder.Entity<City>()
                .HasMany(c => c.Internships)
                .WithOne(i => i.City);

            modelBuilder.Entity<Technology>()
                .HasMany(t => t.Students)
                .WithOne(s => s.Technology);

            modelBuilder.Entity<Technology>()
                .HasMany(t => t.Internships)
                .WithOne(i => i.Technology);


            //One to one relationships
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Cv)
                .WithOne(c => c.Student)
                .HasForeignKey<Cv>(c => c.StudentId);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Cv)
                .WithOne(c => c.Application)
                .HasForeignKey<Cv>(c => c.ApplicationId);


            //Adding seed data~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //Students
            modelBuilder.Entity<Student>()
                .HasData(new
                {
                    UserId = 1,
                    Username = "Stud",
                    Password = "ent",
                    CityId = 1,
                    TechnologyId = 1
                },
                new
                {
                    UserId = 2,
                    Username = "Stu",
                    Password = "dent",
                    CityId = 2,
                    TechnologyId = 1
                },
                new
                {
                    UserId = 3,
                    Username = "St",
                    Password = "udent",
                    CityId = 2,
                    TechnologyId = 2
                },
                new
                {
                    UserId = 4,
                    Username = "S",
                    Password = "tudent",
                    CityId = 3,
                    TechnologyId = 3
                }
                );

            //Companies
            modelBuilder.Entity<Company>()
                .HasData(new
                {
                    UserId = 6,
                    Username = "Microsoft",
                    Password = "microsoft",
                    CompanyDescription = "Microsoft company"
                },
                new
                {
                    UserId = 7,
                    Username = "Apple",
                    Password = "apple",
                    CompanyDescription = "Apple company"
                }
                );

            //Internships
            modelBuilder.Entity<Internship>()
                .HasData(new
                {
                    InternshipId=1,
                    InternshipName="M1 Internship",
                    InternshipDescription="Microsoft 1 Internship",
                    CompanyId=6,
                    CityId=1,
                    TechnologyId=1
                },
                new
                {
                    InternshipId = 2,
                    InternshipName = "M2 Internship",
                    InternshipDescription = "Microsoft 2 Internship",
                    CompanyId = 6,
                    CityId = 2,
                    TechnologyId = 2

                },
                new
                {
                    InternshipId = 3,
                    InternshipName = "A1 Internship",
                    InternshipDescription = "Apple 1 Internship",
                    CompanyId = 7,
                    CityId = 3,
                    TechnologyId = 3
                },
                new
                {
                    InternshipId = 4,
                    InternshipName = "A2 Internship",
                    InternshipDescription = "Apple 2 Internship",
                    CompanyId = 7,
                    CityId = 1,
                    TechnologyId = 4
                }
                );;

            //Applications

            modelBuilder.Entity<Application>()
                .HasData(new
                {
                    ApplicationId =1,
                    StudentUserId = 1,
                    InternshipId = 1,
                    CvId =1,
                },
                new
                {
                    ApplicationId = 2,
                    StudentUserId = 1,
                    InternshipId = 2,
                    CvId = 1,
                },
                new
                {
                    ApplicationId = 3,
                    StudentUserId = 2,
                    InternshipId = 3,
                    CvId = 2,
                }
                );

            //Cvs
            modelBuilder.Entity<Cv>()
                .HasData(new
                {
                    CvId =1,
                    FileLocation ="Not important now",
                    StudentId =1,
                    ApplicationId =1
                },
                new
                {
                    CvId =2,
                    FileLocation ="Still not important now",
                    StudentId =2,
                    ApplicationId =2
                }
                );

            //Technologies
            modelBuilder.Entity<Technology>()
                .HasData(new
                {
                    TechnologyId=1,
                    Interest=".Net"
                },
                new
                {
                    TechnologyId = 2,
                    Interest = "React"
                },
                new
                {
                    TechnologyId = 3,
                    Interest = "Java"
                },
                new
                {
                    TechnologyId = 4,
                    Interest = "Javascript"
                },
                new
                {
                    TechnologyId = 5,
                    Interest = "Python"
                });

            //Cities
            modelBuilder.Entity<City>()
                .HasData(new
                {
                    CityId = 1,
                    CityName = "Cluj"
                },
                new
                {
                    CityId = 2,
                    CityName = "Brasov"
                },
                new
                {
                    CityId = 3,
                    CityName = "Bucuresti"
                }
            );
        }
    }
}
