using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.TravelerService
{
    public interface ITravelerService
    {
        Task<ServiceResponse<List<GetTravelerDto>>> GetAllTravelers();
        Task<ServiceResponse<GetTravelerDto>> GetTravelerById(int id);
        Task<ServiceResponse<List<GetTravelerDto>>> AddTraveler( AddTravelerDto newTraveler);
        Task<ServiceResponse<GetTravelerDto>> UpdateTraveler(UpdateTravelerDto updatedTraveler);
        Task<ServiceResponse<List<GetTravelerDto>>> DeleteTraveler(int id);
    }
}