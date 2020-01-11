using StudentsInternships.Data.Entities;
using StudentsInternships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsInternships.Data.Repositories
{
    public interface IInternshipsRepository
    {
        void Add<Internship>(Internship internship);
        Task<Internship[]> GetAllInternshipsAsync();
        Task<bool> SaveChangesAsync();
        Task<Internship[]> GetInternshipsById(int userId, string userType);
        Task<Internship> AddInternship(Internship internship);
        Task<bool> DeleteInternship(int id);
    }
}
