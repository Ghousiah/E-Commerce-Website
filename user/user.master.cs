using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_user : System.Web.UI.MasterPage
{
    private string cookieValue;
    private string eachCookie;
    private string[] cart_items = new string[6];
    double total = 0;
    int count = 0;

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString.ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Closed)
            con.Open();

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "SELECT * FROM product_category";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);

        dlist.DataSource = dt;
        dlist.DataBind();

        if (con.State == ConnectionState.Open)
            con.Close();

        if (Request.Cookies["aa"] != null)
        {
            cookieValue = (Request.Cookies["aa"].Value);
            string[] parseCookie = cookieValue.Split('|');
            for (int i = 0; i < parseCookie.Length; i++)
            {
                eachCookie = parseCookie[i].ToString();
                string[] cookieItem = eachCookie.Split(',');
                for (int j = 0; j < cookieItem.Length; j++)
                {
                    cart_items[j] = cookieItem[j].ToString();

                }

                total += (Convert.ToDouble(cart_items[2]) * Convert.ToDouble(cart_items[3]));
                count += 1;
            }

            lblTotalCost.Text = "$ " + total.ToString("0.00");
            lblTotalItems.Text = count.ToString();
        }
    }
}
