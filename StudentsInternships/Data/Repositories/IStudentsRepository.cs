using StudentsInternships.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsInternships.Data.Repositories
{
    public interface IStudentsRepository
    {
        void Add<Student>(Student student);
        Task<bool> SaveChangesAsync();
        Task<Student[]> GetAllStudentsAsync();
        Task<Student> GetStudentByUsernameAsync(string username);
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> EditStudent(Student student);
    }
}
