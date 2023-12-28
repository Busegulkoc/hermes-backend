using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace hermesTour.Models
{
    public class Tour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tourId { get; set; }
        
        public DateTime date { get; set; } 
        public string name { get; set; } 
        public int rating { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public List<traveler> TravelerList { get; set; }
        public List<Hotel> HotelList { get; set; }
        public List<Comment> CommentList { get; set; }
        public List<TransportationVehicle> TransportationVehicleList { get; set; }
        public List<CityCountry> CityCountryList { get; set; }



        //traveler listesi,comment listesi eklendi, tran. eklendi, citycountry eklendi, hotel eklendi


    }
}