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
    public partial class SeniorityReport : System.Web.UI.Page
    {
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
            RunReport();
        }

        protected void RunReport()
        {
            List<string> companies = new List<string>();
            List<List<string>> company = new List<List<string>>();
            string ipAddress = "localhost";
            string portNumber = "3306";
            string dataBaseName = "emspss";
            string userName = "root";
            string password = "admin";

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

                        string query = "SELECT DISTINCT hiringCompanyName FROM Employee;";
                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                        // Connection has been made
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    companies.Add(reader.GetString(0));//read all the table names into a buffer
                                }
                                catch
                                {
                                }
                            }
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

            foreach (string comp in companies)
            {
                string tempComp = comp;
                if(tempComp.Contains("\'"))
                {
                    tempComp = tempComp.Replace("\'", "\\\'");
                }
                try
                {
                    mySqlConnection.Open();

                    switch (mySqlConnection.State)
                    {
                        case System.Data.ConnectionState.Open:

                            string query = "SELECT employLastName, employFirstName, employSIN, employeeType, dateOfHire, employeeStatus FROM Employee WHERE hiringCompanyName = '" + tempComp + "';";
                            MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                            // Connection has been made
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                   try
                                    {
                                        if (reader[5].ToString() == "ACTIVE")
                                        {
                                            List<string> employee = new List<string>();

                                            employee.Add(reader[0].ToString());
                                            employee.Add(reader[1].ToString());
                                            employee.Add(reader[2].ToString());
                                            if (reader[3].ToString() == "FULLTIME")
                                            {
                                                employee.Add("FullTime");
                                            }
                                            else if (reader[3].ToString() == "PARTTIME")
                                            {
                                                employee.Add("PartTime");
                                            }
                                            else if (reader[3].ToString() == "SEASONAL")
                                            {
                                                employee.Add("Seasonal");
                                            }
                                            else if (reader[3].ToString() == "CONTRACT")
                                            {
                                                employee.Add("Contract");
                                            }
                                            employee.Add(((DateTime)reader[4]).ToString("yyyy-MM-dd"));
                                            company.Add(employee);
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }

                            int nowYear = DateTime.Now.Year;
                            int nowMonth = DateTime.Now.Month;
                            int nowDay = DateTime.Now.Day;

                            report.InnerHtml += "<b>Seniority Report</b>     (" + comp + ") .</br><table border = 2>" +
                                "<tr><td>Employee Name</td><td>SIN</td><td>Type</td><td>Date of Hire</td><td>Years of Service</td></tr>";
                            foreach (List<string> employee in company)
                            {
                                string service = "";
                                int startYear;
                                Int32.TryParse(employee[4].Substring(0, 4), out startYear);
                                int startMonth;
                                Int32.TryParse(employee[4].Substring(5, 2), out startMonth);
                                int startDay;
                                Int32.TryParse(employee[4].Substring(8, 2), out startDay);
                                if (nowYear - startYear > 1)
                                {
                                    service = (nowYear - startYear) + " years";
                                }
                                else if (nowYear - startYear == 1)
                                {
                                    if (nowMonth - startMonth < 0)
                                    {
                                        service = (nowMonth - startMonth + 12) + " months";
                                    }
                                    else
                                    {
                                        service = "1 year";
                                    }
                                }
                                if (nowYear - startYear == 0)
                                {
                                    if (nowMonth - startMonth + 12 < 11)
                                    {
                                        service = (nowMonth - startMonth + 12) + " months";
                                    }
                                    else if (nowMonth - startMonth + 12 == 11)
                                    {
                                        service = "1 month";
                                    }
                                    else
                                    {
                                        service = (nowDay - startDay + DateTime.DaysInMonth(nowYear, nowMonth)) + " days";
                                    }
                                }

                                if (employee[0] != "")
                                {
                                    report.InnerHtml += "<tr><td>" + employee[0] + ", " + employee[1] + "</td><td>" +
                                        employee[2] + "</td><td>" + employee[3] + "</td><td>" + employee[4] + "</td><td>" + service + "</td></tr>";
                                }
                                else
                                {
                                    report.InnerHtml += "<tr><td>" + employee[1] + "</td><td>" +
                                        employee[2] + "</td><td>" + employee[3] + "</td><td>" + employee[4] + "</td><td>" + service + "</td></tr>";
                                }
                            }
                            report.InnerHtml += "</table></br></br>";

                            company = new List<List<string>>();

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
        }



    }
}