using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_testing : System.Web.UI.Page
{
    private string s;
    HttpCookie cookie = new HttpCookie("aa");

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void btnCookie_Click(object sender, EventArgs e)
    {
        try {
            lblCookie.Text = "";
            if (Request.Cookies["aa"] != null)
            {
                s = Convert.ToString(Request.Cookies["aa"].Value);
                string[] strArr = s.Split('|');
                for (int i = 0; i < strArr.Length; i++)
                {
                    lblCookie.Text += "<br />" + strArr[i].ToString();
                }
            }
            else
            {
                lblCookie.Text = "No Cookies are available here.";
            }
        }
        catch (Exception ex) {
            lblCookie.Text = ex.ToString();
        }   
    }
}