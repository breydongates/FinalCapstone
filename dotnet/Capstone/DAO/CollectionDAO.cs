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

        public CollectionDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Collection AddCollection(Collection newCollection)
        {
            Collection collection = new Collection();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                //Adding collection to users_collection table
                SqlCommand cmd = new SqlCommand(SQLAddCollection, conn);

                cmd.Parameters.AddWithValue("@user_id", newCollection.UserId);
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

    }

}
