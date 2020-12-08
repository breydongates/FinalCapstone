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

        private int UserId { get; set; }
        private string CollectionName { get; set; }

        private bool IsPrivate { get; set; }
    }
}
