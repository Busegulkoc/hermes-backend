using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Dtos.CityCountry
{
    public class GetCityCountryDto
    {
        public int cityCountryId { get; set; }
        public string city { get; set; } 
        public string country { get; set; } 
        public string currency { get; set; } 
        public int managerId { get; set; } 
    }
}