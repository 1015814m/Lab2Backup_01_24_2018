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
    private static int selectSkill;
    private static int selectProject;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Set the variables for the users selections
        selectSkill = skillDropDown.SelectedIndex - 1;
        selectProject = projectDropDown.SelectedIndex - 1;

        //Select from the database and add that to the drop down
        projectDropDown.Items.Clear();
        projectDropDown.Items.Add("(No Project)");
        skillDropDown.Items.Clear();
        skillDropDown.Items.Add("(No Project)");
        selectFromDB("SKILL","SkillName", projectDropDown);
        selectFromDB("PROJECT", "ProjectName", skillDropDown); 
    }

    protected void btnCommitEmployee_Click(object sender, EventArgs e)
    {

        Employee newEmployee = new Employee(txtFirstName.Text, txtLastName.Text, txtMiddleInitial.Text,
            txtHouseNum.Text, txtStreet.Text, txtCity.Text, txtState.Text, txtCountry.Text, txtZip.Text,
            DateTime.Parse(txtDateOfBirth.Text), DateTime.Parse(txtHireDate.Text), DateTime.Parse(txtTerminationDate.Text),
            double.Parse(txtSalary.Text), int.Parse(txtManagerID.Text), (string)Session["user"], System.DateTime.Now);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fields are cleared')", true);
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

    private void selectFromDB(string table, string column, Control cntrl)
    {
        try
        {
            //Connect to the DB
            System.Data.SqlClient.SqlConnection sqlc = connectToDB();

            //Creates a new sql select command to select the data from the skills table
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            select.Connection = sqlc;
            select.CommandText = "select " + column + " from [dbo].[" + table + "]";
            System.Data.SqlClient.SqlDataReader reader;

            reader = select.ExecuteReader();


            while (reader.Read())
            {
                (cntrl as DropDownList).Items.Add(reader.GetString(0));
                
            }
            sqlc.Close();
        }
        catch (Exception c)
        {
            //Shows an error message if there is a problem connecting to the database
            resultMessage.Text += "DROP DOWN ERROR";
            resultMessage.Text += c.Message;
        }
    }

    protected System.Data.SqlClient.SqlConnection connectToDB()
    {
        try
        {
            //Connects to the database and returns the connection
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost; Database=Lab2;Trusted_Connection=Yes";
            sc.Open();
            return sc;
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('There was an error connecting to the Database')", true);
            return null;
        }
    }

    private void insertBridge(int id, Employee person)
    {
        //try
        //{
        //    //Connect to the DB
        //    System.Data.SqlClient.SqlConnection sqlc = connectToDB();

        //    //Creates a new sql insert statement to insert into the bridge table
        //    System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        //    insert.Connection = sqlc;
        //    insert.CommandText = "insert into [dbo].[EMPLOYEEPROJECT] values ('" + 
        //}
        //catch (Exception c)
        //{
            
        //    errorMessage.Text += c;
        //}
    }




}