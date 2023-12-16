using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace hermesTour.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TravelerController : ControllerBase
    {
        private readonly ITravelerService _travelerService;
        public TravelerController(ITravelerService travelerService){
            _travelerService = travelerService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetTravelerDto>>>> Get(){
            return Ok(await _travelerService.GetAllTravelers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTravelerDto>>> GetSingle(int id){
            return Ok(await _travelerService.GetTravelerById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTravelerDto>>>> AddTraveler(AddTravelerDto newTraveler){
            return Ok(await _travelerService.AddTraveler(newTraveler));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetTravelerDto>>>> UpdateTraveler(UpdateTravelerDto updatedTraveler){
            var response = await _travelerService.UpdateTraveler(updatedTraveler);
            if(response.Data is null){
                return NotFound(response);
            }
           
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async  Task<ActionResult<ServiceResponse<List<GetTravelerDto>>>> DeleteTraveler(int id){
            var response = await _travelerService.DeleteTraveler(id);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}