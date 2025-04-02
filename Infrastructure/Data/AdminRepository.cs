using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        private readonly ApplicationContext _context;

        public AdminRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public bool ExistsUserName(string userName)
        {
            return _context.Set<Admin>().Any(a=> a.UserName == userName);
        }
    }
}
