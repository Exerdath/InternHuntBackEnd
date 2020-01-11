using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsInternships.Data.Entities;

namespace StudentsInternships.Data.Repositories
{
    public class TechnologiesRepository : ITechnologiesRepository
    {
        private readonly InternHuntContext _context;

        public TechnologiesRepository(InternHuntContext context)
        {
            _context = context;
        }
        public async Task<Technology[]> getAllTechnologies()
        {
            IQueryable<Technology> query = _context.Technologies;

            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
