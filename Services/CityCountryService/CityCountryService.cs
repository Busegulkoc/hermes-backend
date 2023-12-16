using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.CityCountryService
{
    public class CityCountryService : ICityCountryService
    {
        private static List<CityCountry> cityCountryList = new List<CityCountry>{
            new CityCountry{ city = "Clevelend"},
            new CityCountry{cityCountryId = 1, city = "Izmir"},
            new CityCountry{cityCountryId = 2, city = "Venice"}
        };
        private readonly IMapper _mapper;
        public CityCountryService( IMapper mapper){
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCityCountryDto>>> AddCityCountry(AddCityCountryDto newCityCountry){
            var serviceResponse = new ServiceResponse<List<GetCityCountryDto>>();
            var cityCountry = _mapper.Map<CityCountry>(newCityCountry);
            cityCountry.cityCountryId = cityCountryList.Max(c => c.cityCountryId) +1; // when we use entity framework it will generate the proper id by itself.
            cityCountryList.Add(cityCountry);
            serviceResponse.Data = cityCountryList.Select(c => _mapper.Map<GetCityCountryDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCityCountryDto>>> GetAllCityCountrys(){
            var serviceResponse = new ServiceResponse<List<GetCityCountryDto>>();
            serviceResponse.Data = cityCountryList.Select(c => _mapper.Map<GetCityCountryDto>(c)).ToList();
            return  serviceResponse;
        }
        public async Task<ServiceResponse<GetCityCountryDto>> GetCityCountryById(int id){
            var serviceResponse = new ServiceResponse<GetCityCountryDto>();
            var cityCountry = cityCountryList.FirstOrDefault(c => c.cityCountryId == id);
            serviceResponse.Data = _mapper.Map<GetCityCountryDto>(cityCountry);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCityCountryDto>> UpdateCityCountry(UpdateCityCountryDto updatedCityCountry){ 
            var serviceResponse = new ServiceResponse<GetCityCountryDto>();

            try{
            var cityCountry = cityCountryList.FirstOrDefault(c => c.cityCountryId == updatedCityCountry.cityCountryId);
            if(cityCountry is null ){
                throw new Exception($"CityCountry with Id '{updatedCityCountry.cityCountryId}' not found.");
            }

            //_mapper.Map<traveler>(updatedTraveler);

            cityCountry.city = updatedCityCountry.city;
            cityCountry.country = updatedCityCountry.country;
            cityCountry.currency = updatedCityCountry.currency;

            
            serviceResponse.Data = _mapper.Map<GetCityCountryDto>(cityCountry);

            }
            catch(Exception ex ){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message; 
            }
            
            return serviceResponse;

        }
        public async  Task<ServiceResponse<List<GetCityCountryDto>>> DeleteCityCountry(int id){
            var serviceResponse = new ServiceResponse<List<GetCityCountryDto>>();
            try{
                var cityCountry = cityCountryList.First(c=> c.cityCountryId == id);
                if(cityCountry is null){
                    throw new Exception($"CityCountry with Id'{id}' not found.");
                }
                cityCountryList.Remove(cityCountry);
                serviceResponse.Data = cityCountryList.Select(c => _mapper.Map<GetCityCountryDto>(c)).ToList();

            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }


    }
}