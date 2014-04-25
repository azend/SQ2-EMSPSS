using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace EMS_PSS
{
    public partial class SearchEmployee : System.Web.UI.Page
    {
        private const string mysqlPass = "password";
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
            List<List<string>> employees = new List<List<string>>();
            string ipAddress = "localhost";
            string portNumber = "3306";
            string dataBaseName = "emspss";
            string userName = "root";
            string password = mysqlPass;
            string empLastName = tbSearchLastName.Text;

            string ConnectionString =
                "server=" + ipAddress +
                ";port=" + portNumber +
                ";userid=" + userName +
                ";password=" + password +
                ";database=" + dataBaseName + ";";

            MySql.Data.MySqlClient.MySqlConnection mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection();

            mySqlConnection.ConnectionString = ConnectionString;

            try
            {
                mySqlConnection.Open();

                switch (mySqlConnection.State)
                {
                    case System.Data.ConnectionState.Open:

                        string query = "SELECT eID, employFirstName, employLastName, employeeStatus, employeeType, hiringCompanyName FROM Employee WHERE employLastName = '" +
                             empLastName + "' AND employeeStatus != 'INACTIVE' AND employeeType != 'CONTRACT';";
                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                        // Connection has been made
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    List<string> employee = new List<string>();

                                    employee.Add(reader[0].ToString());
                                    employee.Add(reader[1].ToString());
                                    employee.Add(reader[2].ToString());
                                    employee.Add(reader[3].ToString());
                                    if (reader[4].ToString() == "FULLTIME")
                                    {
                                        employee.Add("FullTime");
                                    }
                                    else if (reader[4].ToString() == "PARTTIME")
                                    {
                                        employee.Add("PartTime");
                                    }
                                    else if (reader[4].ToString() == "SEASONAL")
                                    {
                                        employee.Add("Seasonal");
                                    }
                                    employee.Add(reader[5].ToString());
                                    employees.Add(employee);
                                }
                                catch
                                {
                                }
                            }

                            int i = 0;

                            results.InnerHtml = "";
                            results.InnerHtml += "<b>Results</b></br><table border = 2>" +
                                "<tr><td>Employee ID</td><td>Employee Name</td><td>Status</td><td>Employee Type</td><td>Company</td></tr>";
                            foreach (List<string> employee in employees)
                            {
                                i++;
                                results.InnerHtml += "<tr><td>" + employee[0] + "</td><td>" + employee[1] + ", " + employee[2] + "</td><td>" +
                                    employee[3] + "</td><td>" + employee[4] + "</td><td>" + employee[5] + "</td></tr>";
                            }
                            results.InnerHtml += "</table></br></br>";

                            // Enable results and editID form
                            results.Visible = true;
                            editID.Visible = true;
                        }

                        break;

                    case System.Data.ConnectionState.Closed:
                        lbErrorMessage.Text = "Connection could not be made to the database.";
                        // Connection could not be made

                        break;

                    default:
                        // Connection is actively doing something
                        break;

                }
            }
            catch
            {
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

        protected void SubmitEdit_Click(object sender, EventArgs e)
        {
            // !Populate edit form with employee data
            //lbFirstName.Text = "<Name here...>";
            //lbLastName.Text = "";
            //lbSIN.Text = "";
            //lbDateOfHire = "";
            //lbDateOfBirth = "";
            //lbCompany = "";

            editEmployee.Visible = true;
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            tbSearchLastName.Text = "";
            results.Visible = false;
            editID.Visible = false;
            editEmployee.Visible = false;
        }

        protected void SubmitNewEmployee_Click(object sender, EventArgs e)
        {
            
        }
    }
}