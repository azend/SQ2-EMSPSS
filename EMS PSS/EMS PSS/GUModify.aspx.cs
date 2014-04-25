using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AllEmployees;
using MySql.Data.MySqlClient;


namespace EMS_PSS
{
    public partial class GUModify : System.Web.UI.Page
    {
        private const string mysqlPass = "Fattymilk123";
        private string userID;
        private string firstName;
        private string lastName;
        private string userType;
        private string eid;
        private string employeeFirstName;
        private string employeeLastName;
        private string employeeType;
        private string employeeCompany;
        private string employeeSIN;
        private string employeeDateOfBirth;
        private string employeeDateOfHire;
        private string employeeSeason;
        private string employeeYear;
        private string employeeStatus;



        protected void Page_Load(object sender, EventArgs e)
        {
            //check session variables to make sure user did not get to this page illegally


            userID = (string)Session["userID"];
            firstName = (string)Session["firstName"];
            lastName = (string)Session["lastName"];
            userType = (string)Session["userType"];
            eid = Session["eid"].ToString();

            userInfo.InnerHtml = "<table>" +
                "<tr><td>Username: </td><td>" + userID + "</td></tr>" +
                "<tr><td>First Name: </td><td>" + firstName + "</td></tr>" +
                "<tr><td>Last Name: </td><td>" + lastName + "</td></tr>" +
                "<tr><td>User Type: </td><td>" + userType + "</td></tr>" +
                "</table>";

            if (!IsPostBack)
            {
                string ipAddress = "localhost";
                string portNumber = "3306";
                string dataBaseName = "emspss";
                string userName = "emspss";
                string password = mysqlPass;

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

                            string query = "SELECT hiringCompanyName, employFirstName, employLastName, employSIN, employeeType, dateOfHire, dateOfBirth, employeeStatus FROM Employee WHERE eId = " + eid + ";";
                            MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                            // Connection has been made
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    try
                                    {
                                        employeeCompany = reader[0].ToString();
                                        employeeFirstName = reader[1].ToString();
                                        employeeLastName = reader[2].ToString();
                                        employeeSIN = reader[3].ToString();
                                        employeeType = reader[4].ToString();
                                        employeeDateOfHire = ((DateTime)reader[5]).ToString("yyyy-MM-dd");
                                        employeeDateOfBirth = ((DateTime)reader[6]).ToString("yyyy-MM-dd");
                                        employeeStatus = reader[7].ToString();
                                    }
                                    catch
                                    {
                                    }
                                }
                            }

