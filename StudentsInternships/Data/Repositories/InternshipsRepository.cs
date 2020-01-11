using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsInternships.Data.Entities;

namespace StudentsInternships.Data.Repositories
{
    public class InternshipsRepository : IInternshipsRepository
    {
        private readonly InternHuntContext _context;

        public InternshipsRepository(InternHuntContext context)
        {
            _context = context;
        }



        public void Add<Internship>(Internship internship)
        {
            _context.Add(internship);
        }

        public async Task<Internship> AddInternship(Internship internship)
        {
            internship.City = await _context.Cities.Where(c => c.CityId == internship.City.CityId).FirstOrDefaultAsync();
            internship.Technology = await _context.Technologies.Where(t => t.TechnologyId == internship.Technology.TechnologyId).FirstOrDefaultAsync();
            internship.Company = await _context.Companies.Where(c => c.UserId == internship.Company.UserId).FirstOrDefaultAsync();

            _context.Internships.Add(internship);
            await SaveChangesAsync();
            var newInternship = await _context.Internships.Where(i=>i.InternshipId==internship.InternshipId).FirstOrDefaultAsync();
            return newInternship;
        }

        public async Task<bool> DeleteInternship(int id)
        {
            IQueryable<Internship> query = _context.Internships.Where(i => i.InternshipId == id);
            var internship = query.FirstOrDefault();
            _context.Remove(internship);
            return await SaveChangesAsync();
        }

        public async Task<Internship[]> GetAllInternshipsAsync()
        {
            IQueryable<Internship> query = _context.Internships;
            query = query
                .Include(i => i.Company)
                .Include(i => i.City)
                .Include(i => i.Technology);

            return await query.ToArrayAsync();
        }

        public async Task<Internship[]> GetInternshipsById(int userId, string userType)
        {
            IQueryable<Internship> query = _context.Internships;
            query = query.Include(i => i.Company)
                        .Include(i => i.City)
                        .Include(i => i.Technology);


            if (userType.Equals("company"))
            {
                query = query.Where(i => i.Company.UserId == userId);
            }

            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
