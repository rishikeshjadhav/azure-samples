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
    public class ConnectToBlob
    {
        private static bool uploadBlob = false;
        private static bool listBlobs = false;

        private static CloudStorageAccount storageAccount;
        private static CloudBlobClient blobClient;
        private static CloudBlobContainer blobContainer;
        private static CloudBlockBlob blockBlob;

        public ConnectToBlob()
        {
            storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            blobClient = storageAccount.CreateCloudBlobClient();
            blobContainer = blobClient.GetContainerReference("mycontainer2");
            blobContainer.CreateIfNotExists();
            ////blobContainer.SetPermissions(new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob }); //// For public access
            blockBlob = blobContainer.GetBlockBlobReference("myblockblob1");
        }

        public Uri MyConnect()
        {
            Uri blobUri;

            if (uploadBlob)
            {
                using (var fileStream = File.OpenRead(@"C:\Users\rishikesh.jadhav\Desktop\Notes\SEPARATION_ABSCONDING_PRODUCT_V2.pdf"))
                {
                    blockBlob.UploadFromStream(fileStream);
                }
            }
            else
            {
                using (var fileStream = File.OpenWrite(@"C:\Users\rishikesh.jadhav\Desktop\Notes\FromBlob\SEPARATION_ABSCONDING_PRODUCT_V2.pdf"))
                {
                    blockBlob.DownloadToStream(fileStream);
                }
            }
            blobUri = blockBlob.Uri;

            if (listBlobs)
            {
                foreach (IListBlobItem item in blobContainer.ListBlobs(null, false))
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob currentBlob = (CloudBlockBlob)item;
                        Console.WriteLine("Block blob length {0}: {1}", currentBlob.Properties.Length, currentBlob.Uri);
                    }
                    else if (item.GetType() == typeof(CloudBlobDirectory))
                    {
                        CloudBlobDirectory currentDirectory = (CloudBlobDirectory)item;
                        Console.WriteLine("Directory: {0}", currentDirectory.Uri);
                    }
                }
            }

            return blobUri;
        }
    }
}
