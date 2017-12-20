using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class user_update_order_details : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString.ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }
        DataTable dt = new DataTable();
        if (!(con.State == ConnectionState.Open))
            con.Open();

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "SELECT * FROM registration WHERE email='" + Session["user"].ToString() + "'";

        cmd.ExecuteNonQuery();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);

        foreach (DataRow dr in dt.Rows)
        {
            tbfname.Text = dr["firstname"].ToString();
            tblname.Text = dr["lastname"].ToString();
            tbAddress.Text = dr["address"].ToString();
            tbCity.Text = dr["city"].ToString();
            tbState.Text = dr["state"].ToString();
            tbPincode.Text = dr["pincode"].ToString();
            tbMobile.Text = dr["mobile"].ToString();
        }

        if (con.State == ConnectionState.Open)
            con.Close();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (!(con.State == ConnectionState.Open))
            con.Open();

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "UPDATE registration SET firstname='" + this.tbfname.Text.ToString() + "', lastname='" + tblname.Text.ToString() + "',address='" + this.tbAddress.Text.ToString() + "',city='" + tbCity.Text.ToString() + "',state='" + tbState.Text.ToString() + "',pincode='" + tbPincode.Text.ToString() + "',mobile='" + tbMobile.Text.ToString() + "' WHERE email='" + Session["user"].ToString() + "' ";

        cmd.ExecuteNonQuery();
        if (con.State == ConnectionState.Open)
            con.Close();

        Response.Redirect("payment_gateway.aspx");
    }
}