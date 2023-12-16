using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Dtos.Tour
{
    public class UpdateTourDto
    {
        public int tourId { get; set; }
        public string date { get; set; } //date tipi?
        public string name { get; set; } 
        public int rating { get; set; }
        public int price { get; set; }
    }
}