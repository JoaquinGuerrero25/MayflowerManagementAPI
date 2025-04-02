using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Models
{
    public class AdminDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public AddressDto Address { get; set; } = new AddressDto();
        public bool IsEnabled { get; set; }

        public static AdminDto CreateAdminDto(Admin admin)
        {
            var newAdmin = new AdminDto()
            {
                Id = admin.Id,
                Name = admin.Name,
                LastName = admin.LastName,
                UserName = admin.UserName,
                Email = admin.Email,
                Phone = admin.Phone,
                Address = AddressDto.CreateAddressDto(admin.Address),
                IsEnabled = admin.IsEnabled,
            };

            return newAdmin;
        }

        public static IEnumerable<AdminDto> CreateListAdminDto(IEnumerable<Admin> admins)
        {
            List<AdminDto> list = new List<AdminDto>();

            foreach (var admin in admins)
            {
                list.Add(CreateAdminDto(admin));
            }

            return list;
        }
    }
}