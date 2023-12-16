using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hermesTour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
         private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService){
            _hotelService = hotelService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetHotelDto>>>> Get(){
            return Ok(await _hotelService.GetAllHotels());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetHotelDto>>> GetSingle(int id){
            return Ok(await _hotelService.GetHotelById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetHotelDto>>>> AddHotel(AddHotelDto newHotel){
            return Ok(await _hotelService.AddHotel(newHotel));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetHotelDto>>>> UpdateHotel(UpdateHotelDto updatedHotel){
            var response = await _hotelService.UpdateHotel(updatedHotel);
            if(response.Data is null){
                return NotFound(response);
            }
           
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async  Task<ActionResult<ServiceResponse<List<GetHotelDto>>>> DeleteHotel(int id){
            var response = await _hotelService.DeleteHotel(id);
            if(response.Data is null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}