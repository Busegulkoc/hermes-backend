using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace hermesTour.Services.TransportationWorkersService
{
    public class TransportationWorkersService : ITransportationWorkersService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public TransportationWorkersService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetTransportationWorkersDto>>> AddTransportationWorkers(AddTransportationWorkersDto newTransportationWorkers)
        {
            var serviceResponse = new ServiceResponse<List<GetTransportationWorkersDto>>();
            var worker = _mapper.Map<TransportationWorkers>(newTransportationWorkers);
            _context.TransportationWorkers.Add(worker);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.TransportationWorkers.Select(c => _mapper.Map<GetTransportationWorkersDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTransportationWorkersDto>>> GetAllTransportationWorkerss()
        {
            var serviceResponse = new ServiceResponse<List<GetTransportationWorkersDto>>();
            var dbTransportationWorkerss = await _context.TransportationWorkers.ToListAsync();
            serviceResponse.Data = dbTransportationWorkerss.Select(c => _mapper.Map<GetTransportationWorkersDto>(c)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetTransportationWorkersDto>> GetTransportationWorkersById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTransportationWorkersDto>();
            var dbTransportationWorkers = await _context.TransportationWorkers.FirstOrDefaultAsync(c => c.transportationWorkersId == id);
            serviceResponse.Data = _mapper.Map<GetTransportationWorkersDto>(dbTransportationWorkers);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTransportationWorkersDto>> UpdateTransportationWorkers(UpdateTransportationWorkersDto updatedTransportationWorkers)
        {
            var serviceResponse = new ServiceResponse<GetTransportationWorkersDto>();

            try
            {
                var worker = await _context.TransportationWorkers.FirstOrDefaultAsync(c => c.transportationWorkersId == updatedTransportationWorkers.transportationWorkersId);
                if (worker is null)
                {
                    throw new Exception($"Transportation Workers with Id '{updatedTransportationWorkers.transportationWorkersId}' not found.");
                }

                //_mapper.Map<traveler>(updatedTraveler);

                worker.name = updatedTransportationWorkers.name;
                worker.surname = updatedTransportationWorkers.surname;
                worker.eMail = updatedTransportationWorkers.eMail;
                worker.phoneNumber = updatedTransportationWorkers.phoneNumber;
                worker.salary = updatedTransportationWorkers.salary;
                worker.transportationVehicleId = updatedTransportationWorkers.transportationVehicleId;
                worker.type = updatedTransportationWorkers.type;
                worker.experience = updatedTransportationWorkers.experience;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetTransportationWorkersDto>(worker);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }
        public async Task<ServiceResponse<List<GetTransportationWorkersDto>>> DeleteTransportationWorkers(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTransportationWorkersDto>>();
            try
            {
                var workerToDelete = await _context.TransportationWorkers.FindAsync(id);

                if (workerToDelete == null)
                {
                    serviceResponse.Message = "Transportation Workers not found";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.TransportationWorkers.Remove(workerToDelete);
                await _context.SaveChangesAsync();

                var remainingWorkers = await _context.TransportationWorkers.ToListAsync();
                serviceResponse.Data = _mapper.Map<List<GetTransportationWorkersDto>>(remainingWorkers);
                serviceResponse.Success = true;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error deleting Transportation Workers: {ex.Message}";
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }

    }
}