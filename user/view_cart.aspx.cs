using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class user_view_cart : System.Web.UI.Page
{
    string cookieValue;
    string eachCookie;
    string[] cart_items = new string[6];
    double total=0;

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[] { new DataColumn("name"), new DataColumn("description"), new DataColumn("price"), new DataColumn("qty"), new DataColumn("image"), new DataColumn("id"), new DataColumn("new_id") });

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
                dt.Rows.Add(cart_items[0], cart_items[1], cart_items[2], cart_items[3], cart_items[4], i.ToString(),cart_items[5]);

                total += (Convert.ToDouble(cart_items[2])*Convert.ToDouble(cart_items[3]));
            }

            DL1.DataSource = dt;
            DL1.DataBind();

            lblTotal.Text = "Grand Total : $ " + total.ToString("0.00");
        }
        else {
            lblTotal.Text = "You have no items in cart!";
            btnCheckout.Visible = false;
        }

      

    }
    
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("display_item.aspx");
    }

    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        Session["checkoutButton"] = "yes";
        Response.Redirect("checkout.aspx");
    }
}