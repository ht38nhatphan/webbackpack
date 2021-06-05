using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace websitebackpack
{
    public partial class services_admin : System.Web.UI.Page
    {
        private dataservices dataservices;
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Page.ClientQueryString;
            
            if (a != "")
            {
                //if page not login admin with login admin
                if (Session["Email_USER"] == null)
                {
                    Response.Redirect("~/index.aspx");
                }
                else
                {
                    a = a.Substring(a.IndexOf("=") + 1);
                    int ac = Convert.ToInt32(a);
                    //delete
                    dataservices = new dataservices();
                    string sql = string.Format("delete from Services where ServicesID = {0}", ac);
                    dataservices.runquery(sql);
                    Response.Write("<script>confirm('Delete successfully!')</script>");
                    Response.Redirect("~/services-admin.aspx");
                }  
            }
            if (!Page.IsPostBack)
            {
                //if page not login admin with login admin
                if (Session["Email_USER"] == null)
                {
                    Response.Redirect("~/index.aspx");
                }
                add_services();
               
            }
            

        }
        private void add_services()
        {
            dataservices = new dataservices();
            string sql = "select * from Services";
            DataTable tb = dataservices.getData(sql);
            string s="";
            for(int i = 0; i < tb.Rows.Count; i++)
            {
                string img = tb.Rows[i]["Img"].ToString();
                string name = tb.Rows[i]["NameServices"].ToString();
                string note = tb.Rows[i]["Note"].ToString();
                int id = Convert.ToInt32( tb.Rows[i]["ServicesID"].ToString());
                s += string.Format("<div class='card'><img class='card-image' src='{0}' alt='alternative'><div class='card-body'><h4 class='card-title'>{1}</h4><p>{2}</p></div><div class='button-wrapper'><a class='btn-solid-reg page-scroll' href='edit-services.aspx?idservices={3}' onclick='edit_click(this.id)'>Edit</a>&nbsp&nbsp<a class='btn-solid-reg page-scroll' href='services-admin.aspx?idservices={3}' onclick = 'delete_click(this.id)'>Delete</a></div></div>", img, name, note, id);

            }
            servicesadd.Text += s;
        }
        protected void add_click(object sender, EventArgs e)
        {
            Response.Redirect("~/add-services.aspx");
        }
    }
}