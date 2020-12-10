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

<<<<<<< HEAD
        private string SQLAddComicToCollection = "INSERT INTO comics (title, comic_desc, publisher) VALUES (@title, @comic_desc, @publisher);";


=======

        private string SQLAddComicToCollection = "";
>>>>>>> 4f0a7fe7f46397c46ca310ee05bd4efd3afbf351

        public ComicDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;

        }

<<<<<<< HEAD
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
=======
        public Collection AddComicToCollection (Comic comic, Collection collection) {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

             SqlCommand cmd = new SqlCommand(SQLAddComicToCollection, conn); 
            } 
            

             Collection collectionResult = new Collection();
>>>>>>> 4f0a7fe7f46397c46ca310ee05bd4efd3afbf351

             return collectionResult;

        }


    }
}
