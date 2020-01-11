using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsInternships.Data.Entities;

namespace StudentsInternships.Data.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly InternHuntContext _context;

        public CompaniesRepository(InternHuntContext context)
        {
            _context = context;
        }

        public void Add<Company>(Company company)
        {
            _context.Add(company);
        }

        public async Task<Company> EditCompany(Company company)
        {
            IQueryable<Company> query = _context.Companies.Where(c => c.UserId == company.UserId);
            var theCompany = query.FirstOrDefault();
            theCompany = company;
            var check=await SaveChangesAsync();
            if (check)
            {
                return theCompany;
            }
            return null;
        }

        public async Task<Company[]> GetAllCompaniesAsync()
        {
            IQueryable<Company> query = _context.Companies;
            return await query.ToArrayAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            IQueryable<Company> query = _context.Companies;

            query = query.Where(u => u.UserId == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
