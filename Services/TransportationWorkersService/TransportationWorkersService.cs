using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace hermesTour.Services.TransportationWorkersService
{
    public class TransportationWorkersService : ITransportationWorkersService
    {
        private static List<TransportationWorkers> transportationWorkersList = new List<TransportationWorkers>{
            new TransportationWorkers{ name = "Buse"},
            new TransportationWorkers{transportationWorkersId = 1, name = "Senay"},
            new TransportationWorkers{transportationWorkersId = 2, name = "Alperen"}
        };
        private readonly IMapper _mapper;
        public TransportationWorkersService( IMapper mapper){
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetTransportationWorkersDto>>> AddTransportationWorkers(AddTransportationWorkersDto newTransportationWorkers){
            var serviceResponse = new ServiceResponse<List<GetTransportationWorkersDto>>();
            var worker = _mapper.Map<TransportationWorkers>(newTransportationWorkers);
            worker.transportationWorkersId = transportationWorkersList.Max(c => c.transportationWorkersId) +1; // when we use entity framework it will generate the proper id by itself.  // bu oldu mu empId ile managerList
            transportationWorkersList.Add(worker);
            serviceResponse.Data = transportationWorkersList.Select(c => _mapper.Map<GetTransportationWorkersDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTransportationWorkersDto>>> GetAllTransportationWorkerss(){
            var serviceResponse = new ServiceResponse<List<GetTransportationWorkersDto>>();
            serviceResponse.Data = transportationWorkersList.Select(c => _mapper.Map<GetTransportationWorkersDto>(c)).ToList();
            return  serviceResponse;
        }
        public async Task<ServiceResponse<GetTransportationWorkersDto>> GetTransportationWorkersById(int id){
            var serviceResponse = new ServiceResponse<GetTransportationWorkersDto>();
            var worker = transportationWorkersList.FirstOrDefault(c => c.transportationWorkersId == id);
            serviceResponse.Data = _mapper.Map<GetTransportationWorkersDto>(worker);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTransportationWorkersDto>> UpdateTransportationWorkers(UpdateTransportationWorkersDto updatedTransportationWorkers){ 
            var serviceResponse = new ServiceResponse<GetTransportationWorkersDto>();

            try{
            var worker = transportationWorkersList.FirstOrDefault(c => c.transportationWorkersId == updatedTransportationWorkers.transportationWorkersId);
            if(worker is null ){
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


            serviceResponse.Data = _mapper.Map<GetTransportationWorkersDto>(worker);

            }
            catch(Exception ex ){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message; 
            }
            
            return serviceResponse;

        }
        public async  Task<ServiceResponse<List<GetTransportationWorkersDto>>> DeleteTransportationWorkers(int id){
            var serviceResponse = new ServiceResponse<List<GetTransportationWorkersDto>>();
            try{
                var worker = transportationWorkersList.First(c=> c.transportationWorkersId == id);
                if(worker is null){
                    throw new Exception($"Transportation Workers with Id'{id}' not found.");
                }
                transportationWorkersList.Remove(worker);
                serviceResponse.Data = transportationWorkersList.Select(c => _mapper.Map<GetTransportationWorkersDto>(c)).ToList();

            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

    }
}