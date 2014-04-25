using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using AllEmployees;

namespace EMS_PSS
{
    public partial class CreateEmployee : System.Web.UI.Page
    {
        private const string mysqlPass = "password";
        private string userID;
        private string firstName;
        private string lastName;
        private string userType;
        private string employeeFirstName;
        private string employeeLastName;
        private string employeeType;
        private string employeeCompany;
        private string employeeSIN;
        private string employeeDateOfBirth;
        private string employeeDateOfHire;
        private string employeeSeason;
        private string employeeYear;



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
                    if (InsertIntoEmployee(newGuy, "SEASONAL"))
                    {
                        InsertIntoSeasonalEmployee(newGuy);
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
                    if (InsertIntoEmployee(newGuy, "FULLTIME"))
                    {
                        InsertIntoFullTimeEmployee(newGuy);
                    }
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
                    if (InsertIntoEmployee(newGuy, "PARTTIME"))
                    {
                        InsertIntoPartTimeEmployee(newGuy);
                    }
                }
                else
                {
                    //tell user employee could not be entered
                }
            }

        }


        protected bool InsertIntoEmployee(Employee newGuy, string employeeType)
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

                        string query = "INSERT INTO Employee " +
                            "(hiringCompanyName, employFirstName, employLastName, employSIN, employeeStatus, employeeType, dateOfHire, dateOfTerm, dateOfBirth) " +
                            "VALUES (" +
                            "'" + newGuy.Company + "', " +
                            "'" + newGuy.FirstName + "', " +
                            "'" + newGuy.LastName + "', " +
                            "'" + newGuy.Sin + "', " +
                            "'INCOMPLETE', " +
                            "'" + employeeType + "', " +
                            "'" + newGuy.DateOfHire.ToString("yyyy-MM-dd") + "', " +
                            "'" + newGuy.DateofTermination.ToString("yyyy-MM-dd") + "', " +
                            "'" + newGuy.DateOfBirth.ToString("yyyy-MM-dd") + "');";
                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                        // Connection has been made

                        try
                        {
                            command.ExecuteNonQuery();

                            App_Code.Log l = new App_Code.Log();
                            l.EmployeeId = (int)command.LastInsertedId;
                            l.Action = "CREATE";

                            new App_Code.AuditLogModel().InsertAuditLog(l);

                            lbMessage.Text = "Insert into employee was successful!";
                        }
                        catch
                        {
                            //insert did not work
                            lbMessage.Text = "Insert into employee was not successful!";
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
                lbMessage.Text = "Insert into employee was not successful!!";
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

        public bool InsertIntoFullTimeEmployee(FulltimeEmployee newGuy)
        {
            bool success = true;
            string ipAddress = "localhost";
            string portNumber = "3306";
            string dataBaseName = "emspss";
            string userName = "root";
            string password = mysqlPass;
            string employID;
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

                        string query = "SELECT eID FROM Employee WHERE " +
                                        "employFirstName = '" + newGuy.FirstName + "' AND " +
                                        "employLastName = '" + newGuy.LastName + "' AND " +
                                        "employSIN = '" + newGuy.Sin + "' AND " +
                                        "employeeType = 'FULLTIME';";

                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    employID = reader.GetString(0);

                                    query = "INSERT INTO FullTimeEmployee (EId) VALUES (" +
                                        employID + ");";
                                }
                                catch
                                {
                                    lbMessage.Text = "Insert into full time employee was not successful!";
                                    success = false;

                                    break;
                                }


                            }

                        }

                        command.CommandText = query;

                        try
                        {
                            command.ExecuteNonQuery();

                            lbMessage.Text = "Insert into full time employee was successful!";
                        }
                        catch
                        {
                            //insert did not work
                            lbMessage.Text = "Insert into full time employee was not successful!";
                            success = false;
                            break;
                        }

                        break;

                    case System.Data.ConnectionState.Closed:
                        // Connection could not be made
                        lbMessage.Text = "Insert into full time employee was not successful!";
                        success = false;
                        break;

                    default:
                        // Connection is actively doing something
                        break;
                }

            }
            catch
            {
                lbMessage.Text = "Insert into full time employee was not successful!";
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



        public bool InsertIntoPartTimeEmployee(ParttimeEmployee newGuy)
        {
            bool success = true;
            string ipAddress = "localhost";
            string portNumber = "3306";
            string dataBaseName = "emspss";
            string userName = "root";
            string password = mysqlPass;
            string employID;
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

                        string query = "SELECT eID FROM Employee WHERE " +
                                        "employFirstName = '" + newGuy.FirstName + "' AND " +
                                        "employLastName = '" + newGuy.LastName + "' AND " +
                                        "employSIN = '" + newGuy.Sin + "' AND " +
                                        "employeeType = 'PARTTIME';";

                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    employID = reader.GetString(0);

                                    query = "INSERT INTO PartTimeEmployee (EId) VALUES (" +
                                        employID + ");";
                                }
                                catch
                                {
                                    lbMessage.Text = "Insert into part time employee was not successful!";
                                    success = false;

                                    break;
                                }


                            }

                        }

                        command.CommandText = query;

                        try
                        {
                            command.ExecuteNonQuery();

                            lbMessage.Text = "Insert into part time employee was successful!";
                        }
                        catch
                        {
                            //insert did not work
                            lbMessage.Text = "Insert into part time employee was not successful!";
                            success = false;
                            break;
                        }

                        break;

                    case System.Data.ConnectionState.Closed:
                        // Connection could not be made
                        lbMessage.Text = "Insert into part time employee was not successful!";
                        success = false;
                        break;

                    default:
                        // Connection is actively doing something
                        break;
                }

            }
            catch
            {
                lbMessage.Text = "Insert into part time employee was not successful!";
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


        public bool InsertIntoSeasonalEmployee(SeasonalEmployee newGuy)
        {
            bool success = true;
            string ipAddress = "localhost";
            string portNumber = "3306";
            string dataBaseName = "emspss";
            string userName = "root";
            string password = mysqlPass;
            string employID;
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

                        string query = "SELECT eID FROM Employee WHERE " +
                                        "employFirstName = '" + newGuy.FirstName + "' AND " +
                                        "employLastName = '" + newGuy.LastName + "' AND " +
                                        "employSIN = '" + newGuy.Sin + "' AND " +
                                        "employeeType = 'SEASONAL';";


                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    employID = reader.GetString(0);

                                    query = "INSERT INTO SeasonalEmployee (EId, season) VALUES (" +
                                        employID + ", '" +
                                        dateBuilder + "');";
                                }
                                catch
                                {
                                    lbMessage.Text = "Insert into seasonal employee was not successful!";
                                    success = false;

                                    break;
                                }


                            }

                        }

                        command.CommandText = query;

                        try
                        {
                            command.ExecuteNonQuery();

                            lbMessage.Text = "Insert into seasonal employee was successful!";
                        }
                        catch
                        {
                            //insert did not work
                            lbMessage.Text = "Insert into seasonal employee was not successful!";
                            success = false;
                            break;
                        }

                        break;

                    case System.Data.ConnectionState.Closed:
                        // Connection could not be made
                        lbMessage.Text = "Insert into seasonal employee was not successful!";
                        success = false;
                        break;

                    default:
                        // Connection is actively doing something
                        break;
                }

            }
            catch
            {
                lbMessage.Text = "Insert into seasonal employee was not successful!";
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