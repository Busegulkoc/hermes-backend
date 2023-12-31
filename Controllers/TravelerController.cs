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
            var response = await _travelerService.GetAllTravelers();
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTravelerDto>>> GetSingle(int id){
            var response = await _travelerService.GetTravelerById(id);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("by-email-password")]
        public async Task<ActionResult<ServiceResponse<GetTravelerDto>>> GetSingleByEmailAndPassword(string email, string password)
        {
            var response = await _travelerService.GetTravelerByEmailAndPassword(email, password);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("tour-by-travelerid")]
        public async Task<ActionResult<ServiceResponse<List<GetTourDto>>>> GetTourByTravelerId(int id)
        {
            var response = await   _travelerService.GetTourByTravelerId(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("comment-by-travelerid")]
        public async Task<ActionResult<ServiceResponse<List<GetCommentDto>>>> GetCommentByTravelerId(int id)
        {
            var response = await   _travelerService.GetCommentByTravelerId(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTravelerDto>>>> AddTraveler(AddTravelerDto newTraveler){
            var response = await _travelerService.AddTraveler(newTraveler);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost("add-Tour")]
        public async Task<ActionResult<ServiceResponse<List<GetTravelerDto>>>> AddTourToTraveler(int travelerId, int tourId)
        {
            var response = await  _travelerService.AddTourToTraveler(travelerId, tourId);
            if (response.Data is null)
            {
                return NotFound(response);
            }
             return Ok(response);
        }
        /*[HttpPost("add-favorite-tour")]
        public async Task<ActionResult<ServiceResponse<List<GetTourDto>>>> AddFavoriteTourToTraveler(int travelerId, int tourId)
        {
            var response = await _travelerService.AddFavoriteTourToTraveler(travelerId, tourId);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }*/

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetTravelerDto>>>> UpdateTraveler(UpdateTravelerDto updatedTraveler){
            var response = await _travelerService.UpdateTraveler(updatedTraveler);
            if(response.Data is null){
                return NotFound(response);
            }
           
            return Ok(response);
        }
        [HttpPut("update-wallet")]
        public async Task<ActionResult<ServiceResponse<List<GetTravelerDto>>>> UpdateTravelerWallet(int id, int wallet)
        {
            var response = await _travelerService.UpdateTravelerWallet(id, wallet);
            if (response.Data is null)
            {
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
        [HttpDelete("delete-tour")]
        public async Task<ActionResult<ServiceResponse<List<GetTourDto>>>> DeleteTourFromTraveler(int travelerId, int tourId)
        {
            var response = await _travelerService.DeleteTourFromTraveler(travelerId, tourId);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}