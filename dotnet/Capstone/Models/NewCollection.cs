using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class NewCollection
    {
        public NewCollection(int userId, string collectionName, bool isPrivate)
        {
            this.UserId = userId;
            
            this.CollectionName = collectionName;

            this.IsPrivate = isPrivate; 

        }

        public int UserId { get; set; }
        public string CollectionName { get; set; }
        public bool IsPrivate { get; set; }
    }
}
