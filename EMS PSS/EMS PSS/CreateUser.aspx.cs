using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace EMS_PSS
{
    public partial class CreateUser : System.Web.UI.Page
    {
        private const string mysqlPass = "Fattymilk123";
        private string userID;
        private string firstName;
        private string lastName;
        private string userType;

        protected void Page_Load(object sender, EventArgs e)
        {
            //check session variables to make sure user did not get to this page illegally
            userID = (string)Session["userID"];
            firstName = (string)Session["firstName"];
            lastName = (string)Session["lastName"];
            userType = (string)Session["userType"];

            userInfo.InnerHtml = "<table>" +
                "<tr><td>Username: </td><td>" + userID + "</td></tr>" +
                "<tr><td>First Name: </td><td>" + firstName + "</td></tr>" +
                "<tr><td>Last Name: </td><td>" + lastName + "</td></tr>" +
                "<tr><td>User Type: </td><td>" + userType + "</td></tr>" +
                "</table>";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string ipAddress = "localhost";
            string portNumber = "3306";
            string dataBaseName = "emspss";
            string userName = "emspss";
            string password = mysqlPass;
            string newUserType = "";
            string ConnectionString =
                "server=" + ipAddress +
                ";port=" + portNumber +
                ";userid=" + userName +
                ";password=" + password +
                ";database=" + dataBaseName + ";";

            if (rbUserTypeGen.Checked)
            {
                newUserType = "GENERAL";
            }
            else if (rbUserTypeAdmin.Checked)
            {
                newUserType = "ADMIN";
            }

            MySql.Data.MySqlClient.MySqlConnection mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection();
            mySqlConnection.ConnectionString = ConnectionString;

            try
            {
                mySqlConnection.Open();

                switch (mySqlConnection.State)
                {
                    case System.Data.ConnectionState.Open:
                        string query = "INSERT INTO EMSUser " +
                            "(userId, FirstName, LastName, userPassword, userType) " +
                            "VALUES (" +
                            "'" + tbUserID.Text + "', " +
                            "'" + tbFirstName.Text + "', " +
                            "'" + tbLastName.Text + "', " +
                            "'" + tbUserPass.Text + "', " +
                            "'" + newUserType + "');";
                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                        
                        // Connection has been made
                        try
                        {
                            command.ExecuteNonQuery();
                            lbMessage.Text = "Insert into EMSUser was successful!";
                        }
                        catch
                        {
                            //insert did not work
                            lbMessage.Text = "Insert into EMSUser was not successful!";
                            break;
                        }
                        break;
                    case System.Data.ConnectionState.Closed:
                        // Connection could not be made
                        lbMessage.Text = "Could not connect to database.";
                        break;
                    default:
                        // Connection is actively doing something
                        break;
                }
            }
            catch
            {
                lbMessage.Text = "Insert into employee was not successful!!";
            }
            finally
            {
                if (mySqlConnection.State != System.Data.ConnectionState.Closed)
                {
                    // Close the connection as a good Garbage Collecting practice
                    mySqlConnection.Close();
                }
            }
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbUserID.Text = "";
            tbUserPass.Text = "";
            rbUserTypeGen.Checked = true;
            rbUserTypeAdmin.Checked = false;
        }
    }
}