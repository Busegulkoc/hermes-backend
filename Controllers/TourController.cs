using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hermesTour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;
        public TourController(ITourService tourService){
            _tourService = tourService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetTourDto>>>> Get(){
            return Ok(await _tourService.GetAllTours());
        }
        
        [HttpGet("getTourByCity")]
        public async Task<ActionResult<ServiceResponse<List<GetTourDto>>>> GetTourByCity(string city){
            var response = await _tourService.GetTourByCity(city);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTourDto>>> GetSingle(int id){
            return Ok(await _tourService.GetTourById(id));
        }
        [HttpGet("traveler-by-tourid")]
        public async Task<ActionResult<ServiceResponse<List<GetTravelerDto>>>> GetTravelerByTourId(int id)
        {
            var response = await   _tourService.GetTravelerByTourId(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("comment-by-tourid")]
        public async Task<ActionResult<ServiceResponse<List<GetCommentDto>>>> GetCommentByTourId(int id)
        {
            var response = await   _tourService.GetCommentByTourId(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTourDto>>>> AddTour(AddTourDto newTour){
            return Ok(await _tourService.AddTour(newTour));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetTourDto>>>> UpdateTour(UpdateTourDto updatedTour){
            var response = await _tourService.UpdateTour(updatedTour);
            if(response.Data is null){
                return NotFound(response);
            }
           
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async  Task<ActionResult<ServiceResponse<List<GetTourDto>>>> DeleteTour(int id){
            var response = await _tourService.DeleteTour(id);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}