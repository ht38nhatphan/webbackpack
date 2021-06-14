using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace websitebackpack
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //check submit addmin
        private bool check(int iduser)
        {
           
            if (iduser==1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        protected void sumit1_click(object sender, EventArgs e)
        {
            Label1.Text = "";
            string n = email.Value.ToString();
            string p = pass.Value.ToString();
            p = md5.GetMD5(p);
            dataservices mydataservices = new dataservices();
            string sql = string.Format("select * from Users where Email = N'{0}' and Password = N'{1}'", n, p);
            DataTable tb = mydataservices.getData(sql);
            //id category user
            int id = 0;
            if (tb.Rows.Count > 0)
            {
                id = Convert.ToInt32(tb.Rows[0]["UserCategoryID"].ToString());
            }
            
            if (check(id) == true&& tb.Rows.Count > 0)
            {
                
                Session["ID_USER"] = tb.Rows[0]["UserID"];
                Session["Email_USER"] = tb.Rows[0]["Email"].ToString();
                Session["Password_USER"] = tb.Rows[0]["Password"].ToString();
                Response.Redirect("~/index.aspx");
            }
            if (tb.Rows.Count > 0)
            {
                if (tb.Rows.Count == 1)
                {
                    Session["ID"] = tb.Rows[0]["UserID"];
                    Session["Email"] = tb.Rows[0]["Email"].ToString();
                    Session["Password"] = tb.Rows[0]["Password"].ToString();
                    Response.Redirect("~/index.aspx");
                }

            }
            else
            {
                Label1.Text = "The Email or Password were incorrect.";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        //cheak 
        bool cheackrepeat(string name)
        {
            string sql = string.Format("select * from Users where Email = N'{0}'", name);
            dataservices dataservices = new dataservices();
            DataTable dt = dataservices.getData(sql);
            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //signin
        protected void sumit2_click(object sender, EventArgs e)
        {

            Label1.Text = "";
            string n = cname.Value.ToString();
            string em = cemail.Value.ToString();
            string p = cpass.Value.ToString();
            if (cheackrepeat(n) == false)
            {
                Label1.Text = "Name already exists";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (n == "")
            {
                Label1.Text = "Name cannot be left blank";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (em == "")
            {
                Label1.Text = "Email cannot be left blank";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (p == "")
            {
                Label1.Text = "Password cannot be left blank";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (cterms.Checked == false)
            {
                Label1.Text = "You have not agreed to the conditions";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (cheackrepeat(n) && n != "" && em != "" && p != "" && cterms.Checked == true)
            {
                p = md5.GetMD5(p);
                dataservices dataservices = new dataservices();
                string insert = string.Format("insert into Users(Email,UserName,Password,UserCategoryID) values(N'{0}',N'{1}',N'{2}',2)", em, n, p);
                dataservices.runquery(insert);
                if (Label1.Text == "")
                {
                    Label1.Text = "Sign Up Success!";
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Font.Bold = true;
                }
                email.Value = n;
                //set control
                cname.Value = null;
                cemail.Value = null;
                cpass.Value = null;
                cterms.Checked = false;
            }

        }
    }
}