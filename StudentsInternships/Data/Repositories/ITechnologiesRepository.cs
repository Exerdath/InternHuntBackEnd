using StudentsInternships.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsInternships.Data.Repositories
{
    public interface ITechnologiesRepository
    {
        Task<bool> SaveChangesAsync();
        Task<Technology[]> getAllTechnologies();
    }
}
