using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models;
using Application.Models.Request.Admin;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;

        public AdminService(IAdminRepository adminRepository, IUserRepository userRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
        }

        public AdminDto GetById(Guid id)
        {
            var admin = _adminRepository.GetById(id);

            return admin == null ? throw new CustomException($"No existe un admin con el id {id}") : AdminDto.CreateAdminDto(admin);
        }

        public IEnumerable<AdminDto> GetAll()
        {
            var admins = _adminRepository.GetAll();
            return AdminDto.CreateListAdminDto(admins);
        }

        public AdminDto CreateAdmin(AdminCreateRequest admin)
        {
            if (_userRepository.ExistsEmail(admin.Email))
            {
                throw new CustomException($"Ya existe un usuario registrado con este email {admin.Email}");
            }

            if (_adminRepository.ExistsUserName(admin.UserName))
            {
                throw new CustomException($"Ya existe un usuario registrado con este nombre de usuario {admin.Email}");
            }

            var newAdmin = new Admin()
            {
                Name = admin.Name,
                LastName = admin.LastName,
                Email = admin.Email,
                UserName = admin.UserName,
                Password = admin.Password,
                Phone = admin.Phone,
                Address = new Address()
                {
                    Number = admin.Address.Number,
                    Street = admin.Address.Street,
                    City = admin.Address.City,
                    State = admin.Address.State,
                    Country = admin.Address.Country,
                    PostalCode = admin.Address.PostalCode,
                },
                IsEnabled = admin.IsEnabled,
            };

            _adminRepository.Create(newAdmin);
            return AdminDto.CreateAdminDto(newAdmin);
        }

        public AdminDto UpdateAdmin(Guid id, AdminUpdateRequest admin)
        {
            var entity = _adminRepository.GetById(id) ?? throw new CustomException($"No se encontró el Admin con el id {id}");

            if (entity.Email != admin.Email && _userRepository.ExistsEmail(admin.Email))
            {
                throw new CustomException($"El email {admin.Email} ya está en uso");
            }

            if (entity.UserName != admin.UserName && _adminRepository.ExistsUserName(admin.UserName))
            {
                throw new CustomException($"Ya existe un usuario registrado con este nombre de usuario {admin.Email}");
            }

            entity.Name = admin.Name;
            entity.LastName = admin.LastName;
            entity.Email = admin.Email;
            entity.UserName = admin.UserName;
            entity.Password = admin.Password;
            entity.Phone = admin.Phone;
            entity.Address = new Address()
            {
                Number = admin.Address.Number,
                Street = admin.Address.Street,
                City = admin.Address.City,
                State = admin.Address.State,
                Country = admin.Address.Country,
                PostalCode = admin.Address.PostalCode,
            };
            entity.IsEnabled = admin.IsEnabled;

            _adminRepository.Update(entity);
            return AdminDto.CreateAdminDto(entity);
        }

        public AdminDto DeleteAdmin(Guid id)
        {
            var entity = _adminRepository.GetById(id) ?? throw new CustomException($"No se encontró el Admin con el id {id}");

            entity.IsEnabled = false;
            _adminRepository.Update(entity);

            return AdminDto.CreateAdminDto(entity);
        }
    }
}
