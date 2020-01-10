using System;
using System.Collections.Generic;
using System.Linq;
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
            _context.Add(internship);
            await SaveChangesAsync();
            IQueryable<Internship> query = _context.Internships;
            return query.Last();
        }

        public async Task<bool> DeleteInternship(int id)
        {
            IQueryable<Internship> query = _context.Internships.Where(i=>i.InternshipId==id);
            var internship = query.FirstOrDefault();
            _context.Remove(internship);
            return await SaveChangesAsync();
        }

        public async Task<Internship[]> GetAllInternshipsAsync(bool includeCompany)
        {
            IQueryable<Internship> query = _context.Internships;

            if (includeCompany)
            {
                query = query
                    .Include(i => i.Company)
                    .Include(i => i.City);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Internship[]> GetInternshipsById(int userId, string userType)
        {
            IQueryable<Internship> query = _context.Internships;
            query = query.Include(i => i.Company);


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
