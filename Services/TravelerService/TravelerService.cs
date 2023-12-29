global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.TravelerService
{
    public class TravelerService : ITravelerService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public TravelerService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetTravelerDto>>> AddTraveler(AddTravelerDto newTraveler)
        {
            var serviceResponse = new ServiceResponse<List<GetTravelerDto>>();
            var traveler = _mapper.Map<traveler>(newTraveler);
            _context.Travelers.Add(traveler);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Travelers.Select(c => _mapper.Map<GetTravelerDto>(c)).ToListAsync();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetTravelerDto>>> AddTourToTraveler(int travelerId, int tourId)
        {
            var serviceResponse = new ServiceResponse<List<GetTravelerDto>>();
            try
            {
                var traveler = await _context.Travelers.FirstOrDefaultAsync(c => c.travelerId == travelerId);
                var tour = await _context.Tours.FirstOrDefaultAsync(c => c.tourId == tourId);
                if (traveler is null || tour is null)
                {
                    serviceResponse.Message = "Traveler or Tour not found.";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                if(traveler.Tours == null){
                    traveler.Tours = new List<Tour>();
                }
                if(tour.TravelerList == null){
                    tour.TravelerList = new List<traveler>();
                }
                traveler.Tours.Add(tour);
                traveler.wallet -= tour.price;
                tour.TravelerList.Add(traveler);

                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Travelers.Select(c => _mapper.Map<GetTravelerDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error adding Tour to Traveler: {ex.Message}";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetTravelerDto>>> GetAllTravelers()
        {
            var serviceResponse = new ServiceResponse<List<GetTravelerDto>>();
            var dbTravelers = await _context.Travelers.ToListAsync();
            serviceResponse.Data = dbTravelers.Select(c => _mapper.Map<GetTravelerDto>(c)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetTravelerDto>> GetTravelerById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTravelerDto>();
            var dbTraveler = await _context.Travelers.FirstOrDefaultAsync(c => c.travelerId == id);
            serviceResponse.Data = _mapper.Map<GetTravelerDto>(dbTraveler);
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetTravelerDto>> GetTravelerByEmailAndPassword(string email, string password)
        {
            var serviceResponse = new ServiceResponse<GetTravelerDto>();
            try{
                var dbTraveler = await _context.Travelers.FirstOrDefaultAsync(c => c.eMail == email && c.password == password);
                if (dbTraveler == null)
                {
                    serviceResponse.Message = "Traveler not found. You need to sign in.";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                serviceResponse.Data = _mapper.Map<GetTravelerDto>(dbTraveler);
                return serviceResponse;
            }
            catch(Exception ex){
                serviceResponse.Message =$"Error getting traveler: {ex.Message}";
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<List<GetTourDto>>> GetTourByTravelerId(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTourDto>>();
            try
            {
                var dbTraveler = await _context.Travelers.FirstOrDefaultAsync(c => c.travelerId == id);
                if (dbTraveler == null)
                {
                    serviceResponse.Message = "Traveler not found. You need to sign in.";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                var dbTours = await _context.Travelers.Where(c => c.travelerId == id).SelectMany(c => c.Tours).ToListAsync();
                serviceResponse.Data = dbTours.Select(c => _mapper.Map<GetTourDto>(c)).ToList();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error getting tours: {ex.Message}";
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<List<GetCommentDto>>> GetCommentByTravelerId(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCommentDto>>();
            try
            {
                var dbTraveler = await _context.Travelers.FirstOrDefaultAsync(c => c.travelerId == id);
                if (dbTraveler == null)
                {
                    serviceResponse.Message = "Traveler not found. You need to sign in.";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                var dbComments = await _context.Travelers.Where(c => c.travelerId == id).SelectMany(c => c.Comments).ToListAsync(); // selectmany ?
                serviceResponse.Data = dbComments.Select(c => _mapper.Map<GetCommentDto>(c)).ToList();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error getting comments: {ex.Message}";
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetTravelerDto>> UpdateTraveler(UpdateTravelerDto updatedTraveler)
        {
            var serviceResponse = new ServiceResponse<GetTravelerDto>();

            try
            {
                var trvlr = await _context.Travelers.FirstOrDefaultAsync(c => c.travelerId == updatedTraveler.travelerId);
                if (trvlr is null)
                {
                    throw new Exception($"Traveler with Id '{updatedTraveler.travelerId}' not found.");
                }

                //_mapper.Map<traveler>(updatedTraveler);

                trvlr.password = updatedTraveler.password;
                trvlr.name = updatedTraveler.name;
                trvlr.surname = updatedTraveler.surname;
                trvlr.eMail = updatedTraveler.eMail;
                trvlr.phoneNumber = updatedTraveler.phoneNumber;
                trvlr.wallet = updatedTraveler.wallet;
                trvlr.vip = updatedTraveler.vip;
                trvlr.visa = updatedTraveler.visa;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetTravelerDto>(trvlr);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }
        public async Task<ServiceResponse<GetTravelerDto>> UpdateTravelerWallet(int id, int wallet)
        {
            var serviceResponse = new ServiceResponse<GetTravelerDto>();

            try
            {
                var trvlr = await _context.Travelers.FirstOrDefaultAsync(c => c.travelerId == id);
                if (trvlr is null)
                {
                    serviceResponse.Message = "Traveler not found. You need to sign in.";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                
                trvlr.wallet += wallet;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetTravelerDto>(trvlr);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }
        public async Task<ServiceResponse<List<GetTravelerDto>>> DeleteTraveler(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTravelerDto>>();
            try
            {
                var travelerToDelete = await _context.Travelers.FindAsync(id);

                if (travelerToDelete == null)
                {
                    serviceResponse.Message = "Traveler not found";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.Travelers.Remove(travelerToDelete);
                await _context.SaveChangesAsync();

                var remainingTravelers = await _context.Travelers.ToListAsync();
                serviceResponse.Data = _mapper.Map<List<GetTravelerDto>>(remainingTravelers);
                serviceResponse.Success = true;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error deleting traveler: {ex.Message}";
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<List<GetTourDto>>> DeleteTourFromTraveler(int travelerId, int tourId)
        {
            var serviceResponse = new ServiceResponse<List<GetTourDto>>();
            try
            {
                var traveler = await _context.Travelers.FirstOrDefaultAsync(c => c.travelerId == travelerId);
                var tour = await _context.Tours.FirstOrDefaultAsync(c => c.tourId == tourId);
                if (traveler is null || tour is null)
                {
                    serviceResponse.Message = "Traveler or Tour not found.";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                if (!traveler.Tours.Any(c => c.tourId == tourId))
                {
                    serviceResponse.Message = "This traveler doesn't have this tour.";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                traveler.Tours.Remove(tour);
                traveler.wallet += tour.price;
                tour.TravelerList.Remove(traveler);

                await _context.SaveChangesAsync();
                serviceResponse.Data = traveler.Tours.Select(c => _mapper.Map<GetTourDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error deleting Tour from Traveler: {ex.Message}";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }






    }
}