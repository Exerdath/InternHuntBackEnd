using AutoMapper;
using StudentsInternships.Data.Entities;
using StudentsInternships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsInternships.Data.Repositories
{
    public interface IUserRepository
    {
        void Add<User>(User user);
        Task<bool> SaveChangesAsync();
        //TODO not find by username
        Task<User> GetUserAsync(int id);
        Task<User[]> GetAllUsersAsync();
        Task<User[]> GetAllUsersByPassword(string password);
        Task<User> AuthenticateUserAsync(string username, string password);
        Task<User> AuthenticateUser(string username, string password);
    }
}
