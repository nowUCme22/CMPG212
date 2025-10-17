using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prac10_SU3
{
    public partial class BookingPage : System.Web.UI.Page
    {
        //public variable
        DateTime mydate;
        protected void Page_Load(object sender, EventArgs e)
        {
            //retrieve cookie
            HttpCookie userCookieRetrieve = Request.Cookies["UserInfo"];

            if (userCookieRetrieve != null)
            {
                lblOutput.Text = "Welcome, " + userCookieRetrieve["UserName"];
            }
           
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //select a date
            mydate = Calendar1.SelectedDate;

            //weekend or past
            if (mydate.DayOfWeek == DayOfWeek.Saturday || mydate.DayOfWeek == DayOfWeek.Sunday)
            {
                lblError.Text = "Please choose a day in the week (Not on the weekend)";
                return;
            }
            else if (mydate < DateTime.Today)
            {
                lblError.Text = "Please choose a day in the future";
                return;
            }
            else
            {
                Session["Date"] = mydate.ToString("dddd, dd MMMM yyyy");
            }

            
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            //storing module
            Session["Module"] = ddlModule.Text;
            //storing a date
            
            //redirect to 3 page
            Response.Redirect("InformationPage.aspx");
        }
    }
}