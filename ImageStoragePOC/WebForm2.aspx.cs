using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageStoragePOC
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = Path.GetFullPath(FileUpload1.FileName);
            Label2.Text += Server.MapPath(FileUpload1.FileName);

            string a = "http://www.google.com";
            HyperLink link = new HyperLink();
            link.Text = a;
            link.NavigateUrl = a;
            form1.Controls.Add(link);
        }
    }
}