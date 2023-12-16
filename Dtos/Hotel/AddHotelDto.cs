using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Dtos.Hotel
{
    public class AddHotelDto
    {
        public string name { get; set; } 
        public int cityCountryId { get; set; }
    }
}