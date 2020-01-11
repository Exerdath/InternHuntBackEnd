using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsInternships.Data.Entities;
using StudentsInternships.Models;

namespace StudentsInternships.Data.Repositories
{
    public class UsersRepository:IUserRepository
    {
        private readonly InternHuntContext _context;

        public UsersRepository(InternHuntContext context)
        {
            _context = context;
        }

        public void Add<User>(User user)
        {
            _context.Add(user);
        }

        public async Task<User> AuthenticateUser(string username, string password)
        {
            IQueryable<User> query = _context.Users;
            query = query.Where(u => u.Username.ToLower().Equals(username.ToLower())
              && u.Password.ToLower().Equals(password.ToLower()));
            return await query.FirstOrDefaultAsync();
        }

        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            IQueryable<Student> queryStudents = _context.Students;

            queryStudents = queryStudents.Where(u => u.Username.ToLower().Equals(username.ToLower()) && u.Password.ToLower().Equals(password.ToLower()));


            if (queryStudents.Count() != 0)
            {
                queryStudents = queryStudents.Include(s => s.City).Include(s=>s.Technology);
                return await queryStudents.FirstOrDefaultAsync();

            }

            IQueryable<Company> queryCompanies = _context.Companies;

            queryCompanies = queryCompanies.Where(u => u.Username.ToLower().Equals(username.ToLower()) && u.Password.ToLower().Equals(password.ToLower()));

            return await queryCompanies.FirstOrDefaultAsync();
        }

        public async Task<User[]> GetAllUsersAsync()
        {
            IQueryable<User> query = _context.Users;
            return await query.ToArrayAsync();
        }

        public async Task<User[]> GetAllUsersByPassword(string password)
        {
            IQueryable<User> query = _context.Users;

            query = query.Where(u => u.Password.ToLower() == password.ToLower());

            return await query.ToArrayAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            IQueryable<User> query = _context.Users;

            query = query.Where(u => u.UserId == id);

            return await query.FirstOrDefaultAsync();
                
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            IQueryable<User> query = _context.Users.Where(u => u.Username == username);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
