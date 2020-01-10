using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsInternships.Data.Entities;

namespace StudentsInternships.Data.Repositories
{
    public class ApplicationsRepository : IApplicationsRepository
    {
        private readonly InternHuntContext _context;

        public ApplicationsRepository(InternHuntContext context)
        {
            _context = context;
        }


        public void Add<Application>(Application application)
        {
            _context.Add(application);
        }

        public async Task<Application> ApplyToInternship(Application app)
        {
            _context.Add(app);
            await SaveChangesAsync();
            IQueryable<Application> query = _context.Applications;
            return query.Last();
        }

        public async Task<Application> ChangeAppStatus(Application app)
        {
            IQueryable<Application> query = _context.Applications;

            query = query.Where(a => a.ApplicationId == app.ApplicationId);
            var theApp = query.FirstOrDefault();
            theApp.Status = app.Status;
            await SaveChangesAsync();
            return theApp;
        }

        public async Task<Application[]> GetAllApplicationsAsync()
        {
            IQueryable<Application> query = _context.Applications;

            query = query
                .Include(a => a.Student)
                .Include(a => a.Internship)
                .ThenInclude(i=>i.Company);

            return await query.ToArrayAsync();
        }

        public async Task<Application[]> GetAppsById(int userId,string userType)
        {
            IQueryable<Application> query = _context.Applications;

            if (userType.Equals("student"))
            {
                query = query.Where(a => a.Student.UserId==userId)
                    .Include(a => a.Student)
                    .Include(a => a.Internship)
                    .ThenInclude(i => i.Company);
            }
            else
            {
                query = query.Include(a => a.Student)
                        .Include(a => a.Internship)
                        .ThenInclude(i => i.Company)
                        .Where(a => a.Internship.Company.UserId == userId);
            }

            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
