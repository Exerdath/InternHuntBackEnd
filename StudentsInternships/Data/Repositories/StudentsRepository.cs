using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsInternships.Data.Entities;

namespace StudentsInternships.Data.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly InternHuntContext _context;

        public StudentsRepository(InternHuntContext context)
        {
            _context = context;
        }

        public void Add<Student>(Student student)
        {
            _context.Add(student);
        }

        public async Task<bool> EditStudent(Student student)
        {
            IQueryable<Student> query = _context.Students.Where(s=>s.UserId==student.UserId);
            var theStudent = query.FirstOrDefault();
            theStudent = student;
            return await SaveChangesAsync();
        }

        public async Task<Student[]> GetAllStudentsAsync()
        {
            IQueryable<Student> query = _context.Students;
            query = query.Include(s => s.City);
            return await query.ToArrayAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            IQueryable<Student> query = _context.Students;

            query = query.Where(u => u.UserId == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Student> GetStudentByUsernameAsync(string username)
        {
            IQueryable<Student> query = _context.Students;

            query = query.Where(u => u.Username.ToLower() == username.ToLower());

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
