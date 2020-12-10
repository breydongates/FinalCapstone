using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Capstone.DAO
{
    public class ComicDAO : IComicDAO
    {
        private readonly string connectionString;

        private string SQLAddComicToCollection= ""

        public ComicDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;

        }

        public Collection AddComicToCollection (Comic comic, Collection collection)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQLAddComicToCollection, conn) 
            }
        }


    }
}
