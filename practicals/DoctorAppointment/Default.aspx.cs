using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Prac9_SU3
{
    public partial class Default : System.Web.UI.Page
    {
        DateTime theDate;
        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\dboPatients.mdf;Integrated Security=True";
        SqlConnection conn;
        DataSet ds;
        SqlDataAdapter adapt;
        SqlCommand comm;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Today.Date;
            }
        }

        protected void rbtnCash_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            //variables
            string name, email, service,methodP;


            try
            {
                DateTime myDate = new DateTime(DateTime.Today.Year,DateTime.Today.Month,DateTime.Today.Day,8,0,0);
                theDate = Calendar1.SelectedDate;
                //theDate = Calendar1.SelectedDate.Date.AddHours(8);
                name = txtName.Text;
                email = txtEmail.Text;
                service = ddlService.SelectedItem.ToString();

                if (rbtnCash.Checked)
                {
                    methodP = "Cash";
                }
                else if (rbtnMedicalAid.Checked)
                {
                    methodP = "Medical Aid";
                }
                else
                {
                    lblOutput.Text = "Please choose a payment method";
                    return;
                }

                if (theDate < DateTime.Today)
                {
                    lblOutput.ForeColor = System.Drawing.Color.Red;
                    lblOutput.Text = "The appointment date must be in future!";
                }
                else if (theDate.DayOfWeek == DayOfWeek.Saturday || theDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    lblOutput.ForeColor = System.Drawing.Color.Red;
                    lblOutput.Text = "The appointment date cannot be on a weekend!";
                }
                else
                {
                    lblOutput.ForeColor = System.Drawing.Color.Black;
                    string formattedDate = theDate.ToString("yyyy/MM/dd hh:mm:ss tt");
                    lblOutput.Text = "Hi " + name + ", your appointment for " + service +
                                     " has been booked for " + formattedDate + ".";
                }

                //write into database
                conn = new SqlConnection(conString);
                conn.Open();
                string sqlWrite = "INSERT INTO Patients VALUES (@name, @email,@service,@payment,@date)";

                using (comm = new SqlCommand(sqlWrite, conn))
                {
                    comm.Parameters.AddWithValue("@name", name) ;
                    comm.Parameters.AddWithValue("@email", email);
                    comm.Parameters.AddWithValue("@service", service);
                    comm.Parameters.AddWithValue("@payment", methodP);
                    comm.Parameters.AddWithValue("@date", theDate);
                    comm.ExecuteNonQuery();

                }



                //show data
                adapt = new SqlDataAdapter();
                ds = new DataSet();
                string sql = @"SELECT * FROM Patients";
                comm = new SqlCommand(sql, conn);
                adapt.SelectCommand = comm;
                adapt.Fill(ds);

                GridView1.DataSource = ds;
                GridView1.DataBind();
                conn.Close();




            }
            catch (Exception ex)
            {
                lblOutput.ForeColor = System.Drawing.Color.Red;
                lblOutput.Text = "Error:" + ex.Message;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //DateTime theDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);
            //theDate = Calendar1.SelectedDate;


        }
    }
}