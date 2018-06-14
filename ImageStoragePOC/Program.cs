using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageStoragePOC
{
    class ProgramFile
    {
        public string FileName { get; set; }
    }

    public class Program
    {
        internal class BlobUtilities
        {
            public static CloudBlobClient GetBlobClient
            {
                get
                {
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=storagepoc12;AccountKey=HGVDkNe/XsMN6Gg4wRfABbrsy+mua4hX90aGNUwZom0PoHRzolqv55CeBevAOU3SJ5UCwdc2XJ46jm3HUBPFBA==;EndpointSuffix=core.windows.net");
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    return blobClient;
                }
            }

        }
    }
}