                            if (employeeType == "SEASONAL")
                            {
                                string secondQuery = "SELECT season FROM seasonalEmployee WHERE eId = " + eid + ";";
                                MySqlCommand secondCommand = new MySqlCommand(secondQuery, mySqlConnection);
                                // Connection has been made
                                using (MySqlDataReader reader = secondCommand.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        try
                                        {
                                            employeeSeason = reader[0].ToString();
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                            }

                            string[] season = employeeSeason.Split(' ');
                            employeeSeason = season[0];
                            employeeYear = season[1];


                            break;

                        case System.Data.ConnectionState.Closed:
                            lbMessage.Text = "Connection could not be made to the database.";
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

                tbFirstName.Text = employeeFirstName;
                tbLastName.Text = employeeLastName;
                tbCompany.Text = employeeCompany;
                tbSIN.Text = employeeSIN;
                tbDateOfHire.Text = employeeDateOfHire;
                tbDateOfBirth.Text = employeeDateOfBirth;
                if (employeeType == "FULLTIME")
                {
                    ddlEmployeeType.SelectedValue = "Full-time";
                }
                else if (employeeType == "PARTTIME")
                {
                    ddlEmployeeType.SelectedValue = "Part-time";
                }
                else if (employeeType == "SEASONAL")
                {
                    ddlEmployeeType.SelectedValue = "Seasonal";
                }
                if (employeeSeason != "")
                {
                    ddlSeason.SelectedValue = employeeSeason;
                }
                ddlEmployeeType.Enabled = false;
                if (employeeYear != "")
                {
                    tbYear.Text = employeeYear;
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            employeeType = ddlEmployeeType.SelectedItem.Text;

            if (employeeType == "Seasonal")
            {
                seasonalEmployee.Visible = true;
                baseEmployee.Visible = false;
            }
            else
            {
                fullAndPartTimeEmployee.Visible = true;
                baseEmployee.Visible = false;
            }
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbSIN.Text = "";
            tbCompany.Text = "";
            tbDateOfBirth.Text = "";
            tbDateOfHire.Text = "";
            tbYear.Text = "";

            seasonalEmployee.Visible = false;
            fullAndPartTimeEmployee.Visible = false;
            baseEmployee.Visible = true;
            lbMessage.Text = "";
        }

        protected void btnCommit_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            employeeType = ddlEmployeeType.SelectedItem.Text;
            employeeFirstName = tbFirstName.Text;
            employeeLastName = tbLastName.Text;
            employeeSIN = tbSIN.Text;
            employeeCompany = tbCompany.Text;
            employeeDateOfBirth = tbDateOfBirth.Text;
            employeeDateOfHire = tbDateOfHire.Text;

            if (employeeType == "Seasonal")
            {
                employeeSeason = ddlSeason.SelectedItem.Text;
                employeeYear = tbYear.Text;

                SeasonalEmployee newGuy = new SeasonalEmployee();

                if (!newGuy.SetFirstName(employeeFirstName))
                {
                    isValid = false;
                    lbFirstName.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbFirstName.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetLastName(employeeLastName))
                {
                    isValid = false;
                    lbLastName.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbLastName.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetSin(employeeSIN))
                {
                    isValid = false;
                    lbSIN.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbSIN.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetCompany(employeeCompany))
                {
                    isValid = false;
                    lbCompany.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbCompany.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetDateofHire(employeeDateOfHire))
                {
                    isValid = false;
                    lbDateOfHire.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbDateOfHire.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetDateOfBirth(employeeDateOfBirth))
                {
                    isValid = false;
                    lbDateOfBirth.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbDateOfBirth.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetSeason(employeeSeason, employeeYear))
                {
                    isValid = false;
                    lbSeason.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbSeason.ForeColor = System.Drawing.Color.Black;
                }

                if (isValid)
                {
                    //enter employee into database as a general user
                    //MUST ALSO CHECK that the SIN/name/date of birth fields are unique together
                    if (UpdateEmployee(newGuy, "SEASONAL"))
                    {
                        UpdateSeasonalEmployee(newGuy);
                    }
                }
                else
                {
                    //tell user employee could not be entered
                }
            }
            else if (employeeType == "Full-time")
            {
                employeeDateOfHire = tbDateOfHire.Text;
                FulltimeEmployee newGuy = new FulltimeEmployee();

                if (!newGuy.SetFirstName(employeeFirstName))
                {
                    isValid = false;
                    lbFirstName.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbFirstName.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetLastName(employeeLastName))
                {
                    isValid = false;
                    lbLastName.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbLastName.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetSin(employeeSIN))
                {
                    isValid = false;
                    lbSIN.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbSIN.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetCompany(employeeCompany))
                {
                    isValid = false;
                    lbCompany.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbCompany.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetDateOfBirth(employeeDateOfBirth))
                {
                    isValid = false;
                    lbDateOfBirth.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbDateOfBirth.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetDateofHire(employeeDateOfHire))
                {
                    isValid = false;
                    lbDateOfHire.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbDateOfHire.ForeColor = System.Drawing.Color.Black;
                }

                if (isValid)
                {
                    //enter employee into database as a general user
                    //MUST ALSO CHECK that the SIN/name/date of birth fields are unique together
                    UpdateEmployee(newGuy, "FULLTIME");
                }
                else
                {
                    //tell user employee could not be entered
                }
            }
            else//part-time
            {
                employeeDateOfHire = tbDateOfHire.Text;
                ParttimeEmployee newGuy = new ParttimeEmployee();

                if (!newGuy.SetFirstName(employeeFirstName))
                {
                    isValid = false;
                    lbFirstName.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbFirstName.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetLastName(employeeLastName))
                {
                    isValid = false;
                    lbLastName.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbLastName.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetSin(employeeSIN))
                {
                    isValid = false;
                    lbSIN.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbSIN.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetCompany(employeeCompany))
                {
                    isValid = false;
                    lbCompany.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbCompany.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetDateofHire(employeeDateOfHire))
                {
                    isValid = false;
                    lbDateOfHire.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbDateOfHire.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetDateOfBirth(employeeDateOfBirth))
                {
                    isValid = false;
                    lbDateOfBirth.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbDateOfBirth.ForeColor = System.Drawing.Color.Black;
                }

                if (!newGuy.SetDateofHire(employeeDateOfHire))
                {
                    isValid = false;
                    lbDateOfHire.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbDateOfHire.ForeColor = System.Drawing.Color.Black;
                }

                if (isValid)
                {
                    //enter employee into database as a general user
                    //MUST ALSO CHECK that the SIN/name/date of birth fields are unique together
                    UpdateEmployee(newGuy, "PARTTIME");
                }
                else
                {
                    //tell user employee could not be entered
                }
            }

        }


        protected bool UpdateEmployee(Employee newGuy, string employeeType)
        {
            bool success = true;
            string ipAddress = "localhost";
            string portNumber = "3306";
            string dataBaseName = "emspss";
            string userName = "emspss";
            string password = "Fattymilk123";

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

                        string query = "UPDATE Employee SET hiringCompanyName = '" + newGuy.Company + "', employFirstName = '" + newGuy.FirstName +
                            "', employLastName = '" + newGuy.LastName + "', employSIN = '" + newGuy.Sin + 
                            "', employeeStatus = '" + employeeStatus + "', employeeType = '" + employeeType + 
                            "', dateOfHire = '" + newGuy.DateOfHire.ToString("yyyy-MM-dd") + 
                            "', dateOfTerm = '" + newGuy.DateofTermination.ToString("yyyy-MM-dd") + 
                            "', dateOfBirth = '" + newGuy.DateOfBirth.ToString("yyyy-MM-dd") + 
                            "' WHERE eId = " + eid + ";";
                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                        // Connection has been made

                        try
                        {
                            command.ExecuteNonQuery();

                            lbMessage.Text = "Update on employee was successful!";
                        }
                        catch
                        {
                            //insert did not work
                            lbMessage.Text = "Update on employee was not successful!";
                            success = false;
                            break;
                        }

                        break;

                    case System.Data.ConnectionState.Closed:
                        // Connection could not be made
                        success = false;
                        break;

                    default:
                        // Connection is actively doing something
                        break;

                }
            }
            catch
            {
                lbMessage.Text = "Update on employee was not successful!!";
                success = false;
            }
            finally
            {
                if (mySqlConnection.State != System.Data.ConnectionState.Closed)
                {
                    // Close the connection as a good Garbage Collecting practice
                    mySqlConnection.Close();
                }
            }

