using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Models
{
    public class Comment
    {
        public int commentId { get; set; }
        public string commentText { get; set; } 
        public traveler traveler { get; set; }
        public int travelerId { get; set; }
        public Tour tour { get; set; }
        public int tourId { get; set; }

        //traveler ve tour eklendi
    }
}