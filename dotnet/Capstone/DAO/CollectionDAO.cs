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

        private string SQLAddCollection = "INSERT INTO users_collection (user_id, collection_name, is_private) VALUES (@user_id, @collection_name, @is_private);";

        private string SQLGetRecentlyCreatedIdentity = "SELECT @@IDENTITY;";

        private string SQLGetUserCollectionColumns = "SELECT * FROM users_collection WHERE collection_id = @collection_id;";

        private string SQLGetAllPublicCollections = "SELECT * FROM users_collection WHERE is_private = 0;";

        private string SQLGetAllCollectionsByUserId = "SELECT * FROM users_collection WHERE user_id = @user_id;";

        private string SQLGetNumberOfComicsInCollection = "SELECT COUNT(comic_id) FROM COLLECTIONS WHERE collection_id = @collection_id;";

        private string SQLGetNumOfComicsByPublisher = "SELECT * FROM COMICS JOIN collections on comics.comic_id = collections.comic_id " +
            "WHERE collections.collection_id = @collection_id AND comics.publisher = @publisher;";

        private string SQLGetNumOfComicsByCharacter = "SELECT * " +
            "FROM COMICS JOIN collections on comics.comic_id = collections.comic_id " +
            "JOIN comic_character on comics.comic_id = comic_character.comic_id " +
            "JOIN characters on comic_character.character_id = characters.character_id " +
            "WHERE collections.collection_id = @collection_id AND characters.character_name = @character;";

        private string SQLGetAllComicsByPublisher = "SELECT * FROM COMICS JOIN collections on comics.comic_id = collections.comic_id " +
            "WHERE comics.publisher = @publisher;";

        private string SQLGetAllComicsByCharacter = "SELECT * FROM COMICS " +
            "JOIN comic_character on comics.comic_id = comic_character.comic_id " +
            "JOIN characters on comic_character.character_id = characters.character_id " +
            "WHERE characters.character_name = @character;";

        private string SQLGetCountOfAllComics = "SELECT * FROM comics;";

        public CollectionDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Collection AddCollection(Collection newCollection, int userId)
        {
            Collection collection = new Collection();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                //Adding collection to users_collection table
                SqlCommand cmd = new SqlCommand(SQLAddCollection, conn);

                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@collection_name", newCollection.CollectionName);
                cmd.Parameters.AddWithValue("@is_private", newCollection.IsPrivate);

                cmd.ExecuteNonQuery();

                //Extracting the recently create collection's collection ID, setting it to the existingcollection object
                cmd = new SqlCommand(SQLGetRecentlyCreatedIdentity, conn);
                collection.CollectionId = Convert.ToInt32(cmd.ExecuteScalar());

                //Using the collectionId to pull values from that specific row in users_collection, setting them to the existingCollection object
                cmd = new SqlCommand(SQLGetUserCollectionColumns, conn);
                cmd.Parameters.AddWithValue("@collection_id", collection.CollectionId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    collection.CollectionName = Convert.ToString(reader["collection_name"]);
                    collection.UserId = Convert.ToInt32(reader["user_id"]);
                    collection.IsPrivate = Convert.ToBoolean(reader["is_private"]);
                }

            }

            return collection;
        }

        public List<Collection> GetAllPublicCollections()
        {
            List<Collection> result = new List<Collection>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQLGetAllPublicCollections, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Collection individualCollection = new Collection();

                    individualCollection.CollectionId = Convert.ToInt32(reader["collection_id"]);
                    individualCollection.UserId = Convert.ToInt32(reader["user_id"]);
                    individualCollection.CollectionName = Convert.ToString(reader["collection_name"]);
                    individualCollection.IsPrivate = Convert.ToBoolean(reader["is_private"]);

                    result.Add(individualCollection);
                }

            }

            return result;
        }

        public List<Collection> GetCollectionsByUserId(int userId)
        {
            List<Collection> result = new List<Collection>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQLGetAllCollectionsByUserId, conn);
                cmd.Parameters.AddWithValue("@user_id", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Collection individualCollection = new Collection();

                    individualCollection.CollectionId = Convert.ToInt32(reader["collection_id"]);
                    individualCollection.UserId = Convert.ToInt32(reader["user_id"]);
                    individualCollection.CollectionName = Convert.ToString(reader["collection_name"]);
                    individualCollection.IsPrivate = Convert.ToBoolean(reader["is_private"]);

                    result.Add(individualCollection);
                }

            }

            return result;

        }

        public int GetNumberOfComicsInCollection(int collectionId)
        {
            int numberOfComics;
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQLGetNumberOfComicsInCollection, conn);
                cmd.Parameters.AddWithValue("@collection_id", collectionId);

                numberOfComics = Convert.ToInt32(cmd.ExecuteScalar());             
                

            }
            return numberOfComics;
        }

        public List<Comic> GetNumByPublisherInCollection (StatRequest statRequest)
        {
            List<Comic> listOfComics = new List<Comic>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQLGetNumOfComicsByPublisher, conn);
                cmd.Parameters.AddWithValue("@collection_id", statRequest.CollectionId);
                cmd.Parameters.AddWithValue("@publisher", statRequest.Publisher.ToUpper());

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Comic comic = new Comic();
                    comic.Title = Convert.ToString(reader["title"]);
                    comic.Description = Convert.ToString(reader["comic_desc"]);
                    comic.Publisher = Convert.ToString(reader["publisher"]);
                    comic.ComicId = Convert.ToInt32(reader["comic_id"]);
                    comic.CollectionId = statRequest.CollectionId;

                    listOfComics.Add(comic);

                }

            }
            return listOfComics;

        }

        public List<Comic> GetNumByCharacterInCollection(StatRequest statRequest)
        {
            List<Comic> listOfComics = new List<Comic>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQLGetNumOfComicsByCharacter, conn);
                cmd.Parameters.AddWithValue("@collection_id", statRequest.CollectionId);
                cmd.Parameters.AddWithValue("@character", statRequest.Character.ToUpper());

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Comic comic = new Comic();
                    comic.Title = Convert.ToString(reader["title"]);
                    comic.Description = Convert.ToString(reader["comic_desc"]);
                    comic.Publisher = Convert.ToString(reader["publisher"]);
                    comic.ComicId = Convert.ToInt32(reader["comic_id"]);
                    comic.CollectionId = statRequest.CollectionId;

                    listOfComics.Add(comic);

                }
            
            }
            return listOfComics;

        }

        public List<Comic> GetAllComicsByPublisher(StatRequest statRequest)
        {
            List<Comic> listOfComics = new List<Comic>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQLGetAllComicsByPublisher, conn);
                cmd.Parameters.AddWithValue("@publisher", statRequest.Publisher.ToUpper());

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Comic comic = new Comic();
                    comic.Title = Convert.ToString(reader["title"]);
                    comic.Description = Convert.ToString(reader["comic_desc"]);
                    comic.Publisher = Convert.ToString(reader["publisher"]);
                    comic.ComicId = Convert.ToInt32(reader["comic_id"]);

                    listOfComics.Add(comic);

                }

            }
            return listOfComics;


        }

        public List<Comic> GetAllComicsByCharacter(StatRequest statRequest)
        {
            List<Comic> listOfComics = new List<Comic>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQLGetAllComicsByCharacter, conn);
                cmd.Parameters.AddWithValue("@character", statRequest.Character);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Comic comic = new Comic();
                    comic.Title = Convert.ToString(reader["title"]);
                    comic.Description = Convert.ToString(reader["comic_desc"]);
                    comic.Publisher = Convert.ToString(reader["publisher"]);
                    comic.ComicId = Convert.ToInt32(reader["comic_id"]);

                    listOfComics.Add(comic);

                }

            }

            return listOfComics;

        }

        public List<Comic> GetCountOfAllComics()
        {
            List<Comic> listOfComics = new List<Comic>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQLGetCountOfAllComics, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Comic comic = new Comic();
                    comic.Title = Convert.ToString(reader["title"]);
                    comic.Description = Convert.ToString(reader["comic_desc"]);
                    comic.Publisher = Convert.ToString(reader["publisher"]);
                    comic.ComicId = Convert.ToInt32(reader["comic_id"]);

                    listOfComics.Add(comic);
                }
            }

            return listOfComics;
        }

    }

}
