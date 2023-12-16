using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hermesTour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService){
            _adminService = adminService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetAdminDto>>>> Get(){
            return Ok(await _adminService.GetAllAdmins());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAdminDto>>> GetSingle(int id){
            return Ok(await _adminService.GetAdminById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetAdminDto>>>> AddAdmin(AddAdminDto newAdmin){
            return Ok(await _adminService.AddAdmin(newAdmin));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetAdminDto>>>> UpdateAdmin(UpdateAdminDto updatedAdmin){
            var response = await _adminService.UpdateAdmin(updatedAdmin);
            if(response.Data is null){
                return NotFound(response);
            }
           
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async  Task<ActionResult<ServiceResponse<List<GetAdminDto>>>> DeleteAdmin(int id){
            var response = await _adminService.DeleteAdmin(id);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}