using FamousKiwisApp.Commands;
using FamousKiwisApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FamousKiwisApp.Utilities;
using MongoDB.Driver;
using System.Diagnostics;
using System.Windows;
using MongoDB.Bson;

namespace FamousKiwisApp.ViewModels
{
    class AllKiwisCollection
    {
        // cannot easily make IMongoCollection an observable, so use a list
        public List<KiwisDTO> KiwisCollectionList;
        public IEnumerable<KiwisDTO> AllKiwisEnumerable => KiwisCollectionList;

        private IMongoCollection<KiwisDTO> DB_Results;
        public ICommand GetAllKiwisCommand { get; }


        private string _testname;

        public string TestName
        {
            get { return _testname; }
            set { _testname = value; }
        }



        public AllKiwisCollection()
        {
            TestName = "John";
            GetAllKiwisCommand = new GetAllKiwisCommand(this);
            Debug.WriteLine("fetching");
            IMongoDatabase? db = Connector._database;



            if (db != null)
            {
                BsonDocument filter = new BsonDocument();
                DB_Results = db.GetCollection<KiwisDTO>("persons");
                KiwisCollectionList = DB_Results.Find(filter).SortBy(x => x.LastName).ToList(); ;
                var resultsCount = DB_Results.CountDocuments(new BsonDocument());

            }

        }

        public string getTheText()
        {
            return "hello world";
        }
    }
}
