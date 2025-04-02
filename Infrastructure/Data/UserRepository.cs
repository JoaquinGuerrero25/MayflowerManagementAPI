using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool ExistsEmail(string email)
        {
            return _context.Set<User>().Any(u => u.Email == email);
        }

        public User? Authenticate(string userName, string password)
        {
            return null;
        }
    }
}
