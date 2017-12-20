using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_view_full_order : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString.ToString());
    int id;
    double total = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            if (con.State == ConnectionState.Closed)
                con.Open();


            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandText = "SELECT * FROM orders WHERE id='" + id + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            sda1.Fill(dt1);

            Repeater1.DataSource = dt1;
            Repeater1.DataBind();


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM order_details WHERE order_id=" + id + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                total += Convert.ToInt32(dr["product_price"].ToString()) * Convert.ToInt32(dr["product_qty"].ToString());
            }

            r1.DataSource = dt;
            r1.DataBind();
            lblTotal.Text = "Grand Total : " + total.ToString();
            if (con.State == ConnectionState.Open)
                con.Close();
        }
    }
}