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
    public partial class edit_services : System.Web.UI.Page
    {
        private dataservices dataservices;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                //lay id khi click lấy id
                string a = Page.ClientQueryString;
                //neu khoong co du lieu khong cat
                if (a != "")
                {
                    a = a.Substring(a.IndexOf("=") + 1);
                }
                int c = Convert.ToInt32(a);
                dataservices = new dataservices();
                string sql = string.Format("select * from Services where ServicesID = {0}", c);
                DataTable tb = dataservices.getData(sql);
                //get data

                string name = tb.Rows[0]["NameServices"].ToString();
                Session["namesericses"] = name;
                string im = tb.Rows[0]["Img"].ToString();
                string note = tb.Rows[0]["Note"].ToString();
                //set data on text

                cname.Value = name;
                Description.Value = note;
                vas.ImageUrl = im;

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
            else if (tb.Rows.Count > 0 && Session["namesericses"].ToString() != name)
            {
                Response.Write("<script>confirm('This name already exists!')</script>");
            }
            //if satisfied then add
            else
            {
                c = true;
            }
        }
        protected void edit_click(object sender, EventArgs e)
        {
            if (Label1.Visible == true)
            {
                Label1.Visible = false;

            }
            else
            {
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
        }
        protected void save_click(object sender, EventArgs e)
        {
            string a = Page.ClientQueryString;
            //neu khoong co du lieu khong cat
            if (a != "")
            {
                a = a.Substring(a.IndexOf("=") + 1);
            }
            int ck = Convert.ToInt32(a);
            string img1 = getimg();
            string name1 = cname.Value;
            string note1 = Description.Value;

            dataservices = new dataservices();
            string sql = string.Format("update Services set NameServices = N'{0}',Img=N'{1}',Note=N'{2}' where ServicesID = {3}", name1, img1, note1, ck);
            cheak(img1, name1, note1);
            if (c == true)
            {
                dataservices.runquery(sql);
                Response.Write("<script>confirm('Add data successfully!')</script>");
                //load page
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
        }
    }
}