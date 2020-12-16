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

        private string SQLAddComicToComics = "INSERT INTO comics (title, comic_desc, publisher, edition) OUTPUT inserted.comic_id VALUES (@title, @comic_desc, @publisher, @edition);";

        private string SQLAddComicToCollections = "INSERT INTO collections (collection_id, user_id, comic_id) VALUES (@collection_id, @user_id, @comic_id);";

        private string SQLGetComicsByCollectionId = "SELECT * FROM comics JOIN collections ON comics.comic_id = collections.comic_id WHERE collection_id = @collection_id;";

        private string SQLAddMainCharacter = "INSERT INTO characters (character_name) OUTPUT INSERTED.character_id VALUES (@maincharacter);";

        private string SQLAddCharacterToComic = "INSERT INTO comic_character (comic_id, character_id) VALUES (@comicId, @characterId);";


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
                cmd.Parameters.AddWithValue("@title", comic.Title.ToUpper());
                cmd.Parameters.AddWithValue("@comic_desc", comic.Description.ToUpper());
                cmd.Parameters.AddWithValue("@publisher", comic.Publisher.ToUpper());
                cmd.Parameters.AddWithValue("@edition", comic.Edition);

               //retreiving created comic id from the database
                comic.ComicId = Convert.ToInt32(cmd.ExecuteScalar());

                //Adding character to character
                cmd = new SqlCommand(SQLAddMainCharacter, conn);
                cmd.Parameters.AddWithValue("@maincharacter", comic.MainCharacter.ToUpper());

                //grabbing character ID
                int characterId = Convert.ToInt32(cmd.ExecuteScalar());

                //Add character to comic id
                cmd = new SqlCommand(SQLAddCharacterToComic, conn);
                cmd.Parameters.AddWithValue("@characterId", characterId);
                cmd.Parameters.AddWithValue("@comicId", comic.ComicId);

                //Add comic to collectionId
                cmd = new SqlCommand(SQLAddComicToCollections, conn);
                cmd.Parameters.AddWithValue("@collection_id", collectionId);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@comic_id", comic.ComicId);

                cmd.ExecuteNonQuery();

            }

            return comic;

        }
        
        public List<Comic> GetComicsByCollectionId(int collectionId)
        {
            List<Comic> comicsInCollection = new List<Comic>();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQLGetComicsByCollectionId, conn);
                cmd.Parameters.AddWithValue("@collection_id", collectionId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Comic comic = new Comic();
                    comic.Title = Convert.ToString(reader["title"]);
                    comic.Description = Convert.ToString(reader["comic_desc"]);
                    comic.Publisher = Convert.ToString(reader["publisher"]);
                    comic.CollectionId = Convert.ToInt32(reader["collection_id"]);
                    comic.ComicId = Convert.ToInt32(reader["comic_id"]);

                    comicsInCollection.Add(comic);

                }

            }

            return comicsInCollection;
        }

    }
}
