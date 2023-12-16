using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.HotelService
{
    public class HotelService : IHotelService
    {
         private static List<Hotel> hotelList = new List<Hotel>{
            new Hotel{ name = "Kalahari"},
            new Hotel{hotelId = 1, name = "Senay"},
            new Hotel{hotelId = 2, name = "Buse"}
        };
        private readonly IMapper _mapper;
        public HotelService( IMapper mapper){
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetHotelDto>>> AddHotel(AddHotelDto newHotel){
            var serviceResponse = new ServiceResponse<List<GetHotelDto>>();
            var hotel = _mapper.Map<Hotel>(newHotel);
            hotel.hotelId = hotelList.Max(c => c.hotelId) +1; // when we use entity framework it will generate the proper id by itself.
            hotelList.Add(hotel);
            serviceResponse.Data = hotelList.Select(c => _mapper.Map<GetHotelDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetHotelDto>>> GetAllHotels(){
            var serviceResponse = new ServiceResponse<List<GetHotelDto>>();
            serviceResponse.Data = hotelList.Select(c => _mapper.Map<GetHotelDto>(c)).ToList();
            return  serviceResponse;
        }
        public async Task<ServiceResponse<GetHotelDto>> GetHotelById(int id){
            var serviceResponse = new ServiceResponse<GetHotelDto>();
            var hotel = hotelList.FirstOrDefault(c => c.hotelId == id);
            serviceResponse.Data = _mapper.Map<GetHotelDto>(hotel);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetHotelDto>> UpdateHotel(UpdateHotelDto updatedHotel){ 
            var serviceResponse = new ServiceResponse<GetHotelDto>();

            try{
            var hotel = hotelList.FirstOrDefault(c => c.hotelId == updatedHotel.hotelId);
            if(hotel is null ){
                throw new Exception($"Hotel with Id '{updatedHotel.hotelId}' not found.");
            }

            //_mapper.Map<traveler>(updatedTraveler);

            hotel.name = updatedHotel.name;
            hotel.cityCountryId = updatedHotel.cityCountryId;
           

            serviceResponse.Data = _mapper.Map<GetHotelDto>(hotel);

            }
            catch(Exception ex ){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message; 
            }
            
            return serviceResponse;

        }
        public async  Task<ServiceResponse<List<GetHotelDto>>> DeleteHotel(int id){
            var serviceResponse = new ServiceResponse<List<GetHotelDto>>();
            try{
                var hotel = hotelList.First(c=> c.hotelId == id);
                if(hotel is null){
                    throw new Exception($"Hotel with Id'{id}' not found.");
                }
                hotelList.Remove(hotel);
                serviceResponse.Data = hotelList.Select(c => _mapper.Map<GetHotelDto>(c)).ToList();

            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}