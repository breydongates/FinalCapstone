using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface ICollectionDAO
    {
        Collection AddCollection(Collection newCollection, int userId);

        List<Collection> GetAllPublicCollections();

        List<Collection> GetCollectionsByUserId(int userId);


    }
}
