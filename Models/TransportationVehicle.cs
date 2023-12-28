using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Models
{
    public class TransportationVehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int transportationVehicleId { get; set; }
        
        public string type { get; set; } 
        public string code { get; set; } 
        public int capacity { get; set; }
        public List<Tour> Tours { get; set; }
        public List<TransportationWorkers> TransportationWorkers { get; set; }
    }
}