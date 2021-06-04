using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace websitebackpack
{
    public partial class product_detail : System.Web.UI.Page
    {
        private dataservices dataservices;
        protected void Page_Load(object sender, EventArgs e)
        {
            //lay id khi click lấy id
            string a = Page.ClientQueryString;
            //neu khoong co du lieu khong cat
            if (a != "")
            {
                a = a.Substring(a.IndexOf("=") + 1);
            }
            int c = Convert.ToInt32(a);
            add_price(c);
        }

        private void add_price(int id)
        {

            dataservices = new dataservices();
            string sql = string.Format("select * from Products where ProductID = {0}", id);
            DataTable tb = dataservices.getData(sql);
            Label3.Text = string.Format("<img class='img-product-detail' src='{0}'  alt=''>",tb.Rows[0]["Image"].ToString());
            Label2.Text = string.Format("<h1>{0}</h1><p>{1}</p>",tb.Rows[0]["ProductName"], tb.Rows[0]["Description"].ToString());
            Label1.Text = string.Format("<span class='value'>{0}</span>", tb.Rows[0]["Price"].ToString());
        }
        protected void add_click(object sender, EventArgs e)
        {
            //chưa đăng nhập 
            if (Session["Email"] == null)
            {
                Response.Redirect("~/login.aspx");
            }

            else
            {
                //lay id khi click lấy id
                string a = Page.ClientQueryString;
                //neu khoong co du lieu khong cat
                if (a != "")
                {
                    a = a.Substring(a.IndexOf("=") + 1);
                }
                //cheak dơn hàng nếu có thêm mới không thì update sản phẩm
                addorder();
                string b = DateTime.Now.ToString();
                b = b.Substring(0, b.IndexOf(" "));
                int id1 = getidorder();
                int ca = Convert.ToInt32(a);
                //giá trị mới thêm
                if (cheackpro() == false)
                {
                    dataservices = new dataservices();
                    string sql = string.Format("insert into OrderDetails(OrderID,ProductID,Quantity) values ({0},{1},{2})", id1, ca, 1);
                    dataservices.runquery(sql);
                    
                }
                //đã có dữ liei trong pro và đơn hàng
                if (cheackpro() == true)
                {
                    updatequatyti();
                }
                Response.Write("<script>alert('Successful Order')</script>");
            }
        }
        //add order
        private void addorder()
        {

            string a = DateTime.Now.ToString();
            a = a.Substring(0, a.IndexOf(" "));
            if (cheakinsert(a) == 0)
            {
                dataservices = new dataservices();
                string sql = string.Format("insert into Orders(UserID,StatusID,OrderDate) values({0},{1},N'{2}')", Convert.ToInt32(Session["ID"]), 1, a);
                dataservices.runquery(sql);
            }


        }
        //cheak idproduct
        public bool cheackpro()
        {
            string b = Page.ClientQueryString;
            //neu khoong co du lieu khong cat
            b = b.Substring(b.IndexOf("=") + 1);
            dataservices = new dataservices();
            string sql = string.Format("select * from OrderDetails where ProductID = {0} and OrderID = {1}", b, getidorder());
            DataTable tb = dataservices.getData(sql);
            //đã có dữ liệu rồi
            if (tb.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //check insert 
        public int cheakinsert(string x)
        {
            dataservices = new dataservices();
            string sql = string.Format("select * from Orders where OrderDate = N'{0}' and UserID = {1}", x, Convert.ToInt32(Session["ID"]));
            DataTable tb = dataservices.getData(sql);
            if (tb.Rows.Count > 0)
            {
                return Convert.ToInt32(tb.Rows[0]["OrdersID"].ToString());
            }
            else
            {
                return 0;
            }
        }

        //up date order
        private void updatequatyti()
        {
            string b = Page.ClientQueryString;
            //neu khoong co du lieu khong cat

            b = b.Substring(b.IndexOf("=") + 1);
            string a = DateTime.Now.ToString();
            a = a.Substring(0, a.IndexOf(" "));
            dataservices = new dataservices();
            string sql = string.Format("update OrderDetails set Quantity = Quantity + {0} where OrderID = {1} and ProductID = {2}", 1, cheakinsert(a), b);
            dataservices.runquery(sql);
        }
        //get id order
        private int getidorder()
        {
            dataservices = new dataservices();
            //get data new
            string sql = "select MAX(OrdersID) as orderid from Orders";
            DataTable tb = dataservices.getData(sql);
            return Convert.ToInt32(tb.Rows[0]["orderid"]);
        }
    }
}