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
            var response = await _tourService.GetAllTours();
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
        
        [HttpGet("getTourByCity")]
        public async Task<ActionResult<ServiceResponse<List<GetTourDto>>>> GetTourByCity(string city){
            var response = await _tourService.GetTourByCity(city);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("getTourByPrice")]
        public async Task<ActionResult<ServiceResponse<List<GetTourDto>>>> GetTourByPrice(int price){
            var response = await _tourService.GetTourByPrice(price);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("getAllToursSortedByPrice")]
        public async Task<ActionResult<ServiceResponse<List<GetTourDto>>>> GetAllToursSortedByPrice(){
            var response = await _tourService.GetAllToursSortedByPrice();
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("getAllToursSortedByRating")]
        public async Task<ActionResult<ServiceResponse<List<GetTourDto>>>> GetAllToursSortedByRating(){
            var response = await _tourService.GetAllToursSortedByRating();
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTourDto>>> GetSingle(int id){
            var response = await _tourService.GetTourById(id);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
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
        [HttpGet("citycountry-by-tourid")]
        public async Task<ActionResult<ServiceResponse<List<GetCityCountryDto>>>> GetCityCountryByTourId(int id)
        {
            var response = await   _tourService.GetCityCountryByTourId(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("vehicle-by-tourid")]
        public async Task<ActionResult<ServiceResponse<List<GetTransportationVehicleDto>>>> GetVehicleByTourId(int id)
        {
            var response = await   _tourService.GetTransportationVehicleByTourId(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("hotel-by-tourid")]
        public async Task<ActionResult<ServiceResponse<List<GetHotelDto>>>> GetHotelByTourId(int id)
        {
            var response = await   _tourService.GetHotelByTourId(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("tour-by-city-date-peoplenumber")]
        public async Task<ActionResult<ServiceResponse<List<GetTourDto>>>> GetTourByCityDatePeopleNumber(string city, DateTime date, int peopleNumber)
        {
            var response = await   _tourService.GetTourByCityDatePeopleNumber(city, date, peopleNumber);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTourDto>>>> AddTour(AddTourDto newTour){
            var response = await _tourService.AddTour(newTour);
            if(response.Data is null){
                return NotFound(response);
            }   
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetTourDto>>>> UpdateTour(UpdateTourDto updatedTour){
            var response = await _tourService.UpdateTour(updatedTour);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPut("update-tour-description")]
        public async Task<ActionResult<ServiceResponse<GetTourDto>>> UpdateTourDescription(int id, string description){
            var response = await _tourService.UpdateTourDescription(id, description);
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