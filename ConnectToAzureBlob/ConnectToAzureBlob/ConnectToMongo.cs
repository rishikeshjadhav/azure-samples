using ConnectToAzureBlob;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToMongoDB
{
    public class ConnectToMongo
    {
        private static bool readData = true;
        private static bool uploadFile = false;

        private static string connectionString;
        private static IMongoClient mongoClient;
        private static IMongoDatabase mongoDatabase;
        private static MongoUrl mongoUrl;
        private static MongoClientSettings mongoClientSettings;
        private static IGridFSBucket gridFSBucket;
        private static ObjectId attachmentId;
        private static IMongoCollection<Employee> employeeCollection;

        public ConnectToMongo()
        {
            connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["DocumentDBEmulatorConnectionString"], CultureInfo.InvariantCulture);
            mongoUrl = new MongoUrl(connectionString);
            mongoClientSettings = MongoClientSettings.FromUrl(mongoUrl);
            mongoClientSettings.SslSettings = new SslSettings() { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            mongoClient = new MongoClient(mongoClientSettings);
            mongoDatabase = mongoClient.GetDatabase(mongoUrl.DatabaseName, null);
            gridFSBucket = new GridFSBucket(mongoDatabase);
            employeeCollection = mongoDatabase.GetCollection<Employee>("Employee");
        }

        public void MyConnect()
        {
            if (readData)
            {
                Employee test1 = employeeCollection.AsQueryable<Employee>().Where(item => item.Emp_Id == "OCSP001").ToList().SingleOrDefault();
                ConnectToBlob connectToBlob = new ConnectToBlob();
                connectToBlob.MyConnect();


                ////var filter = Builders<GridFSFileInfo>.Filter.Eq<ObjectId>("_id", test1.Files[0]);
                ////using (var cursor = gridFSBucket.Find(filter))
                ////{
                ////    var fileInfo = cursor.ToList().FirstOrDefault();
                ////    if (null != fileInfo)
                ////    {
                ////        var bytes = gridFSBucket.DownloadAsBytes(test1.Files[0]);
                ////    }
                ////}
            }
            else
            {
                if (uploadFile)
                {
                    ////var bytes = File.ReadAllBytes(@"C:\Users\rishikesh.jadhav\Desktop\Notes\work11.png");
                    ////attachmentId = gridFSBucket.UploadFromBytes("work11.png", bytes, new GridFSUploadOptions { ChunkSizeBytes = 64512, Metadata = new BsonDocument() });

                    IDictionary<string, object> test = new Dictionary<string, object>();
                    test.Add("aa11", "aa1111");
                    test.Add("bb11", "bb1111");
                    Employee currentEmployee = new Employee() { Emp_Id = "OCSP001", Emp_Name = "Rishikesh Jadhav", InActive = true, Created = DateTime.Now, CollectionDict = test, CollectionString = new List<string>() { "aaListItem", "bbListItem" }, Salary = 56000.89, Files = new List<ObjectId>() { attachmentId }, DynamicField = "abc", ObjectField = 16.89 };

                    //// Upload to Azure blob storage
                    ConnectToBlob connectToBlob = new ConnectToBlob();
                    currentEmployee.FilesUri.Add(connectToBlob.MyConnect());

                    employeeCollection.InsertOne(currentEmployee);
                }

            }
        }
    }
}
