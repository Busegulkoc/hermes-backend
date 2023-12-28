using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hermesTour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        public ManagerController(IManagerService managerService){
            _managerService = managerService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetManagerDto>>>> Get(){
            return Ok(await _managerService.GetAllManagers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetManagerDto>>> GetSingle(int id){
            return Ok(await _managerService.GetManagerById(id));
        }
        [HttpGet("by-email-password")]
        public async Task<ActionResult<ServiceResponse<GetManagerDto>>> GetSingleByEmailAndPassword(string email, string password){
            return Ok(await _managerService.GetManagerByEmailAndPassword(email, password));
        }
        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetManagerDto>>>> AddManager(AddManagerDto newManager){
            return Ok(await _managerService.AddManager(newManager));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetManagerDto>>>> UpdateManager(UpdateManagerDto updatedManager){
            var response = await _managerService.UpdateManager(updatedManager);
            if(response.Data is null){
                return NotFound(response);
            }
           
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async  Task<ActionResult<ServiceResponse<List<GetManagerDto>>>> DeleteManager(int id){
            var response = await _managerService.DeleteManager(id);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}