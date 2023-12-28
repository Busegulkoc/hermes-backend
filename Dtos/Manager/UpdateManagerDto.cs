using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Dtos.Manager
{
    public class UpdateManagerDto
    {
        public int managerId { get; set; }
        public string eMail { get; set; }
        public string password { get; set; }
        public string name { get; set; } 
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public int salary { get; set; }
        public int cityCountryId { get; set; }
        
    }
}