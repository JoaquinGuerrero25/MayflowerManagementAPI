using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Models.Request.Admin;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        AdminDto GetById(Guid Id);
        IEnumerable<AdminDto> GetAll();
        AdminDto CreateAdmin(AdminCreateRequest admin);
        AdminDto UpdateAdmin(Guid id, AdminUpdateRequest admin);
        AdminDto DeleteAdmin(Guid Id);
    }
}
