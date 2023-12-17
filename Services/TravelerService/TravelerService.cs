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







    }
}