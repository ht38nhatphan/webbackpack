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
    public partial class edit_product : System.Web.UI.Page
    {
        private dataservices dataservices;
        string im, name, price, note;
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
                string sql = string.Format("select * from Products where ProductID = {0}", c);
                DataTable tb = dataservices.getData(sql);
                //get data
                
                name = tb.Rows[0]["ProductName"].ToString();
                Session["beginname"] = name;
                price = tb.Rows[0]["Price"].ToString();
                im = tb.Rows[0]["Image"].ToString();
                note = tb.Rows[0]["Description"].ToString();
                //set data on text

                cname.Value = name;
                number.Value = price;
                Description.Value = note;
                vas.ImageUrl = im;
                Label2.Text = string.Format("<h1>{0}</h1><p>{1}</p>", tb.Rows[0]["ProductName"], tb.Rows[0]["Description"].ToString());
                Label3.Text = string.Format("<span class='value'>{0}</span>", tb.Rows[0]["Price"].ToString());

            }
        }

        //cheack
        
        bool c = false;
        private void cheak(string img1, string name1, string number1, string note1)
        {
            dataservices = new dataservices();
            string sql = string.Format("select * from Products where ProductName = N'{0}'", name1);
            DataTable tb = dataservices.getData(sql);
            if (img1 == "")
            {
                Response.Write("<script>confirm('Img cannot be empty!')</script>");
            }
            else if (name1 == "")
            {
                Response.Write("<script>confirm('Name cannot be empty!')</script>");
            }
            else if (number1 == "")
            {
                Response.Write("<script>confirm('Price cannot be empty!')</script>");
            }
            else if (tb.Rows.Count > 0&& Session["beginname"].ToString() != name1)
            {
                Response.Write("<script>confirm('This name already exists!')</script>");
            }
            //if satisfied with add
            else
            {
                c = true;
            }
        }
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
        protected void clickshow(object sender, EventArgs e)
        {
            if(Label1.Visible == true)
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
            dataservices = new dataservices();
            string a = Page.ClientQueryString;
            //neu khoong co du lieu khong cat
            if (a != "")
            {
                a = a.Substring(a.IndexOf("=") + 1);
            }
            
            int ck = Convert.ToInt32(a);
            
            string sql1 = string.Format("select * from Products where ProductID = {0}", ck);
            DataTable tb = dataservices.getData(sql1);
            string img1 = tb.Rows[0]["Image"].ToString();
            if (img1 == "")
            {
                img1 = getimg();
            }

            string name1 = cname.Value;
            string numbera1 = number.Value;
            string note1 = Description.Value;

           
            string sql = string.Format("update Products set ProductName = N'{0}',Price={1},Image=N'{2}',Description=N'{3}' where ProductID = {4}", name1, numbera1, img1, note1,ck);
            cheak(img1, name1, numbera1, note1);
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