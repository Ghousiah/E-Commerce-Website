using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_delete : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString.ToString());

    string category;

    protected void Page_Load(object sender, EventArgs e)
    {
        category = Request.QueryString["category"].ToString();
        if (!(con.State == ConnectionState.Open))
            con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM product_category WHERE product_category='"+category+"'";
        cmd.ExecuteNonQuery();

        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = con;
        cmd1.CommandText = "DELETE FROM product WHERE category='" + category + "'";
        cmd1.ExecuteNonQuery();

        Response.Redirect("add_category.aspx");
    }
}