using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace ImageStoragePOC
{
    class BlobWrapper
    {
        private string Container = ConfigurationManager.AppSettings["storage:account:ProcessedFilesContainer"];
        
         public CloudBlockBlob UploadFileToBlob(Stream image_path, string jobid, string imageid) 
        {
            // Get Blob Container
            CloudBlobContainer container = Program.BlobUtilities.GetBlobClient.GetContainerReference(Container);// container 
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            CloudBlobDirectory directory = container.GetDirectoryReference((DateTime.Now.Year).ToString()+"/"+ DateTime.Now.ToString("MMMM")+"/"+jobid);
            // Get reference to blob (binary content)
            CloudBlockBlob blockBlob_image = directory.GetBlockBlobReference(imageid);
            blockBlob_image.Metadata["filename"] = imageid;        


            //try //image file upload
           // {
             ////   using (var filestream = image_path)
             //   {
                    blockBlob_image.UploadFromStream(image_path);
             //   }
            //}
            //catch (Exception e)
            //{
            //    //return false;
            //}
             
            var accountName = ConfigurationManager.AppSettings["storage:account:name"];
            var accountKey = ConfigurationManager.AppSettings["storage:account:key"];
            var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), false);

           // GetBlobSasUri(blockBlob_image);
           // GetBlobSasUri2(blockBlob_image);
            ////Create Blobs
            //CloudBlobClient blobClient_image = storageAccount.CreateCloudBlobClient();
            //CloudBlobContainer imagesContainer = blobClient_image.GetContainerReference(Container);


             return blockBlob_image;
        }

        public string GetBlobSasUri(CloudBlockBlob path)
        {
             //string filename = Path.GetFileName(path);
            //Get a reference to a blob within the container.
            //  CloudBlockBlob blob = container.GetBlockBlobReference();
             
              //Upload text to the blob. If the blob does not yet exist, it will be created.
              //If the blob does exist, its existing content will be overwritten.
              //string blobContent = "This blob will be accessible to clients via a shared access signature (SAS).";
              // blob.UploadText(blobContent);
              
              //Set the expiry time and permissions for the blob.
              //In this case, the start time is specified as a few minutes in the past, to mitigate clock skew.
              //The shared access signature will be valid immediately.
              SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5);
            sasConstraints.SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(24);
            sasConstraints.Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write;

            //Generate the shared access signature on the blob, setting the constraints directly on the signature.
            string sasBlobToken = path.GetSharedAccessSignature(sasConstraints);
            string sas = path.Uri + sasBlobToken;
            //Return the URI string for the container, including the SAS token.
            return sas;
        }

        public string GetBlobSasUri2(CloudBlockBlob path)
        {
            //string filename = Path.GetFileName(path);
            //Get a reference to a blob within the container.
            //  CloudBlockBlob blob = container.GetBlockBlobReference();

            //Upload text to the blob. If the blob does not yet exist, it will be created.
            //If the blob does exist, its existing content will be overwritten.
            //string blobContent = "This blob will be accessible to clients via a shared access signature (SAS).";
            // blob.UploadText(blobContent);

            //Set the expiry time and permissions for the blob.
            //In this case, the start time is specified as a few minutes in the past, to mitigate clock skew.
            //The shared access signature will be valid immediately.
            SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5);
            sasConstraints.SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddYears(10);
            sasConstraints.Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write;

            //Generate the shared access signature on the blob, setting the constraints directly on the signature.
            string sasBlobToken = path.GetSharedAccessSignature(sasConstraints);
            string sas = path.Uri + sasBlobToken;
            //Return the URI string for the container, including the SAS token.
            return sas;
        }

        //public string GetBlobSasUri2(CloudBlobContainer container, String path)
        //{
        //    string filename = Path.GetFileName(path);
        //    //Get a reference to a blob within the container.
        //    CloudBlockBlob blob = container.GetBlockBlobReference(filename);

        //    //Upload text to the blob. If the blob does not yet exist, it will be created.
        //    //If the blob does exist, its existing content will be overwritten.
        //    string blobContent = "This blob will be accessible to clients via a shared access signature (SAS).";
        //    blob.UploadText(blobContent);

        //    //Set the expiry time and permissions for the blob.
        //    //In this case, the start time is specified as a few minutes in the past, to mitigate clock skew.
        //    //The shared access signature will be valid immediately.
        //    SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
        //    sasConstraints.SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5);
        //    sasConstraints.SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddYears(10);
        //    sasConstraints.Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write;

        //    //Generate the shared access signature on the blob, setting the constraints directly on the signature.
        //    string sasBlobToken = blob.GetSharedAccessSignature(sasConstraints);

        //    //Return the URI string for the container, including the SAS token.
        //    return blob.Uri + sasBlobToken;
        //}
    }
}