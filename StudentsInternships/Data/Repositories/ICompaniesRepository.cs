using StudentsInternships.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsInternships.Data.Repositories
{
    public interface ICompaniesRepository
    {
        void Add<Company>(Company company);
        Task<bool> SaveChangesAsync();
        Task<Company[]> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<Company> EditCompany(Company company);
    }
}
