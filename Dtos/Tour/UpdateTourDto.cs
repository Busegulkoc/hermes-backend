using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Dtos.Tour
{
    public class UpdateTourDto
    {
        public int tourId { get; set; }
        public DateTime date { get; set; } 
        public string name { get; set; } 
        public int rating { get; set; }
        public int price { get; set; }
        public string description { get; set; }
       
    }
}