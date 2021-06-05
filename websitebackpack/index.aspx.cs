using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace websitebackpack
{
    public partial class index : System.Web.UI.Page
    {
        private dataservices dataservices;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                add_sevices();
                showbackpack();
                
            }
                // lay id khi click
            string a = Page.ClientQueryString;
            //neu khoong co du lieu khong cat
            if (a != "")
            {
                a = a.Substring(a.IndexOf("=") + 1);
            }
            //neu co du lieu them
            if (a != "")
            {
                //if is admin then show 
                if (Session["Email_USER"] != null)
                {
                    Response.Write("<script>confirm('This function is only for customers!')</script>");
                }
                //chưa đăng nhập 
                else if (Session["Email"] == null)
                {
                    Session["IDindex"] = null;
                    Response.Redirect("~/login.aspx");

                }
                else if (Session["Email"] != null && a!="")
                {
                    //cheak dơn hàng nếu có thêm mới không thì update sản phẩm
                    addorder();
                    string b = DateTime.Now.ToString();
                    b = b.Substring(0, b.IndexOf(" "));
                    int id = getidorder();
                    int ca = Convert.ToInt32(a);
                    //giá trị mới thêm
                    if (cheackpro()==false)
                    {
                        dataservices = new dataservices();
                        string sql = string.Format("insert into OrderDetails(OrderID,ProductID,Quantity) values ({0},{1},{2})", id, ca, 1);
                        dataservices.runquery(sql);
                        
                    }
                    //đã có dữ liei trong pro và đơn hàng
                    else if (cheackpro() == true)
                    {
                        updatequatyti();
                    }
                    
                }
                


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
            string sql = string.Format("update OrderDetails set Quantity = Quantity + {0} where OrderID = {1} and ProductID = {2}", 1, cheakinsert(a),b);
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
        //check
        public bool check(string n, string em, string m)
        {
            if (m != "" && n != "" && em != "" && cterms.Checked == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected void Feedback_click(object sender, EventArgs e)
        {
            string n = cname.Value.ToString();
            string em = cemail.Value.ToString();
            string m = cmessage.Value.ToString();
            if (check(n, em, m) == false)
            {
                dataservices = new dataservices();
                string sql = string.Format("insert into Feedback(Note,Name,Email) values (N'{0}',N'{1}',N'{2}')", m, n, em);
                dataservices.runquery(sql);
                Response.Write("<script>alert('Successful response')</script>");
                cname.Value = "";
                cemail.Value = "";
                cmessage.Value = "";

            }

        }
        private void add_sevices()
        {
            dataservices = new dataservices();
            string sql = "select * from Services";
            DataTable tb = dataservices.getData(sql);
            for(int i = 0; i < tb.Rows.Count; i++)
            {
                string n = tb.Rows[i]["NameServices"].ToString();
                string img = tb.Rows[i]["Img"].ToString();
                string note = tb.Rows[i]["Note"].ToString();
                string s = string.Format("<div class='card'><img class='card-image' src='{0}' alt='alternative'><div class='card-body'><h4 class='card-title'>{1}</h4><p>{2}</p></div></div>", img, n, note);
                add_services.InnerHtml += s;

            }
        }
        //show data
        private void showbackpack()
        {
            dataservices = new dataservices();
            DataTable tb = dataservices.getData("select top 6 * from maxc a join Products b on a.ProductID = b.ProductID order by sum desc");
            //adđ
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string name = tb.Rows[i]["ProductName"].ToString();
                string price = tb.Rows[i]["Price"].ToString();
                string image = tb.Rows[i]["Image"].ToString();
                //get data
                string id = tb.Rows[i]["ProductID"].ToString();
                //check admin 
                string c = "product_detail.aspx?idbuy=";
                if (Session["Email_USER"] != null){
                    c = "edit-product.aspx?idbuy=";
                }
                show.InnerHtml += string.Format("<div class='card'> <div class='label'> <p class='best-value'>Best Sellers</p></div><div class='card-body'><a class='product-image'  href='{4}{3}'  onclick='showdetail(this.id)'><img src = '{0}' alt='alternative'></a><div class='card-title'>{1}</div><hr class='cell-divide-hr'><div class='price'><span class='currency'>$</span><span class='value'>{2}</span> </div><hr class='cell-divide-hr'><div class='button-wrapper'><a class='btn-solid-reg page-scroll' href='index.aspx?id={3}' onclick ='call_click' id={3}>ADD TO CART</a></div></div></div>", image, name, price,id,c);

            }
            

        }
       //onclick user
        protected void userclick(object sender, EventArgs e)
        {
            //NEU CHUA DĂNG NHẬP THI PHẢI ĐĂNG NHẬP 
            if(Session["Email"] == null && Session["Email_USER"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else if (Session["Email_USER"]!=null)
            {
                Response.Redirect("~/user-admin.aspx");
            }
            else
            {
                Response.Redirect("~/user.aspx");
            }
        }
        //onclick shop
        protected void shopclick(object sender, EventArgs e)
        {
            //NEU CHUA DĂNG NHẬP THI PHẢI ĐĂNG NHẬP 
            if (Session["Email"] == null && Session["Email_USER"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else if (Session["Email_USER"] != null)
            {
                Response.Redirect("~/shop-admin.aspx");
            }
            else
            {
                Response.Redirect("~/shop.aspx");
            }
        }
        protected void showall_click(object sender, EventArgs e)
        {
            if(Session["Email_USER"] != null)
            {
                Response.Redirect("~/product-admin.aspx");
            }
            else
            {
                Response.Redirect("~/product.aspx");
            }
        }


    }
}