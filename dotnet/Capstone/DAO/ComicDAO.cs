using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class ComicDAO : IComicDAO
    {
        private readonly string connectionString;

        public ComicDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

    }
}
