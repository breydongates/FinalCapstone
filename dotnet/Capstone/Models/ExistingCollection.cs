using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ExistingCollection
    {
        public ExistingCollection (int userId, int collectionId, string collectionName)
        {
            this.UserId = userId;
            this.CollectionId = collectionId;
            this.CollectionName = collectionName;
        }
        private int UserId { get; set; }          
        
        private int CollectionId { get; set; }
        private string CollectionName { get; set; }

        private bool IsPrivate { get; set; }


    }
}
