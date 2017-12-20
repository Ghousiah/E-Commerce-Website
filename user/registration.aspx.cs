using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class user_registration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (!(con.State == ConnectionState.Open))
            con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO registration VALUES('"+tbFirstname.Text+"','"+tbLastname.Text+"','"+tbEmail.Text+"','"+tbPassword.Text+"','"+tbAddress.Text+"','"+tbCity.Text+"','"+tbState.Text+"','"+tbPincode.Text+"','"+tbMobile.Text+"')";
        cmd.ExecuteNonQuery();

        lblMsg.Text = "Registered Successfully!";

        tbFirstname.Text = "";
        tbLastname.Text = "";
        tbEmail.Text = "";
        tbPassword.Text = "";
        tbAddress.Text = "";
        tbCity.Text = "";
        tbState.Text = "";
        tbPincode.Text = "";
        tbMobile.Text = "";

    }
}