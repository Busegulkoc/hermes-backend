using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Models
{
    public class CityCountry
    {
        public int cityCountryId { get; set; }
        public string city { get; set; } 
        public string country { get; set; } 
        public string currency { get; set; } 
        public List<Hotel> HotelList { get; set; }
        public List<Tour> Tours { get; set; }
        public Manager manager { get; set; }
    }
}