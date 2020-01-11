using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsInternships.Data.Entities;

namespace StudentsInternships.Data.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {

        private readonly InternHuntContext _context;

        public CitiesRepository(InternHuntContext context)
        {
            _context = context;
        }

        public async Task<City[]> GetAllCities()
        {
            IQueryable<City> query = _context.Cities;

            return await query.ToArrayAsync();
        }

        public async Task<City> getCityById(int cityId)
        {
            IQueryable<City> query = _context.Cities.Where(c=>c.CityId==cityId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
