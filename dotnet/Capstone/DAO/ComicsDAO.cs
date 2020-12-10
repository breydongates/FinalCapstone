using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Capstone.DAO
{
    public class ComicsDAO : IComicsDAO
    {
        private readonly string connectionString;

        private string SQLAddComicToComics = "INSERT INTO comics (title, comic_desc, publisher) OUTPUT inserted.comic_id VALUES (@title, @comic_desc, @publisher);";

        private string SQLAddComicToCollections = "INSERT INTO collections (collection_id, user_id, comic_id) VALUES (@collection_id, @user_id, @comic_id)";


        public ComicsDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;

        }


        public Comic AddComicToCollection (Comic comic, int collectionId, int userId)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                //adding comic to collectionId selected by user
                SqlCommand cmd = new SqlCommand(SQLAddComicToComics, conn);
                cmd.Parameters.AddWithValue("@title", comic.Title);
                cmd.Parameters.AddWithValue("@comic_desc", comic.Description);
                cmd.Parameters.AddWithValue("@publisher", comic.Publisher);

               //retreiving created comic id from the database
                comic.ComicId = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand(SQLAddComicToCollections, conn);

                cmd.Parameters.AddWithValue("@collection_id", collectionId);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@comic_id", comic.ComicId);

                cmd.ExecuteNonQuery();


            }

            return comic;

             

        }


    }
}
