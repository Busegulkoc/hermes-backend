using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.TransportationVehicleService
{
    public class TransportationVehicleService : ITransportationVehicleService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public TransportationVehicleService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetTransportationVehicleDto>>> AddTransportationVehicle(AddTransportationVehicleDto newTransportationVehicle)
        {
            var serviceResponse = new ServiceResponse<List<GetTransportationVehicleDto>>();
            var vehicle = _mapper.Map<TransportationVehicle>(newTransportationVehicle);
            _context.TransportationVehicle.Add(vehicle);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.TransportationVehicle.Select(c => _mapper.Map<GetTransportationVehicleDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTransportationVehicleDto>>> GetAllTransportationVehicles()
        {
            var serviceResponse = new ServiceResponse<List<GetTransportationVehicleDto>>();
            var dbTransportationVehicles = await _context.TransportationVehicle.ToListAsync();
            serviceResponse.Data = dbTransportationVehicles.Select(c => _mapper.Map<GetTransportationVehicleDto>(c)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetTransportationVehicleDto>> GetTransportationVehicleById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTransportationVehicleDto>();
            var dbTransportationVehicle = await _context.TransportationVehicle.FirstOrDefaultAsync(c => c.transportationVehicleId == id);
            serviceResponse.Data = _mapper.Map<GetTransportationVehicleDto>(dbTransportationVehicle);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTransportationVehicleDto>> UpdateTransportationVehicle(UpdateTransportationVehicleDto updatedTransportationVehicle)
        {
            var serviceResponse = new ServiceResponse<GetTransportationVehicleDto>();

            try
            {
                var vehicle = await _context.TransportationVehicle.FirstOrDefaultAsync(c => c.transportationVehicleId == updatedTransportationVehicle.transportationVehicleId);
                if (vehicle is null)
                {
                    throw new Exception($"TransportationVehicle with Id '{updatedTransportationVehicle.transportationVehicleId}' not found.");
                }

                //_mapper.Map<traveler>(updatedTraveler);

                vehicle.type = updatedTransportationVehicle.type;
                vehicle.code = updatedTransportationVehicle.code;
                vehicle.capacity = updatedTransportationVehicle.capacity;

                await _context.SaveChangesAsync();


                serviceResponse.Data = _mapper.Map<GetTransportationVehicleDto>(vehicle);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }
        public async Task<ServiceResponse<List<GetTransportationVehicleDto>>> DeleteTransportationVehicle(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTransportationVehicleDto>>();
            try
            {
                var vehicle = await _context.TransportationVehicle.FirstAsync(c => c.transportationVehicleId == id);
                _context.TransportationVehicle.Remove(vehicle);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.TransportationVehicle.Select(c => _mapper.Map<GetTransportationVehicleDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}