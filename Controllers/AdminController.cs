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
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetAdminDto>>>> GetAllAdmins()
        {
            var response = await _adminService.GetAllAdmins();

            if (!response.Success)
            {
                return BadRequest(response.Message); // 400 Bad Request
            }

            return Ok(response); // 200 OK
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAdminDto>>> GetAdminById(int id)
        {
            var response = await _adminService.GetAdminById(id);

            if (!response.Success)
            {
                return NotFound(response.Message); // 404 Not Found
            }

            return Ok(response); // 200 OK
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<AddAdminDto>>> AddAdmin([FromBody] AddAdminDto newAdmin)
        {
            var response = await _adminService.AddAdmin(newAdmin);

            if (!response.Success)
            {
                return BadRequest(response.Message); // 400 Bad Request
            }

            return Ok(response); // 200 OK
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetAdminDto>>> UpdateAdmin(UpdateAdminDto updatedAdmin)
        {
            var response = await _adminService.UpdateAdmin(updatedAdmin);
            if (!response.Success)
            {
                return BadRequest(response.Message); // 400 Bad Request
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetAdminDto>>>> DeleteAdmin(int id)
        {
            var response = await _adminService.DeleteAdmin(id);
            if (!response.Success)
            {
                return BadRequest(response.Message); // 400 Bad Request
            }

            return Ok(response.Data); // 200 OK
        }
    }
}