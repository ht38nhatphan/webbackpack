using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace websitebackpack
{
    
    public partial class product : System.Web.UI.Page
    {
        
        private dataservices dataservices;
        //biến show
        public string s, img, n, price;
        public int id;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //lay id khi click lấy id
            string a = Page.ClientQueryString;
            //neu khoong co du lieu khong cat
            string c = "";
            if (a != "")
            {
                c = a.Substring(0, a.IndexOf("="));
                a = a.Substring(a.IndexOf("=") + 1);
                
            }
            if (!Page.IsPostBack)
            {

                addcategory();
                if(a=="")
                {
                    show_all();
                }
                //click show all
                if(a!="")
                {
                    show_all1();
                    
                }
               
              
            }
           
           
            //neu search category
            if (a!=""&&a!="ab"&&c=="idcaregory")
            {
                int ca = Convert.ToInt32(a);
                //click show all
                show_category1(ca);
            }
            
            if (a != "" && a != "ab" && c != "idcaregory" )
            {
                //chưa đăng nhập 
                if (Session["Email"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
               
                else
                {
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
                        Response.Write("<script>alert('Successful Order')</script>");
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

        protected void myListDropDown_Change(object sender, EventArgs e)
        {
           string a = DropDownList1.Text;
           if(a == "popularity")
            {
                sort_max1();
            }
           else if(a== "date")
           {
                sort_new1();

            }
            else if (a == "price")
            {
                sort_min_max1();
            }
            else if (a == "price-desc")
            {
                sort_max_min1();

            }
            else
            {
                sort_aipha1();

            }



        }


        string s1, s2, s3, s4, s5, s6;                
        //show all
        public void show_all()
        {
            showall.Text = "";
            dataservices = new dataservices();
            string sql = "select top 6 * from Products";
            DataTable tb = dataservices.getData(sql);
            for(int i = 0; i < tb.Rows.Count; i++)
            {
                img = tb.Rows[i]["Image"].ToString();
                n = tb.Rows[i]["ProductName"].ToString();
                price = tb.Rows[i]["Price"].ToString();
                id =Convert.ToInt32( tb.Rows[i]["ProductID"].ToString());
                s += string.Format("<div class='card'>  <div class='card-body'><a class='product-image' href='product_detail.aspx?idbuy={3}'  onclick='showdetail(this.id)'><img src = {0} alt='alternative'></a><div class='card-title'>{1}</div><hr class='cell-divide-hr'><div class='price'> <span class='currency'>$</span><span class='value'>{2}</span>" +
               "</div><hr class='cell-divide-hr'><div class='button-wrapper'><a class='btn-solid-reg page-scroll' href='product.aspx?id={3}' onclick='buy(this.id)'>ADD TO CART</a></div></div></div>", img, n, price,id);
            }
            
            s += "<div class='button-wrapper'id='dummy'><a class='btn-solid-reg page-scroll' onclick='removeDummy()' id='show_add'  href='product.aspx?id=ab'>SEE MORE</a></div>"; 
            showall.Text += s;
           
        }
        
        //add category
        private void addcategory()
        {
            
            dataservices = new dataservices();
            string sql = "select * from Categories";
            DataTable tb = dataservices.getData(sql);
            string a = "";
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string n = tb.Rows[i]["CategoryName"].ToString();
                string id = tb.Rows[i]["CategoryID"].ToString();
                //save id categry
                Session["idcategory"] = id;
                a += string.Format("<hr class='cell-divide-hr'><li><a href = 'product.aspx?idcaregory={0}' id='{0}' Onclick = cheak_category(this.id) > {1}</a></li>", id, n);
                
            }
            add_category.InnerHtml = a;
        }
        //show in category
        private void show_category(int a)
        {
            showall.Text = "";
            dataservices = new dataservices();
            string sql = string.Format("select top 6 * from Products a where CategoryID = {0}",a);
            DataTable tb = dataservices.getData(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                img = tb.Rows[i]["Image"].ToString();
                n = tb.Rows[i]["ProductName"].ToString();
                price = tb.Rows[i]["Price"].ToString();
                id = Convert.ToInt32(tb.Rows[i]["ProductID"].ToString());
                s1 += string.Format("<div class='card'>  <div class='card-body'><a class='product-image' href='product_detail.aspx?idbuy={3}'  onclick='showdetail(this.id)'><img src = {0}  alt='alternative'></a><div class='card-title'>{1}</div><hr class='cell-divide-hr'><div class='price'> <span class='currency'>$</span><span class='value'>{2}</span>" +
               "</div><hr class='cell-divide-hr'><div class='button-wrapper'><a class='btn-solid-reg page-scroll' href='product.aspx?id={3}' onclick='buy(this.id)'>ADD TO CART</a></div></div></div>", img, n, price,id);
            }

            s += "<div class='button-wrapper'id='dummy'><a class='btn-solid-reg page-scroll' onclick='removeDummy()' id='show_add'  href='product.aspx?id=ab'>SEE MORE</a></div>";
            showall.Text += s1;
        }
        ////show add
        //protected void show_add(object sender, EventArgs e)
        //{

        //}

         
       
        /// showw allll
        /// 



        //show all
        public void show_all1()
        {
            showall.Text = "";
            dataservices = new dataservices();
            string sql = "select  * from Products";
            DataTable tb = dataservices.getData(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                img = tb.Rows[i]["Image"].ToString();
                n = tb.Rows[i]["ProductName"].ToString();
                price = tb.Rows[i]["Price"].ToString();
                id = Convert.ToInt32(tb.Rows[i]["ProductID"].ToString());
                s += string.Format("<div class='card'>  <div class='card-body'><a class='product-image' href='product_detail.aspx?idbuy={3}'  onclick='showdetail(this.id)'><img src = {0} alt='alternative'></a><div class='card-title'>{1}</div><hr class='cell-divide-hr'><div class='price'> <span class='currency'>$</span><span class='value'>{2}</span>" +
               "</div><hr class='cell-divide-hr'><div class='button-wrapper'><a class='btn-solid-reg page-scroll' href='product.aspx?id={3}' onclick='buy(this.id)'>ADD TO CART</a></div></div></div>", img, n, price,id);
            }

           
            showall.Text += s;

        }

 
        //show in category
        private void show_category1(int a)
        {
            showall.Text = "";
            dataservices = new dataservices();
            string sql = string.Format("select * from Products a where CategoryID = {0}", a);
            DataTable tb = dataservices.getData(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                img = tb.Rows[i]["Image"].ToString();
                n = tb.Rows[i]["ProductName"].ToString();
                price = tb.Rows[i]["Price"].ToString();
                id = Convert.ToInt32(tb.Rows[i]["ProductID"].ToString());
                s1+= string.Format("<div class='card'>  <div class='card-body'><a class='product-image' href='product_detail.aspx?idbuy={3}'  onclick='showdetail(this.id)'><img src = {0} alt='alternative'></a><div class='card-title'>{1}</div><hr class='cell-divide-hr'><div class='price'> <span class='currency'>$</span><span class='value'>{2}</span>" +
                "</div><hr class='cell-divide-hr'><div class='button-wrapper'><a class='btn-solid-reg page-scroll' href='product.aspx?id={3}' onclick='buy(this.id)'>ADD TO CART</a></div></div></div>", img, n, price, id);
            }

           
            showall.Text += s1;
        }
        ////show add
        //protected void show_add(object sender, EventArgs e)
        //{

        //}


        //sort max customer
        public void sort_max1()
        {
            showall.Text = "";
            dataservices = new dataservices();
            string sql = "select * from maxc a join Products b on a.ProductID = b.ProductID order by sum desc";
            DataTable tb = dataservices.getData(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                img = tb.Rows[i]["Image"].ToString();
                n = tb.Rows[i]["ProductName"].ToString();
                price = tb.Rows[i]["Price"].ToString();
                id = Convert.ToInt32(tb.Rows[i]["ProductID"].ToString());
                s2 += string.Format("<div class='card'>  <div class='card-body'><a class='product-image' href='product_detail.aspx?idbuy={3}'  onclick='showdetail(this.id)'><img src = {0} alt='alternative'></a><div class='card-title'>{1}</div><hr class='cell-divide-hr'><div class='price'> <span class='currency'>$</span><span class='value'>{2}</span>" +
               "</div><hr class='cell-divide-hr'><div class='button-wrapper'><a class='btn-solid-reg page-scroll' href='product.aspx?id={3}' onclick='buy(this.id)'>ADD TO CART</a></div></div></div>", img, n, price,id);
            }

          
            showall.Text += s2;
        }
        //sort_new
        public void sort_new1()
        {

            dataservices = new dataservices();
            string sql = "select  * from Products order by ProductID desc";
            DataTable tb = dataservices.getData(sql);
            showall.Text = "";
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                img = tb.Rows[i]["Image"].ToString();
                n = tb.Rows[i]["ProductName"].ToString();
                price = tb.Rows[i]["Price"].ToString();
                id = Convert.ToInt32(tb.Rows[i]["ProductID"].ToString());
                s3 += string.Format("<div class='card'>  <div class='card-body'><a class='product-image' href='product_detail.aspx?idbuy={3}'  onclick='showdetail(this.id)'><img src = {0}  alt='alternative'></a><div class='card-title'>{1}</div><hr class='cell-divide-hr'><div class='price'> <span class='currency'>$</span><span class='value'>{2}</span>" +
               "</div><hr class='cell-divide-hr'><div class='button-wrapper'><a class='btn-solid-reg page-scroll' href='product.aspx?id={3}' onclick='buy(this.id)'>ADD TO CART</a></div></div></div>", img, n, price,id);
            }

           
            showall.Text += s3;
        }
        //sort_min_max
        public void sort_min_max1()
        {
            showall.Text = "";
            dataservices = new dataservices();
            string sql = "select  * from Products order by Price asc";
            DataTable tb = dataservices.getData(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                img = tb.Rows[i]["Image"].ToString();
                n = tb.Rows[i]["ProductName"].ToString();
                price = tb.Rows[i]["Price"].ToString();
                id = Convert.ToInt32(tb.Rows[i]["ProductID"].ToString());
                s4 += string.Format("<div class='card'>  <div class='card-body'><a class='product-image' href='product_detail.aspx?idbuy={3}'  onclick='showdetail(this.id)'><img src = {0}  alt='alternative'></a><div class='card-title'>{1}</div><hr class='cell-divide-hr'><div class='price'> <span class='currency'>$</span><span class='value'>{2}</span>" +
               "</div><hr class='cell-divide-hr'><div class='button-wrapper'><a class='btn-solid-reg page-scroll' href='product.aspx?id={3}' onclick='buy(this.id)'>ADD TO CART</a></div></div></div>", img, n, price,id);
            }

           
            showall.Text += s4;
        }
        //sort_max_min
        public void sort_max_min1()
        {
            showall.Text = "";
            dataservices = new dataservices();
            string sql = "select   * from Products order by Price desc";
            DataTable tb = dataservices.getData(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                img = tb.Rows[i]["Image"].ToString();
                n = tb.Rows[i]["ProductName"].ToString();
                price = tb.Rows[i]["Price"].ToString();
                id = Convert.ToInt32(tb.Rows[i]["ProductID"].ToString());
                s5 += string.Format("<div class='card'>  <div class='card-body'><a class='product-image' href='product_detail.aspx?idbuy={3}'  onclick='showdetail(this.id)'><img src = {0}  alt='alternative'></a><div class='card-title'>{1}</div><hr class='cell-divide-hr'><div class='price'> <span class='currency'>$</span><span class='value'>{2}</span>" +
               "</div><hr class='cell-divide-hr'><div class='button-wrapper'><a class='btn-solid-reg page-scroll' href='product.aspx?id={3}' onclick='buy(this.id)'>ADD TO CART</a></div></div></div>", img, n, price,id);
            }

            
            showall.Text += s5;

        }
        //sort_aipha
        public void sort_aipha1()
        {
            showall.Text = "";
            dataservices = new dataservices();
            string sql = "select *from Products order by ProductName asc";
            DataTable tb = dataservices.getData(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                img = tb.Rows[i]["Image"].ToString();
                n = tb.Rows[i]["ProductName"].ToString();
                price = tb.Rows[i]["Price"].ToString();
                id = Convert.ToInt32(tb.Rows[i]["ProductID"].ToString());
                s6 += string.Format("<div class='card'>  <div class='card-body'><a class='product-image' href='product_detail.aspx?idbuy={3}'  onclick='showdetail(this.id)'><img src = {0}  alt='alternative'></a><div class='card-title'>{1}</div><hr class='cell-divide-hr'><div class='price'> <span class='currency'>$</span><span class='value'>{2}</span>" +
               "</div><hr class='cell-divide-hr'><div class='button-wrapper'><a class='btn-solid-reg page-scroll' href='product.aspx?id={3}' onclick='buy(this.id)'>ADD TO CART</a></div></div></div>", img, n, price,id);
            }

           
            showall.Text += s6;
        }









    }
}