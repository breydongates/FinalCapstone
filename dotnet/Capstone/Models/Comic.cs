using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Comic
    {
       
        public  string Title { get; set; }

        public string Publisher { get; set; }

        public int ComicId { get; set; } = 0;

        public string Description { get; set; }

        public int CollectionId { get; set; }
        
    }
}
