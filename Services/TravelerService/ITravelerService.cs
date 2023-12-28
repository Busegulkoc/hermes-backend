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
        Task<ServiceResponse<GetTravelerDto>> GetTravelerByEmailAndPassword(string email, string password);
        Task<ServiceResponse<List<GetTourDto>>> GetTourByTravelerId(int id);
        Task<ServiceResponse<List<GetCommentDto>>> GetCommentByTravelerId(int id);
        Task<ServiceResponse<List<GetTravelerDto>>> AddTraveler( AddTravelerDto newTraveler);
        Task<ServiceResponse<List<GetTravelerDto>>> AddTourToTraveler(int travelerId, int tourId);
        Task<ServiceResponse<GetTravelerDto>> UpdateTraveler(UpdateTravelerDto updatedTraveler);
        Task<ServiceResponse<GetTravelerDto>> UpdateTravelerWallet(int id, int wallet);
        Task<ServiceResponse<List<GetTravelerDto>>> DeleteTraveler(int id);
        Task<ServiceResponse<List<GetTourDto>>> DeleteTourFromTraveler(int travelerId, int tourId);
    }
}