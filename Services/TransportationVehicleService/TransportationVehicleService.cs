using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.TransportationVehicleService
{
    public class TransportationVehicleService : ITransportationVehicleService
    {
        private static List<TransportationVehicle> transportationVehicleList = new List<TransportationVehicle>{
            new TransportationVehicle{ type = "Car"},
            new TransportationVehicle{transportationVehicleId = 1, type = "Plane"},
            new TransportationVehicle{transportationVehicleId = 2, type = "Ship"}
        };
        private readonly IMapper _mapper;
        public TransportationVehicleService( IMapper mapper){
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetTransportationVehicleDto>>> AddTransportationVehicle(AddTransportationVehicleDto newTransportationVehicle){
            var serviceResponse = new ServiceResponse<List<GetTransportationVehicleDto>>();
            var vehicle = _mapper.Map<TransportationVehicle>(newTransportationVehicle);
            vehicle.transportationVehicleId = transportationVehicleList.Max(c => c.transportationVehicleId) +1; // when we use entity framework it will generate the proper id by itself.
            transportationVehicleList.Add(vehicle);
            serviceResponse.Data = transportationVehicleList.Select(c => _mapper.Map<GetTransportationVehicleDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTransportationVehicleDto>>> GetAllTransportationVehicles(){
            var serviceResponse = new ServiceResponse<List<GetTransportationVehicleDto>>();
            serviceResponse.Data = transportationVehicleList.Select(c => _mapper.Map<GetTransportationVehicleDto>(c)).ToList();
            return  serviceResponse;
        }
        public async Task<ServiceResponse<GetTransportationVehicleDto>> GetTransportationVehicleById(int id){
            var serviceResponse = new ServiceResponse<GetTransportationVehicleDto>();
            var vehicle = transportationVehicleList.FirstOrDefault(c => c.transportationVehicleId == id);
            serviceResponse.Data = _mapper.Map<GetTransportationVehicleDto>(vehicle);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTransportationVehicleDto>> UpdateTransportationVehicle(UpdateTransportationVehicleDto updatedTransportationVehicle){ 
            var serviceResponse = new ServiceResponse<GetTransportationVehicleDto>();

            try{
            var vehicle = transportationVehicleList.FirstOrDefault(c => c.transportationVehicleId == updatedTransportationVehicle.transportationVehicleId);
            if(vehicle is null ){
                throw new Exception($"TransportationVehicle with Id '{updatedTransportationVehicle.transportationVehicleId}' not found.");
            }

            //_mapper.Map<traveler>(updatedTraveler);

            vehicle.type = updatedTransportationVehicle.type;
            vehicle.code = updatedTransportationVehicle.code;
            vehicle.capacity = updatedTransportationVehicle.capacity;
           

            serviceResponse.Data = _mapper.Map<GetTransportationVehicleDto>(vehicle);

            }
            catch(Exception ex ){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message; 
            }
            
            return serviceResponse;

        }
        public async  Task<ServiceResponse<List<GetTransportationVehicleDto>>> DeleteTransportationVehicle(int id){
            var serviceResponse = new ServiceResponse<List<GetTransportationVehicleDto>>();
            try{
                var vehicle = transportationVehicleList.First(c=> c.transportationVehicleId == id);
                if(vehicle is null){
                    throw new Exception($"Transportation Vehicle with Id'{id}' not found.");
                }
                transportationVehicleList.Remove(vehicle);
                serviceResponse.Data = transportationVehicleList.Select(c => _mapper.Map<GetTransportationVehicleDto>(c)).ToList();

            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }




    }
}