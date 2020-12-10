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

        private string SQLAddComicToCollection = "INSERT INTO comics (title, comic_desc, publisher) VALUES (@title, @comic_desc, @publisher);";



        public ComicDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;

        }

        public Collection AddComicToCollection (Comic comic, int collectionId)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQLAddComicToCollection, conn);
                cmd.Parameters.AddWithValue("@title", comic.Title);
                cmd.Parameters.AddWithValue("@comic_desc", comic.Description);
                cmd.Parameters.AddWithValue("@publisher", comic.Publisher);

                cmd.ExecuteNonQuery();


            }

            Collection collectionResult = new Collection();

            return collectionResult;
        }


    }
}
