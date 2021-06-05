using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace websitebackpack
{
    public partial class add_services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                //if page not login admin then login admin
                if (Session["Email_USER"] == null)
                {
                    Response.Redirect("~/index.aspx");
                }
            }
        }
        //get img up 
        private string getimg()
        {
            string folderPath = Server.MapPath("~/Images/");
            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists Create it.
                Directory.CreateDirectory(folderPath);
            }
            // Before attempting to save the file, verify
            // that the FileUpload control contains a file.
            string url = "";
            if (imgload.HasFile)
            {
                string savePath = folderPath + Path.GetFileName(imgload.FileName);
                imgload.SaveAs(savePath);
                url = "/Images/" + Path.GetFileName(Path.GetFileName(imgload.FileName));

            }
            return url;
        }
        //cheack 
        bool c = false;
        private void cheak(string img, string name, string note)
        {
            //declare dataservics
            dataservices dataservices = new dataservices();
            //query sql
            string sql = string.Format("select * from Services where NameServices = N'{0}'", name);
            DataTable tb = dataservices.getData(sql);
            //if img empty notification
            if (img == "")
            {
                Response.Write("<script>confirm('Img cannot be empty!')</script>");
            }
            //if img name notification
            else if (name == "")
            {
                Response.Write("<script>confirm('Name cannot be empty!')</script>");
            }
            //if img name duplicate notification
            else if (tb.Rows.Count > 0)
            {
                Response.Write("<script>confirm('This name already exists!')</script>");
            }
            //if satisfied then add
            else
            {
                c = true;
            }
        }
        protected void add_click(object sender, EventArgs e)
        {
            string img = getimg();
            string name = cname.Value;
            string note = Description.Value;
            //declare dataservics
            dataservices dataservices = new dataservices();
            //query sql insert
            string sql = string.Format("insert into Services(Img,NameServices,Note) Values(N'{0}',N'{1}',N'{2}')", img,name, note);
            //cheak 
            cheak(img, name, note);
            //if c == true insert db
            if (c == true)
            {
                dataservices.runquery(sql);
                Response.Write("<script>confirm('Add data successfully!')</script>");
            }


        }
    }
}