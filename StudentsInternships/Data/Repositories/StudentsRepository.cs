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

        public async Task<bool> AddStudent(Student student)
        {
            student.City = await _context.Cities.Where(c => c.CityId == student.City.CityId).FirstOrDefaultAsync();
            student.Technology = await _context.Technologies.Where(t => t.TechnologyId == student.Technology.TechnologyId).FirstOrDefaultAsync();

            _context.Students.Add(student);
            return await SaveChangesAsync();
        }

        public async Task<Student> EditStudent(Student student)
        {
            IQueryable<Student> query = _context.Students.Where(s=>s.UserId==student.UserId);
            var theStudent = query.FirstOrDefault();
            theStudent = student;
            var check = await SaveChangesAsync();
            if (check)
            {
                return theStudent;
            }
            return null;

        }

        public async Task<Student[]> GetAllStudentsAsync()
        {
            IQueryable<Student> query = _context.Students;
            query = query.Include(s => s.City)
                .Include(s=>s.Technology);
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
