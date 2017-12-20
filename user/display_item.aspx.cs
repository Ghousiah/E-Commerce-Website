using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class user_display_item : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString.ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        try {
            if (!(con.State == ConnectionState.Open))
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //cmd.CommandText = "SELECT * FROM product WHERE Quantity > 0";

            if (Request.QueryString["category"] == null)
            {
                cmd.CommandText = "SELECT * FROM product";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM product WHERE category='"+ Request.QueryString["category"] .ToString()+ "'";
            }      
            
            if(Request.QueryString["category"]==null && Request.QueryString["search"] != null)
            {
                cmd.CommandText = "SELECT * FROM product WHERE Name like ('%"+ Request.QueryString["search"].ToString() + "%') ";
            } 
            
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            r1.DataSource = dt;
            r1.DataBind();
            
               }
        catch(Exception ex)
        {
            Response.Write(ex.ToString());
        }
        
    }
}