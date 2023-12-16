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
        Task<ServiceResponse<List<GetTourDto>>> AddTour( AddTourDto newTour);
        Task<ServiceResponse<GetTourDto>> UpdateTour(UpdateTourDto updatedTour);
        Task<ServiceResponse<List<GetTourDto>>> DeleteTour(int id);
    }
}