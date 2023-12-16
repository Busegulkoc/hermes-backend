using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Dtos.TransportationVehicle
{
    public class AddTransportationVehicleDto
    {
        public string type { get; set; } 
        public string code { get; set; } 
        public int capacity { get; set; }
    }
}