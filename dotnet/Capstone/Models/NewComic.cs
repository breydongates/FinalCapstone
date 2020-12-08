using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class NewComic
    {
        public NewComic (string title, string publisher, int creatorId, string description)
        {
            this.Title = title;
            this.Publisher = publisher;
            this.CreatorId = creatorId;
            this.Description = description;
        }
        private  string Title { get; set; } 

        private string Publisher { get; set; }

        private int CreatorId { get; set; }

        private string Description { get; set; }
    }
}
