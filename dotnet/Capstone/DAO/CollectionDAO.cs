using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class CollectionDAO : ICollectionDAO
    {
        private readonly string connectionString;

        private string SQLAddCollection = ""; 

        public CollectionDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public AddCollection( NewCollection newCollection)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand

            }
        }

    }

}
