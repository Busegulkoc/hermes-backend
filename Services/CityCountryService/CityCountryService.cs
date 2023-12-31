using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.CityCountryService
{
    public class CityCountryService : ICityCountryService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CityCountryService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCityCountryDto>>> AddCityCountry(AddCityCountryDto newCityCountry)
        {
            var response = new ServiceResponse<List<GetCityCountryDto>>();

            try
            {
                var cityCountry = _mapper.Map<CityCountry>(newCityCountry);
                _context.CityCountry.Add(cityCountry);
                await _context.SaveChangesAsync();

                response.Data = (await GetAllCityCountrys()).Data; // Access the Data property of the response object
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Error adding cityCountry: {ex.Message}";
                response.Success = false;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetCityCountryDto>>> GetAllCityCountrys()
        {
            var response = new ServiceResponse<List<GetCityCountryDto>>();
            try
            {
                var cityCountry = await _context.CityCountry.ToListAsync();
                var getCityCountryDtoList =  _mapper.Map<List<GetCityCountryDto>>(cityCountry);
                for(int i = 0; i < cityCountry.Count; i++){
                    getCityCountryDtoList[i].managerId = cityCountry[i].manager.managerId;
                }
                response.Data = getCityCountryDtoList;
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting cityCountry: {ex.Message}";
                response.Success = false;
                return response;
            }
        }
        public async Task<ServiceResponse<GetCityCountryDto>> GetCityCountryById(int id)
        {
            var response = new ServiceResponse<GetCityCountryDto>();

            try
            {
                var cityCountry = await _context.CityCountry.FindAsync(id);

                if (cityCountry == null)
                {
                    response.Message = "CityCountry not found";
                    response.Success = false;
                    return response;
                }

                response.Data = _mapper.Map<GetCityCountryDto>(cityCountry);
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting cityCountry: {ex.Message}";
                response.Success = false;
                return response;
            }
        }

        public async Task<ServiceResponse<GetCityCountryDto>> UpdateCityCountry(UpdateCityCountryDto updatedCityCountry)
        {
            var response = new ServiceResponse<GetCityCountryDto>();

            try
            {
                var cityCountry = await _context.CityCountry.FindAsync(updatedCityCountry.cityCountryId);

                if (cityCountry == null)
                {
                    response.Message = "CityCountry not found";
                    response.Success = false;
                    return response;
                }

                // Güncelleme işlemleri
                cityCountry.city = updatedCityCountry.city;
                cityCountry.country = updatedCityCountry.country;

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCityCountryDto>(cityCountry);
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Error updating cityCountry: {ex.Message}";
                response.Success = false;
                return response;
            }
        }
        public async Task<ServiceResponse<List<GetCityCountryDto>>> DeleteCityCountry(int id)
        {
            var response = new ServiceResponse<List<GetCityCountryDto>>();

            try
            {
                var cityCountry = await _context.CityCountry.FindAsync(id);

                if (cityCountry == null)
                {
                    response.Message = "CityCountry not found";
                    response.Success = false;
                    return response;
                }

                _context.CityCountry.Remove(cityCountry);
                await _context.SaveChangesAsync();

                response.Data = (await GetAllCityCountrys()).Data; // Access the Data property
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Error deleting cityCountry: {ex.Message}";
                response.Success = false;
                return response;
            }
        }

    }




}