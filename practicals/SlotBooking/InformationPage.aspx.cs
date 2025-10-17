using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prac10_SU3
{
    public partial class InformationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //retireve cookies
            HttpCookie userCookieRetrieve2 = Request.Cookies["UserInfo"];

            if (userCookieRetrieve2 != null)
            {
                lblOutput2.Text = "Hello, " + userCookieRetrieve2["UserName"] + " your slot booking information is as ff: ";
            }

            if (Session["Date"] != null && Session["Module"] != null)
            {
                lblSession.Text = "Session Date: " + Session["Date"];
                lblModule.Text = "Module: " + Session["Module"];
            }

            /*if (Session["Module"] != null)
            {
                lblSession.Text = "Module: " + Session["Module"];
            }*/

        }

        protected void lblBookNewSlot_Click(object sender, EventArgs e)
        {
            //redirect to 1 page
            Response.Redirect("Default.aspx");
        }
    }
}