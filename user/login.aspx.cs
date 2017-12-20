using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class user_login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString.ToString());
    int count = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (!(con.State == ConnectionState.Open))
            con.Open();

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "SELECT * FROM registration WHERE email='" + tbEmail.Text + "' AND password='" + tbPassword.Text + "'";
        cmd.ExecuteNonQuery();

        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);

        count = dt.Rows.Count;

        if (count > 0)
        {
            if (Session["checkoutButton"] == "yes")
            {
                Session["user"] = tbEmail.Text;
                Response.Redirect("update_order_details.aspx");
            }
            else
            {
                Session["user"] = tbEmail.Text;
                Response.Redirect("order_details.aspx");
            }
        }
        else
        {
            lblMsg.Text = "Invalid Username or Password.";
        }
    }
}