global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.TravelerService
{
    public class TravelerService : ITravelerService
    {
        private static List<traveler> travelerList = new List<traveler>{
            new traveler{ name = "Buse"},
            new traveler{travelerId = 1, name = "Senay"},
            new traveler{travelerId = 2, name = "Alperen"}
        };
        private readonly IMapper _mapper;
        public TravelerService( IMapper mapper){
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetTravelerDto>>> AddTraveler(AddTravelerDto newTraveler){
            var serviceResponse = new ServiceResponse<List<GetTravelerDto>>();
            var trvlr = _mapper.Map<traveler>(newTraveler);
            trvlr.travelerId = travelerList.Max(c => c.travelerId) +1; // when we use entity framework it will generate the proper id by itself.
            travelerList.Add(trvlr);
            serviceResponse.Data = travelerList.Select(c => _mapper.Map<GetTravelerDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTravelerDto>>> GetAllTravelers(){
            var serviceResponse = new ServiceResponse<List<GetTravelerDto>>();
            serviceResponse.Data = travelerList.Select(c => _mapper.Map<GetTravelerDto>(c)).ToList();
            return  serviceResponse;
        }
        public async Task<ServiceResponse<GetTravelerDto>> GetTravelerById(int id){
            var serviceResponse = new ServiceResponse<GetTravelerDto>();
            var trvlr = travelerList.FirstOrDefault(c => c.travelerId == id);
            serviceResponse.Data = _mapper.Map<GetTravelerDto>(trvlr);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTravelerDto>> UpdateTraveler(UpdateTravelerDto updatedTraveler){ 
            var serviceResponse = new ServiceResponse<GetTravelerDto>();

            try{
            var trvlr = travelerList.FirstOrDefault(c => c.travelerId == updatedTraveler.travelerId);
            if(trvlr is null ){
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

            serviceResponse.Data = _mapper.Map<GetTravelerDto>(trvlr);

            }
            catch(Exception ex ){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message; 
            }
            
            return serviceResponse;

        }
        public async  Task<ServiceResponse<List<GetTravelerDto>>> DeleteTraveler(int id){
            var serviceResponse = new ServiceResponse<List<GetTravelerDto>>();
            try{
                var trvlr = travelerList.First(c=> c.travelerId == id);
                if(trvlr is null){
                    throw new Exception($"Traveler with Id'{id}' not found.");
                }
                travelerList.Remove(trvlr);
                serviceResponse.Data = travelerList.Select(c => _mapper.Map<GetTravelerDto>(c)).ToList();

            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }







    }
}