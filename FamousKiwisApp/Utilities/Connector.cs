
using MongoDB;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Driver;


namespace FamousKiwisApp.Utilities
{
    internal class Connector
    {

        private const string connectionUri = "mongodb+srv://yourHero:Yoobee01@bse2024.jon1dt4.mongodb.net/?retryWrites=true&w=majority&appName=BSE2024";
        private static MongoClient? _client;
        public static MongoDatabaseBase? _database;


        public static void EstablishConnection(string DB_Name)
        {
            try
            {

                _client = new MongoClient(connectionUri);
                _database = _client.GetDatabase(DB_Name) as MongoDatabaseBase;


                //debug only, can we successfuly ping our DB, response from Mongo is Bson not Json
                //if (_database != null)
                //{
                //    BsonDocument isOK = _database.RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                //    BsonValue result = isOK.GetElement("ok").Value;
                //    MessageBox.Show(result.ToString());
                //}
            }
            catch (Exception e)
            {
                MessageBox.Show("oh dear.");
                MessageBox.Show(e.Message);
            }

        }
    }
}
