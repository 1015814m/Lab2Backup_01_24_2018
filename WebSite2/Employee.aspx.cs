using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;


//John Morrissey Lab 1

public partial class EmployeeDefault : System.Web.UI.Page
{
    public static int count = 0;
    public static string[,] returnArray = new string[1000, 2];

    protected void Page_Load(object sender, EventArgs e)
    {
        //Select information from the database and input it into the drop downs
    }






    protected void btnCommitEmployee_Click(object sender, EventArgs e)
    {

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fields are cleared')", true);
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtMiddleInitial.Text = "";
        txtDateOfBirth.Text = "";
        txtHouseNum.Text = "";
        txtStreet.Text = "";
        txtCity.Text = "";
        txtState.Text = "";
        txtCountry.Text = "";
        txtZip.Text = "";
        txtHireDate.Text = "";
        txtTerminationDate.Text = "";
        txtSalary.Text = "";
        txtManagerID.Text = "";
        txtFirstName.Focus();
    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        //Exits the web application
    }

    


}