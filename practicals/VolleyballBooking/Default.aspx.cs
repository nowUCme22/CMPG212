using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SU3_Prac8_TakeHome
{
    public partial class Default : System.Web.UI.Page
    {
        /*//variables
        int bookday = 0;
        string timeSlot = "";
        
        DateTime meetingDate;*/
        DateTime selectedDate;

        // With this:
        public int bookday
        {
            get { return ViewState["bookday"] != null ? (int)ViewState["bookday"] : 0; }
            set { ViewState["bookday"] = value; }
        }

        public string timeSlot
        {
            get { return ViewState["timeSlot"] != null ? ViewState["timeSlot"].ToString() : ""; }
            set { ViewState["timeSlot"] = value; }
        }

        public DateTime meetingDate
        {
            get { return ViewState["meetingDate"] != null ? (DateTime)ViewState["meetingDate"] : DateTime.MinValue; }
            set { ViewState["meetingDate"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //try catch for calender post back
            try
            {
                if (!Page.IsPostBack)
                {
                    Calendar1.SelectedDate = DateTime.Today;
                }
            }
            catch (System.Exception ex)
            {
                lblOutput1.Text = ex.Message;
            }
        }

        //method for calender
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date == DateTime.Today)
            {
                //Highlight today's date
                e.Cell.BackColor = System.Drawing.Color.Yellow;
                e.Cell.ForeColor = System.Drawing.Color.Black;
                e.Cell.Font.Bold = true;
            }
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtStudentNumber.Text))
            {
                lblOutput1.Text = "Please fill in all the fields and select a campus before booking";
                lblOutput2.Text = "";
                return;
            }

            if (Calendar1.SelectedDate.DayOfWeek != DayOfWeek.Monday && Calendar1.SelectedDate.DayOfWeek != DayOfWeek.Friday)
            {
                lblOutput1.Text = "Bookings are only allowed on Mondays and Fridays.";
                lblOutput2.Text = "";
                return;
            }

            lblOutput1.Text = "Hello " + txtName.Text + ", your class has been successfully booked for " + meetingDate.ToString("dddd MM / dd");
            lblOutput2.Text = "Your class slot time is: " + timeSlot;

            txtName.Text = "";
            txtEmail.Text = "";
            txtStudentNumber.Text = "";
            rbtnMC.Checked = false;
            rbtnPC.Checked = false;
            rbtnVC.Checked = false;
            Calendar1.SelectedDate = DateTime.Today;
        }

        protected void rbtnMC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMC.Checked)
            {
                bookday = 8;
                timeSlot = "10:00am - 12:00pm";
            }
            else if (rbtnPC.Checked)
            {
                bookday = 4;
                timeSlot = "11:00am - 1:00pm";
            }
            else if (rbtnVC.Checked)
            {
                bookday = 6;
                timeSlot = "08:00am - 10:00am";
            }
            /*else
            {
                lblOutput1.Text = "Please choose your campus";
            }*/

            try
            {
                //always based of today's date
               // Calendar1.SelectedDate = DateTime.Today;

                //use reset date
                selectedDate = Calendar1.SelectedDate;
                meetingDate = selectedDate.AddDays(bookday);
                Calendar1.SelectedDate = meetingDate;
            }
            catch (Exception ex)
            {
                lblOutput1.Text = "Error: " + ex.Message;
            }


        }
    }
}