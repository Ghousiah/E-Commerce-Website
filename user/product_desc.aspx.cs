using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class user_product_desc : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString.ToString());

    int id,qtyvalue;
    string name, description, price, qty, images;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string str = Request.QueryString["id"];
            if (Request.QueryString["id"] == null)
            { Response.Redirect("display_item.aspx"); }
            else if (string.IsNullOrEmpty(Request.QueryString["id"].ToString()))
            {
                Response.Redirect("display_item.aspx");
            }
            else
            {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());
                if (!(con.State == ConnectionState.Open))
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
               // cmd.CommandText = "SELECT * FROM product WHERE Quantity > 0 AND id=" + id + ";";
                cmd.CommandText = "SELECT * FROM product WHERE id=" + id + ";";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);              
                L1.DataSource = dt;
                L1.DataBind();
            }
                        
            qtyvalue=getQty(id);

            if (qtyvalue == 0)
            {
                lblQty.Visible = false;
                tbQty.Visible = false;
                btnAddtoCart.Visible = false;
                lblErr.Text = "Out of Stock!";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    protected void lbtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("display_item.aspx");
    }

    protected void btnAddtoCart_Click(object sender, EventArgs e)
    {
        try
        {
            string str = Request.QueryString["id"];
            if (Request.QueryString["id"] == null)
            { Response.Redirect("display_item.aspx"); }
            else if (string.IsNullOrEmpty(Request.QueryString["id"].ToString()))
            {
                Response.Redirect("display_item.aspx");
            }
            else if (string.IsNullOrWhiteSpace(tbQty.Text.ToString()))
            {
                lblErr.Text = "Please enter the quantity.";
            }
            else
            {
                DataTable dt = new DataTable();
                id = Convert.ToInt32(Request.QueryString["id"].ToString());
                if (!(con.State == ConnectionState.Open))
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //cmd.CommandText = "SELECT * FROM product WHERE Quantity > 0 AND id=" + id + ";";
                cmd.CommandText = "SELECT * FROM product WHERE id=" + id + ";";
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                              
                foreach (DataRow row in dt.Rows)
                {
                    name = row["Name"].ToString();
                    description = row["Description"].ToString();
                    price = row["Price"].ToString();
                    qty = row["Quantity"].ToString();
                    images = row["Images"].ToString();
                }

                if (Convert.ToInt32(tbQty.Text) > Convert.ToInt32(qty))
                {
                    lblErr.Text = "Sorry! No Enough Stock Available For This Product.";
                }
                else if(Convert.ToInt32(tbQty.Text) <= 0)
                {
                    lblErr.Text = "Invalid Quantity!";
                }
                else
                {
                    lblErr.Text = "";
                    if (Request.Cookies["aa"] == null)
                    {
                        Response.Cookies["aa"].Value = name + "," + description + "," + price + "," + tbQty.Text + "," + images+","+id.ToString();
                        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
                    }
                    else
                    {
                        Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + "|" + name + "," + description + "," + price + "," + tbQty.Text + "," + images + "," + id.ToString();
                        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
                    }

                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE product SET Quantity=Quantity-" + tbQty.Text + " WHERE Id=" + id;
                    cmd.ExecuteNonQuery();
                    Response.Redirect("product_desc.aspx?id=" + id.ToString());
                }                
            }
        }
        catch (Exception ex)
        {
            lblErr.Text=(ex.ToString());
        }
    }

    private int getQty(int id)
    {       
        if (!(con.State == ConnectionState.Open))
            con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        // cmd.CommandText = "SELECT * FROM product WHERE Quantity > 0 AND id=" + id + ";";
        cmd.CommandText = "SELECT * FROM product WHERE id=" + id + ";";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);

        foreach(DataRow dr in dt.Rows)
        {
            qtyvalue = Convert.ToInt32(dr["Quantity"].ToString());
        }

        return qtyvalue;
    }
}