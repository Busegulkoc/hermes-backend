using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.TourService
{
    public interface ITourService
    {
        Task<ServiceResponse<List<GetTourDto>>> GetAllTours();
        Task<ServiceResponse<GetTourDto>> GetTourById(int id);
        Task<ServiceResponse<List<GetTravelerDto>>> GetTravelerByTourId(int id);
        Task<ServiceResponse<List<GetCommentDto>>> GetCommentByTourId(int id);
        Task<ServiceResponse<List<GetCityCountryDto>>> GetCityCountryByTourId(int id);
        Task<ServiceResponse<List<GetTransportationVehicleDto>>> GetTransportationVehicleByTourId(int id);
        Task<ServiceResponse<List<GetHotelDto>>> GetHotelByTourId(int id);
        Task<ServiceResponse<List<GetTourDto>>> AddTour( AddTourDto newTour);
        Task<ServiceResponse<GetTourDto>> UpdateTour(UpdateTourDto updatedTour);
        Task<ServiceResponse<List<GetTourDto>>> DeleteTour(int id);
        Task<ServiceResponse<List<GetTourDto>>> GetTourByCity(string city);
        Task<ServiceResponse<List<GetTourDto>>> GetTourByPrice(int price);
        Task<ServiceResponse<List<GetTourDto>>> GetAllToursSortedByPrice();
        Task<ServiceResponse<List<GetTourDto>>> GetAllToursSortedByRating();
    }
}