            return success;
        }


        public bool UpdateSeasonalEmployee(SeasonalEmployee newGuy)
        {
            bool success = true;
            string ipAddress = "localhost";
            string portNumber = "3306";
            string dataBaseName = "emspss";
            string userName = "emspss";
            string password = mysqlPass;
            string dateBuilder = newGuy.SeasonYear;
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

                        string query = "UPDATE SeasonalEmployee SET season = '" + newGuy.SeasonYear + "' WHERE eId = " + eid + ";"; 


                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);

                        command.CommandText = query;

                        try
                        {
                            command.ExecuteNonQuery();

                            lbMessage.Text = "Update on seasonal employee was successful!";
                        }
                        catch
                        {
                            //insert did not work
                            lbMessage.Text = "Update on seasonal employee was not successful!";
                            success = false;
                            break;
                        }

                        break;

                    case System.Data.ConnectionState.Closed:
                        // Connection could not be made
                        lbMessage.Text = "Update on seasonal employee was not successful!";
                        success = false;
                        break;

                    default:
                        // Connection is actively doing something
                        break;
                }

            }
            catch
            {
                lbMessage.Text = "Update on seasonal employee was not successful!";
                success = false;
            }
            finally
            {
                if (mySqlConnection.State != System.Data.ConnectionState.Closed)
                {
                    // Close the connection as a good Garbage Collecting practice
                    mySqlConnection.Close();
                }
            }

            return success;
        }
        
    }
}