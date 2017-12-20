using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_display_order : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed)
            con.Open();

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "SELECT * FROM orders WHERE email='"+Session["user"].ToString()+"' ORDER BY id DESC";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);

        r1.DataSource = dt;
        r1.DataBind();

        if (con.State == ConnectionState.Open)
            con.Close();
    }
}