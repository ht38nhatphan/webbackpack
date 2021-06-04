using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace websitebackpack
{
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Email"] != null)
                {
                    show();
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }
        //show customer
        private void show()
        {
            string em = Session["Email"].ToString();
            string s = string.Format("<div class='text-container'><p>Hello<span class='h6'> {0} </span></p><p>Welcome to Backpack Store. Enjoy shopping!</p></div>", em);
            useremail.InnerHtml += s;

        }
        //logout clear data
        protected void logout_click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Session["ID"] = null;
            Session["Password"] = null;
            Response.Redirect("~/login.aspx");
        }
    }
}