using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Models
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int hotelId { get; set; }
        
        public string name { get; set; } 
        public List<Tour> Tours { get; set; }
        public CityCountry cityCountry { get; set; }
        public int cityCountryId { get; set; }
    }
}