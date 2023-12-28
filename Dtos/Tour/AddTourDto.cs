using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Dtos.Tour
{
    public class AddTourDto
    {
        public string description { get; set; }
        public DateTime date { get; set; } 
        public string name { get; set; } 
        public int rating { get; set; }
        public int price { get; set; }
        public List<CityCountryDto> CityCountryList { get; set; } 
        public List<TransportationVehicleDto> TransportationVehicleList { get; set; }
        public List<HotelDto> HotelList { get; set; }
    }
}