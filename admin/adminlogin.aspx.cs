using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class admin_adminlogin : System.Web.UI.Page
{
    static string constr = ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString;
    SqlConnection con = new SqlConnection(constr);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try {
            if (!(con.State == ConnectionState.Open))
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM admin_login WHERE UserName='"+tblogin.Text+"' AND Password='"+tbpassword.Text+"'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["admin"] = tblogin.Text;
                Response.Redirect("add_product.aspx");
            }
            else
            {
                LblError.Text = "You have entered invalid username or password.";
            }
           
        } catch(Exception ex)
        { LblError.Text = ex.ToString(); }     
    }
}