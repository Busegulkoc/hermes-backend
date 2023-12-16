using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hermesTour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransportationWorkersController : ControllerBase
    {
         private readonly ITransportationWorkersService _transportationWorkersService;
        public TransportationWorkersController(ITransportationWorkersService transportationWorkersService){
            _transportationWorkersService = transportationWorkersService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetTransportationWorkersDto>>>> Get(){
            return Ok(await _transportationWorkersService.GetAllTransportationWorkerss());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTransportationWorkersDto>>> GetSingle(int id){
            return Ok(await _transportationWorkersService.GetTransportationWorkersById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTransportationWorkersDto>>>> AddTransportationWorkers(AddTransportationWorkersDto newTransportationWorkers){
            return Ok(await _transportationWorkersService.AddTransportationWorkers(newTransportationWorkers));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetTransportationWorkersDto>>>> UpdateTransportationWorkers(UpdateTransportationWorkersDto updatedTransportationWorkers){
            var response = await _transportationWorkersService.UpdateTransportationWorkers(updatedTransportationWorkers);
            if(response.Data is null){
                return NotFound(response);
            }
           
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async  Task<ActionResult<ServiceResponse<List<GetTransportationWorkersDto>>>> DeleteTransportationWorkers(int id){
            var response = await _transportationWorkersService.DeleteTransportationWorkers(id);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}