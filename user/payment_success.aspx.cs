using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class user_payment_success : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString.ToString());
    private string cookieValue;
    private string eachCookie;
    string order = "";
    private string order_id;
    string[] cart_items = new string[6];

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        if (!(con.State == ConnectionState.Open))
            con.Open();

        order = Request.QueryString["order"].ToString();

        if (order == Session["order_no"])
        {

            // getting and storing user details in orders table
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM registration WHERE email='" + Session["user"].ToString() + "'";

            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cmd.CommandText = "INSERT INTO orders VALUES('"+dr["firstname"]+"','"+dr["lastname"]+"','"+dr["email"]+"','"+dr["address"]+"','"+dr["city"]+"','"+dr["state"]+"','"+dr["pincode"]+"','"+dr["mobile"]+"') ";
                cmd.ExecuteNonQuery();
            }
            // end of storing user details

            // get order_id from orders table
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandText = "SELECT TOP 1 * FROM orders WHERE email='"+Session["user"].ToString()+"' ORDER BY id DESC ";

            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            sda1.Fill(dt1);

            foreach(DataRow dr in dt1.Rows)
            {
                order_id = dr["id"].ToString();
            }
            // end of getting order id

            // start of getting order items from cookies
            if (Request.Cookies["aa"] != null)
            {
                cookieValue = (Request.Cookies["aa"].Value);
                string[] parseCookie = cookieValue.Split('|');
                for (int i = 0; i < parseCookie.Length; i++)
                {
                    eachCookie = parseCookie[i].ToString();
                    string[] cookieItem = eachCookie.Split(',');
                    for (int j = 0; j < cookieItem.Length; j++)
                    {
                        cart_items[j] = cookieItem[j].ToString();

                    }

                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandText = "INSERT INTO order_details VALUES('"+order_id.ToString()+"','"+cart_items[0].ToString()+"','"+cart_items[2].ToString()+ "','" + cart_items[3].ToString() + "','" + cart_items[4].ToString() + "') ";

                    cmd2.ExecuteNonQuery();                   
                }
            }
            // end of getting items from cookies
        }
        else
        {
            Response.Redirect("login.aspx");
        }

        if (con.State == ConnectionState.Open)
            con.Close();

        Session["user"] = "";
        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("display_item.aspx");
    }
}