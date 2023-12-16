using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hermesTour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransportationVehicleController :ControllerBase
    {
        private readonly ITransportationVehicleService _transportationVehicleService;
        public TransportationVehicleController(ITransportationVehicleService transportationVehicleService){
            _transportationVehicleService = transportationVehicleService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetTransportationVehicleDto>>>> Get(){
            return Ok(await _transportationVehicleService.GetAllTransportationVehicles());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTransportationVehicleDto>>> GetSingle(int id){
            return Ok(await _transportationVehicleService.GetTransportationVehicleById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTransportationVehicleDto>>>> AddTransportationVehicle(AddTransportationVehicleDto newTransportationVehicle){
            return Ok(await _transportationVehicleService.AddTransportationVehicle(newTransportationVehicle));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetTransportationVehicleDto>>>> UpdateTransportationVehicle(UpdateTransportationVehicleDto updatedTransportationVehicle){
            var response = await _transportationVehicleService.UpdateTransportationVehicle(updatedTransportationVehicle);
            if(response.Data is null){
                return NotFound(response);
            }
           
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async  Task<ActionResult<ServiceResponse<List<GetTransportationVehicleDto>>>> DeleteTransportationVehicle(int id){
            var response = await _transportationVehicleService.DeleteTransportationVehicle(id);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}