using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.HotelService
{
    public interface IHotelService
    {
        Task<ServiceResponse<List<GetHotelDto>>> GetAllHotels();
        Task<ServiceResponse<GetHotelDto>> GetHotelById(int id);
        Task<ServiceResponse<List<GetHotelDto>>> AddHotel( AddHotelDto newHotel);
        Task<ServiceResponse<GetHotelDto>> UpdateHotel(UpdateHotelDto updatedHotel);
        Task<ServiceResponse<List<GetHotelDto>>> DeleteHotel(int id);
    }
}