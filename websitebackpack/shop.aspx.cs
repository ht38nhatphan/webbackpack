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
            string a = Page.ClientQueryString;
            if (!Page.IsPostBack)
            {
                if (Session["Email"] != null)
                {
                    product();
                }
            }
            //lay id khi click
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
       




        private void product()
        {
            dataservices = new dataservices();
            //select in order
            string sql = string.Format("select DetailID, c.Image, c.ProductID, c.ProductName,c.Price,b.Quantity from Orders a join OrderDetails b on a.OrdersID = b.OrderID join Products c on c.ProductID = b.ProductID join Users d on d.UserID = a.UserID where d.Email =N'{0}'", Session["Email"].ToString());
            DataTable tb = dataservices.getData(sql);

            string s = "";
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                s = "<div class='text-container1'>";
                string em = tb.Rows[i]["Image"].ToString();
                string name = tb.Rows[i]["ProductName"].ToString();
                string price = tb.Rows[i]["Price"].ToString();
                int qut = Convert.ToInt32 (tb.Rows[i]["Quantity"]);
                int id = Convert.ToInt32(tb.Rows[i]["DetailID"]);
                s += string.Format("<div class='card'><div class='card-body'><input type='checkbox' name = 'check' value = '{4}'><img class='shop-image' src='{0}' alt='alternative'><div><h6>{1}</h6><span class='currency'>$</span><span class='value'>{2}</span><div class='form-group'><input type='number' id='number1' aria-label='quantity' max='' min='1' step='1' value='{3}' pattern='[0-9]*'></div><a href='shop.aspx?idshop={4}' onclick='delete_click(this.id)'>Remove</a></div></div></div></div>", em,name,price,qut,id);
                if (i % 2 == 0)
                {
                    Label1.Text += s;
                    s = "";
                }
                else
                {
                    Label2.Text += s;
                    s = "";
                }

            }
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dataservices = new dataservices();
            //get data in cheak box
            string selected = Request.Form["check"];
            HashSet<int> b = splitstring(selected);
            int sum = 0;
            foreach(int i in b)
            {

                string sql = string.Format("select c.ProductID, b.Quantity,c.Price from Orders a join OrderDetails b on a.OrdersID = b.OrderID join Products c on c.ProductID = b.ProductID join Users d on d.UserID = a.UserID where DetailID ={0}", i);
                DataTable tb = dataservices.getData(sql);
                //get data
                int idpr = Convert.ToInt32(tb.Rows[0]["ProductID"].ToString());
                int price = Convert.ToInt32 (tb.Rows[0]["Price"].ToString());
                int qut = Convert.ToInt32(tb.Rows[0]["Quantity"]);
                string a = DateTime.Now.ToString();
                a = a.Substring(0, a.IndexOf(" "));
                //set card
                string sql1 = string.Format("insert into Card(ProductID,Quantity,Date,Sum) values({0},{1},N'{2}',{3}) ", idpr, qut, a, price * qut);
                //save sumall
                sum += price * qut;
                dataservices.runquery(sql1);
                string sql2 = string.Format("Delete from OrderDetails where DetailID ={0}", i);
                dataservices.runquery(sql2);
               
                

            }
            Response.Write(string.Format("<script>confirm('The total amount you have to pay is: {0}$')</script>", sum));
            //Response.Redirect("~/shop.aspx");
        }
        //set data in hashset
        private HashSet<int> splitstring(string s)
        {
            HashSet<int> a = new HashSet<int>();
            string g = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ',')
                {
                    g += s[i];
                    //get value last
                    if (i == s.Length - 1)
                    {
                        a.Add(Convert.ToInt32(g));
                    }
                }
                else if (s[i] == ',')
                {
                    a.Add(Convert.ToInt32(g));
                    g = "";
                }
                
            }
            return a;
        }
    }

}