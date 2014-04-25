using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using AllEmployees;

namespace EMS_PSS
{
    public partial class WeeklyHoursWorked : System.Web.UI.Page
    {
        protected List<string> workWeeks = new List<string>();
        protected Dictionary<string, List<Dictionary<string, string>>> employees = new Dictionary<string, List<Dictionary<string, string>>>();

        protected void Page_Load(object sender, EventArgs e)
        {


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

                        string query = "SELECT StartDate FROM workweek;";
                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                        // Connection has been made
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                workWeeks.Add(reader.GetDateTime(0).ToShortDateString());

                            }
                        }

                        if (Request.QueryString["workWeek"] != null)
                        {

                            query = "SELECT employFirstName, employLastName, employSIN, employeeStatus, employeeType, hiringCompanyName, IFNULL(( SELECT (HoursMonday + HoursTuesday + HoursWednesday + HoursThursday + HoursFriday) FROM WeeklyTimeCard WHERE WeeklyTimeCard.EId = Employee.eId AND StartDate=@startDate LIMIT 1 ), 0) AS HoursWorked FROM Employee ORDER BY HoursWorked DESC, employLastName DESC";
                            command = new MySqlCommand(query, mySqlConnection);
                            command.Parameters.AddWithValue("@startDate", Request.QueryString["workWeek"]);
                            // Connection has been made
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Dictionary<string, string> employee = new Dictionary<string, string>();

                                    string hiringCompany = reader.GetString(5);
                                    try
                                    {
                                        employees.Add(hiringCompany, new List<Dictionary<string, string>>());
                                    }
                                    catch (ArgumentException)
                                    {
                                        // Company is already in the dict
                                    }

                                    employee.Add("FirstName", reader.GetString(0));
                                    employee.Add("LastName", reader.GetString(1));
                                    employee.Add("SIN", reader.GetString(2));
                                    employee.Add("EmployeeType", reader.GetString(4));
                                    employee.Add("NumHoursWorked", reader.GetInt32(6).ToString());

                                    employees[hiringCompany].Add(employee);

                                }
                            }
                        }
                        
                        App_Code.Log l = new App_Code.Log();
                        l.Action = "RAN WEEKLY HOURS REPORT";
                        l.UserId = (string)Session["userId"];

                        new App_Code.AuditLogModel().InsertAuditLog(l);
                        break;

                    case System.Data.ConnectionState.Closed:
                        // Connection could not be made

                        break;

                    default:
                        // Connection is actively doing something
                        break;

                }
            }
            catch (Exception mysqlError)
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