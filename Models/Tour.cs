using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace hermesTour.Models
{
    public class Tour
    {
        public int tourId { get; set; }
        public string date { get; set; } //date tipi?
        public string name { get; set; } 
        public int rating { get; set; }
        public int price { get; set; }
        public List<traveler> TravelerList { get; set; }
        public List<Hotel> HotelList { get; set; }
        public List<Comment> CommentList { get; set; }
        public List<TransportationVehicle> TransportationVehicleList { get; set; }
        public List<CityCountry> CityCountryList { get; set; }
    }
}