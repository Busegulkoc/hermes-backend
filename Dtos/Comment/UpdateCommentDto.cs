using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hermesTour.Dtos.Comment
{
    public class UpdateCommentDto
    {
        public int commentId { get; set; }
        public string commentText { get; set; } 
        public int travelerId { get; set; }
        public int tourId { get; set; }
    }
}