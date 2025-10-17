//48073253
//50600826
//45911398
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SU3_Prac6
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //variables
            string name = txtName.Text;
            string mode = ddlStudyMode.SelectedValue.ToString();
            string courses = lstCourses.SelectedValue.ToString();

            /*if (!rfvName.IsValid || !revEmail.IsValid || !rfvStudyMode.IsValid || ddlStudyMode.SelectedIndex == 0 || !rfvEmail.IsValid)
            {
                lblOutput.Text = "Make sure all the required information have been provided!";
                lblOutput.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {*/
            //validation and images
                if (lstCourses.SelectedIndex == 0)
                {
                    imgCourses.ImageUrl = @"~/WlcomeWebDev.png";
                    imgCourses.Visible = true;
                    lblOutput.ForeColor = System.Drawing.Color.Green;
                    lblOutput.Text = "Hi, " + name + " you have successfully registered " + mode + " for " + courses + " Course.";
            }
                else if (lstCourses.SelectedIndex == 1)
                {
                    imgCourses.ImageUrl = @"~/WelcometoAI.jpg";
                    imgCourses.Visible = true;
                    lblOutput.ForeColor = System.Drawing.Color.Green;
                    lblOutput.Text = "Hi, " + name + " you have successfully registered " + mode + " for " + courses + " Course.";
            }
                else if (lstCourses.SelectedIndex == 2)
                {
                    imgCourses.ImageUrl = @"~/WelcometoDataScie.jpg";
                    imgCourses.Visible = true;
                    lblOutput.ForeColor = System.Drawing.Color.Green;
                    lblOutput.Text = "Hi, " + name + " you have successfully registered " + mode + " for " + courses + " Course.";
            }
                else if (lstCourses.SelectedIndex == 3)
                {
                    imgCourses.ImageUrl = @"~/WelcometoCyber.jpg";
                    imgCourses.Visible = true;
                    lblOutput.ForeColor = System.Drawing.Color.Green;
                    lblOutput.Text = "Hi, " + name + " you have successfully registered " + mode + " for " + courses + " Course.";
            }
                else if (lstCourses.SelectedIndex == -1)
                {
                //error message
                    lblOutput.ForeColor = System.Drawing.Color.Red;
                    lblOutput.Text = "Make sure all the required information have been provided!";
                    return;
                } 
               
           // }

           
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //clear 
            txtName.Text = "";
            txtEmail.Text = "";
            lstCourses.SelectedIndex = -1;
            ddlStudyMode.SelectedIndex = 0;
            lblOutput.Text = "";
            imgCourses.Visible = false;

        }
    }
}