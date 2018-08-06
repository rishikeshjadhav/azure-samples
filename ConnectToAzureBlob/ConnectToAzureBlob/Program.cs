using ConnectToMongoDB;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToAzureBlob
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ConnectToMongo connectToMongoDB = new ConnectToMongo();
                connectToMongoDB.MyConnect();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occurred: " + exception.Message);
            }
        }
    }
}
