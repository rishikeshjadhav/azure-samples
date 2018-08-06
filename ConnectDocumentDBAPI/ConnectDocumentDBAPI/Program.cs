using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace ConnectDocumentDBAPI
{
    public class Program
    {
        private const string EndpointUrl = "https://devdocdbapi.documents.azure.com:443/";
        private const string PrimaryKey = "yOPAi2FmcTglNWjwn4Pfn6mg2zqVO7fGaD8nmPaTKaxd1jRT73Kfb1bfdmpT6iPtxwmcKc6QbtR7qpA9TiHS3Q==";
        private DocumentClient client;

        private async Task GetStartedDemo()
        {
            client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            Database documentDB = new Database();
            documentDB.Id = "Test DB";
            await client.CreateDatabaseIfNotExistsAsync(documentDB);
        }

        static void Main(string[] args)
        {
            try
            {
                Program p = new Program();
                p.GetStartedDemo();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error Occurred: " + exception.Message);
            }
        }
    }
}
