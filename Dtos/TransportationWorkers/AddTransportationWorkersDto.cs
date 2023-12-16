using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Dtos.TransportationWorkers
{
    public class AddTransportationWorkersDto
    {
        public string type { get; set; }
        public string experience { get; set; }
        public int transportationVehicleId { get; set; }
        public string eMail { get; set; }
        public string name { get; set; } 
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public int salary { get; set; }
    }
}