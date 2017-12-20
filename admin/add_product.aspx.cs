using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class admin_add_product : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString.ToString());

    string fname,imgPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }

        if (IsPostBack) { return; }

        ddCategory.Items.Clear();

        if (!(con.State == ConnectionState.Open))
            con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM product_category";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);
        foreach(DataRow dr in dt.Rows)
        {
            ddCategory.Items.Add(dr["product_category"]+"");
        }       
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            string str = Request.PhysicalApplicationPath;
            fname = Class1.GetRandomPassword(10).ToString();
            fuImage.SaveAs(Request.PhysicalApplicationPath + "./images/" + fname + fuImage.FileName.ToString());

            imgPath = "images/"+fname+fuImage.FileName.ToString();
            if (!(con.State == ConnectionState.Open))
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO product values('"+tbName.Text+"','"+tbDesc.Text+"',"+tbPrice.Text+","+tbQty.Text+",'"+imgPath+"','"+ddCategory.SelectedItem.Text.ToString()+"')";
            cmd.ExecuteNonQuery();                       
           
        }catch(Exception ex)
        {
            errlbl.Text = ex.ToString();
        }
        
    }
}