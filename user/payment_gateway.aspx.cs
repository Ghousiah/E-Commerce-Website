using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_payment_gateway : System.Web.UI.Page
{
    private string cookieValue;
    private string eachCookie;
    string[] cart_items = new string[6];
    private double total=0;
    private string order_no;

    protected void Page_Load(object sender, EventArgs e)
    {
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
            }
            Session["total"] = total.ToString();
        }

        // here comes the implementation of payment gateway

        order_no = Class1.GetRandomPassword(10);
        Session["order_no"] = order_no.ToString();

        Response.Write("<form action='https://www.sandbox.paypal.com/cgi-bin/webscr' method='post' name='buyCredits' id='buyCredits'>");
        Response.Write("<input type='hidden' name='cmd' value='_xclick' />");
        Response.Write("<input type='hidden' name='business' value='your_email_address@gmail.com' />");
        Response.Write("<input type='hidden' name='currency_code' value='USD' />");
        Response.Write("<input type='hidden' name='item_name' value='payment for donate' />");
        Response.Write("<input type='hidden' name='item_number' value='0' />");
        Response.Write("<input type='hidden' name='amount' value='"+Session["total"].ToString()+"' />");
        Response.Write("<input type='hidden' name='return' value='http://localhost:53983/user/payment_success.aspx?order="+order_no.ToString()+"' />");
        Response.Write("</form>");

        Response.Write("<script type='text/javascript'>");
        Response.Write("document.getElementById('buyCredits').submit();");
        Response.Write("</script>");

        // end of implementation
    }
}