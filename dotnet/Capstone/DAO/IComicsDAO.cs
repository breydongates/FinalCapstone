using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IComicsDAO
    {
       void AddComicToCollection(Comic comic, int collectionId, int userId);

    }
}
