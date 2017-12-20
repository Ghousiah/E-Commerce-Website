using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class user_delete_cart : System.Web.UI.Page
{
    string cookieValue;
    string eachCookie;
    string[] cart_items = new string[6];
    int id;
    string name, description, price, qty, images;
    int count = 0;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString);
    int prod_id, prod_qty;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] != null)
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());

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
                    dt.Rows.Add(cart_items[0], cart_items[1], cart_items[2], cart_items[3], cart_items[4], i.ToString(), cart_items[5]);

                }
            }

            foreach (DataRow dr in dt.Rows)
            {
                if (count == id)
                {
                    prod_id = Convert.ToInt32(dr["new_id"].ToString());
                    prod_qty = Convert.ToInt32(dr["qty"].ToString());
                }
                count += 1;
            }

            try
            {
                if (!(con.State == ConnectionState.Open))
                    con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update product SET Quantity=Quantity+" + prod_qty + " WHERE Id=" + prod_id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            dt.Rows.RemoveAt(id);

            Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);


            count = 0;
            foreach (DataRow row in dt.Rows)
            {
                name = row["name"].ToString();
                description = row["description"].ToString();
                price = row["price"].ToString();
                qty = row["qty"].ToString();
                images = row["image"].ToString();
                prod_id = Convert.ToInt32(row["new_id"].ToString());
                count += 1;
                if (count == 1)
                {
                    Response.Cookies["aa"].Value = name + "," + description + "," + price + "," + qty + "," + images + "," + prod_id;
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
                }
                else
                {
                    Response.Cookies["aa"].Value = Response.Cookies["aa"].Value + "|" + name + "," + description + "," + price + "," + qty + "," + images + "," + prod_id;
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
                }
            }
            Response.Redirect("view_cart.aspx");
        }

    }
}