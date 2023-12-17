using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace hermesTour.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public AdminService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        // ...

        public async Task<ServiceResponse<AddAdminDto>> AddAdmin(AddAdminDto newAdmin)
        {
            var response = new ServiceResponse<AddAdminDto>();

            try
            {
                var admin = _mapper.Map<Admin>(newAdmin);
                _context.Admin.Add(admin);

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<AddAdminDto>(admin);
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                // Hata durumunda isteğe özel bir hata mesajı belirleme
                response.Message = $"Error adding admin: {ex.Message}";
                response.Success = false;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetAdminDto>>> GetAllAdmins()
        {
            var response = new ServiceResponse<List<GetAdminDto>>();

            try
            {
                var admins = await _context.Admin.ToListAsync();

                response.Data = _mapper.Map<List<GetAdminDto>>(admins);
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                // Hata durumunda isteğe özel bir hata mesajı belirleme
                response.Message = $"Error retrieving admins: {ex.Message}";
                response.Success = false;
                return response;
            }
        }
        public async Task<ServiceResponse<GetAdminDto>> GetAdminById(int id)
        {
            var response = new ServiceResponse<GetAdminDto>();

            try
            {
                var admin = await _context.Admin.FindAsync(id);

                if (admin == null)
                {
                    response.Message = "Admin not found";
                    response.Success = false;
                    return response;
                }

                response.Data = _mapper.Map<GetAdminDto>(admin);
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                // Hata durumunda isteğe özel bir hata mesajı belirleme
                response.Message = $"Error retrieving admin: {ex.Message}";
                response.Success = false;
                return response;
            }
        }

        public async Task<ServiceResponse<GetAdminDto>> UpdateAdmin(UpdateAdminDto updatedAdmin)
        {
            var response = new ServiceResponse<GetAdminDto>();

            try
            {
                var admin = await _context.Admin.FindAsync(updatedAdmin.adminId);

                if (admin == null)
                {
                    response.Message = "Admin not found";
                    response.Success = false;
                    return response;
                }

                admin.eMail = updatedAdmin.eMail;
                admin.name = updatedAdmin.name;
                admin.surname = updatedAdmin.surname;
                admin.phoneNumber = updatedAdmin.phoneNumber;
                admin.salary = updatedAdmin.salary;

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetAdminDto>(admin);
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Error updating admin: {ex.Message}";
                response.Success = false;
                return response;
            }
        }
        public async Task<ServiceResponse<List<GetAdminDto>>> DeleteAdmin(int id)
        {
            var response = new ServiceResponse<List<GetAdminDto>>();

            try
            {
                var adminToDelete = await _context.Admin.FindAsync(id);

                if (adminToDelete == null)
                {
                    response.Message = "Admin not found";
                    response.Success = false;
                    return response;
                }

                _context.Admin.Remove(adminToDelete);
                await _context.SaveChangesAsync();

                var remainingAdmins = await _context.Admin.ToListAsync();
                response.Data = _mapper.Map<List<GetAdminDto>>(remainingAdmins);
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Error deleting admin: {ex.Message}";
                response.Success = false;
                return response;
            }
        }

        // Task<ServiceResponse<List<GetAdminDto>>> IAdminService.AddAdmin(AddAdminDto newAdmin)
        // {
        //     throw new NotImplementedException();
        // }
    }
}