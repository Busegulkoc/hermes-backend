using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace hermesTour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityCountryController : ControllerBase
    {
        private readonly ICityCountryService _cityCountryService;
        public CityCountryController(ICityCountryService cityCountryService){
            _cityCountryService = cityCountryService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCityCountryDto>>>> Get(){
            return Ok(await _cityCountryService.GetAllCityCountrys());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCityCountryDto>>> GetSingle(int id){
            return Ok(await _cityCountryService.GetCityCountryById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCityCountryDto>>>> AddCityCountry(AddCityCountryDto newCityCountry){
            return Ok(await _cityCountryService.AddCityCountry(newCityCountry));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCityCountryDto>>>> UpdateCityCountry(UpdateCityCountryDto updatedCityCountry){
            var response = await _cityCountryService.UpdateCityCountry(updatedCityCountry);
            if(response.Data is null){
                return NotFound(response);
            }
           
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async  Task<ActionResult<ServiceResponse<List<GetCityCountryDto>>>> DeleteCityCountry(int id){
            var response = await _cityCountryService.DeleteCityCountry(id);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}