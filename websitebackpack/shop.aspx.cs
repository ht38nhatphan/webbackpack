using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace websitebackpack
{
    
    public partial class shop : System.Web.UI.Page
    {
        private dataservices dataservices;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Email"] != null)
                {
                    addimg();
                    product();


                }
            }
            //lay id khi click
            string a = Page.ClientQueryString;
            //neu khoong co du lieu khong cat
            if (a != "")
            {
                a = a.Substring(a.IndexOf("=") + 1);
            }
            //neu khoong co du lieu khong xoa
            if (Session["Name"] != null && a!="")
            {
                int ca = Convert.ToInt32(a);
                dataservices = new dataservices();
                string sql = string.Format("Delete from OrderDetails where DetailID ={0}", ca);
                dataservices.runquery(sql);
                Response.Redirect("~/shop.aspx");
            }
            if (Session["Email"] == null)
            {
                Response.Redirect("~/login.aspx");
            }

        }
        //show img
        private void addimg()
        {
            dataservices = new dataservices();
            //select in order
            string sql = string.Format("select c.Image from Orders a join OrderDetails b on a.OrdersID = b.OrderID join Products c on c.ProductID = b.ProductID join Users d on d.UserID = a.UserID where d.Email =N'{0}'", Session["Email"].ToString());
            DataTable tb = dataservices.getData(sql);
            string s = "<div class='text-container1'>";
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string em = tb.Rows[i]["Image"].ToString();
                s += string.Format("<br><div class='card'> <div class='card-body'><img class='shop-image' src='{0}' alt='alternative'></div></div><br>", em);

            }
            s += "</div>";
            add_img.InnerHtml += s;

            //JavaScriptSerializer ser = new JavaScriptSerializer();

        }



        public string c;

        private void product()
        {
            dataservices = new dataservices();
            //select in order
            string sql = string.Format("select DetailID, c.ProductID, c.ProductName,c.Price,b.Quantity from Orders a join OrderDetails b on a.OrdersID = b.OrderID join Products c on c.ProductID = b.ProductID join Users d on d.UserID = a.UserID where d.Email =N'{0}'", Session["Email"].ToString());
            DataTable tb = dataservices.getData(sql);
            string s = "<div class='text-container1'>";

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string name = tb.Rows[i]["ProductName"].ToString();
                string price = tb.Rows[i]["Price"].ToString();
                int qut = Convert.ToInt32 (tb.Rows[i]["Quantity"]);
                int id = Convert.ToInt32(tb.Rows[i]["DetailID"]);
                s += string.Format("<div class='card-title1'>{0}</div><div class='price'><span class='currency'>$</span><span class='value'>{1}</span></div> <br><div class='form-group'><input type = 'number' id='number1' required aria-label='quantity' max='' min='1' step='1' value='{2}' pattern='[0-9]*'></div> <a href = 'shop.aspx?id={3}' ID ={3} = '_parent' onclick =reply_click(this.id) > Remove </a> <br>", name, price,qut, id);

            }
            s += "</div>";
            add_product.Visible = true;
            add_product.InnerHtml += s;



        }
        protected void c_click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Successful')</script>");
        }
    }

}