using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace hermesTour.Models
{
    public class traveler
    {
        public int travelerId { get; set; }
        public string eMail { get; set; }
        public string name { get; set; } 
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public int wallet { get; set; }
        public Boolean vip { get; set; }
        public Boolean visa { get; set; }
        public List<Tour> Tours { get; set; }
        public List<Comment> Comments { get; set; }

    }
    //istersen default değerler ata !1
}