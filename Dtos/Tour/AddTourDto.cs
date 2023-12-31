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
        public List<int> cityCountryIdList { get; set; } 
        public List<int> TransportationVehicleIdList { get; set; }
        public List<int> HotelIdList { get; set; }
    }
}