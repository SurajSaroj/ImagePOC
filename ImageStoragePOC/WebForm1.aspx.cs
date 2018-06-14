using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace ImageStoragePOC
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string Container = ConfigurationManager.AppSettings["storage:account:ProcessedFilesContainer"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string path = Path.GetFullPath(FileUpload1.FileName); ;
            // string path =  TextBox1.Text; //@"C:\Users\omkar\Desktop\New folder\14.jpg";
            //  StreamReader st = new StreamReader(.FileContent);
            Stream fileStream = FileUpload1.FileContent;
            string jobid = TextBox2.Text;
            string imageid = TextBox3.Text;
            
            CloudBlobContainer container = Program.BlobUtilities.GetBlobClient.GetContainerReference(Container);// container named processedfiles
            container.CreateIfNotExists();
            CloudBlockBlob blockblob;
            BlobWrapper b = new BlobWrapper();
            //try
            //{
                blockblob = b.UploadFileToBlob(fileStream, jobid, imageid);

                string sas1 = b.GetBlobSasUri(blockblob);
                string sas2 = b.GetBlobSasUri2(blockblob);

                Label1.Text = "EXPIRES IN ONE DAY : ";// + sas1;

                HyperLink1.Text = sas1;
                HyperLink1.NavigateUrl = sas1;

                Label2.Text = "NOT EXPIRES : ";// +sas2;
                HyperLink2.Text = sas2;
                HyperLink2.NavigateUrl = sas2;
            //}
            //catch (Exception e1)
            //{
            //    Label1.Text = e1.Message;
            //}
        }
    }
}