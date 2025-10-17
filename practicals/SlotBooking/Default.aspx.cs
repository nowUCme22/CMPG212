using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prac10_SU3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            //create cookie
            HttpCookie userCookie = new HttpCookie("UserInfo");

            //assign value
            userCookie["UserName"] = txtName.Text;
            Response.Cookies.Add(userCookie);
            //expires in 5 min
            userCookie.Expires = DateTime.Now.AddMinutes(5);

            //storing a session
            Session["StudyLevel"] = ddlStudyLevel.Text;

            //redirect to 2 page
            Response.Redirect("BookingPage.aspx");
        }
    }
}