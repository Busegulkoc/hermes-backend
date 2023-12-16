using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Services.CityCountryService
{
    public interface ICityCountryService
    {
        Task<ServiceResponse<List<GetCityCountryDto>>> GetAllCityCountrys();
        Task<ServiceResponse<GetCityCountryDto>> GetCityCountryById(int id);
        Task<ServiceResponse<List<GetCityCountryDto>>> AddCityCountry( AddCityCountryDto newCityCountry);
        Task<ServiceResponse<GetCityCountryDto>> UpdateCityCountry(UpdateCityCountryDto updatedCityCountry);
        Task<ServiceResponse<List<GetCityCountryDto>>> DeleteCityCountry(int id);
    }
}