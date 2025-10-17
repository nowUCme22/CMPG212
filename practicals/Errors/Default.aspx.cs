using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SU3_Prac_5
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            //variables
            double cost;
            double totalAmount;

            //data validation
            if (txtFName.Text == "" || txtLName.Text == "" || txtEmail.Text == "" || txtPhoneNr.Text == "" || txtAmount.Text == "")
            {
                lblResult2.Text = "Please enter details";
            }
            else
            {

                //result label
                lblResult2.Text = "Selections made for " + txtFName.Text + " " + txtLName.Text + "---- Color: " + ddlColor.SelectedItem.ToString() + "-(Amount) " + txtAmount.Text;

                if (ddlColor.SelectedItem.ToString() == "Black")
                {
                    //if color is black
                    cost = 45.50;
                }
                else
                {
                    //if other
                    cost = 30;
                }

                try
                {
                    //try parse for text to double
                    if (double.TryParse(txtAmount.Text, out double Amount)) ;

                    //total amount calculation
                    totalAmount = Amount * cost;
                    lblAmount.Text = $"Total cost, excluding tax = R {totalAmount:f2}";

                    //tax calculation
                    double tax = totalAmount * 0.15;
                    lblTax.Text = $"Total amount of tax: R {tax:f2}";

                    //total cost calculATION
                    double TotalCost = totalAmount + tax;
                    lblTotal.Text = $"Total cost, including tax: R {TotalCost:f2}";
                }
                catch
                {
                    lblAmount.Text = "Unexpected error";
                }
            }

        }
    }
}