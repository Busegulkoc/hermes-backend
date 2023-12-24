using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hermesTour.Services.AdminService
{
    public interface IAdminService
    {
        Task<ServiceResponse<List<GetAdminDto>>> GetAllAdmins();
        Task<ServiceResponse<GetAdminDto>> GetAdminById(int id);
        Task<ServiceResponse<AddAdminDto>> AddAdmin(AddAdminDto newAdmin);
        Task<ServiceResponse<GetAdminDto>> UpdateAdmin(UpdateAdminDto updatedAdmin);
        Task<ServiceResponse<List<GetAdminDto>>> DeleteAdmin(int id);

    }
}