using proj.Interfaces;
using proj.Domain;
using proj.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public void Add(User user)
        {
            try
            {
                using var context = new MyDatabaseContext();
                context.Users.Add(user);
                context.SaveChanges();
            }
            catch
            {
            }
        }

        public void Delete(int id)
        {
            try
            {
                using var context = new MyDatabaseContext();
                var user = context.Users.FirstOrDefault(x => x.UserId == id);
                if (user != null)
                {
                    context.Remove(user);
                    context.SaveChanges();
                }
            }
            catch { }
        }
        public void Update(int id, User user)
        {
            using var context = new MyDatabaseContext();

            var dbUser = context.Users.FirstOrDefault(x => x.UserId == id);
            if (dbUser == null) return;

            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.PasswordHash = user.PasswordHash;
            dbUser.Email = user.Email;
            dbUser.Phone = user.Phone;
            dbUser.RegistrationDate = user.RegistrationDate;
            dbUser.IsActive = user.IsActive;

            context.SaveChanges();
        }

        public User? Find(Predicate<User> predicate)
        {
            using var context = new MyDatabaseContext();
            return context.Users.FirstOrDefault(u => predicate(u));
        }
        public User? Get(int id)
        {
            using var context = new MyDatabaseContext();
            return context.Users.FirstOrDefault(x => x.UserId == id);
        }
        public IEnumerable<User> GetAll()
        {
            using var context = new MyDatabaseContext();
            return context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ToList();
        }

        private readonly MyDatabaseContext _context = new();

        public User? GetUser(string login, string password)
        {
            return _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefault(u => u.Email == login && u.PasswordHash == password);
        }
    }
}