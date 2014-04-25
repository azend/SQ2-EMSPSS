using AllEmployees;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS_PSS
{
    public partial class TimeCardEntry : System.Web.UI.Page
    {
        private string userID;
        private string firstName;
        private string lastName;
        private string userType;

        private static DateTime WeekStartDate;




        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void Workweek_SelectedIndexChanged(object sender, EventArgs e)
        {

            string[] lines = Workweek.SelectedItem.Text.ToString().Split('-');
            DateTime startTime = DateTime.Parse(lines[0]);
            string query = "select HoursMonday, HoursTuesday, HoursWednesday, HoursThursday, HoursFriday, HoursSaturday, HoursSunday from WeeklyTimeCard";
        }





        protected bool AddNewWorkWeek(DateTime StartOfWeek)
        {
            string ipAddress = "localhost";
            string portNumber = "3306";
            string dataBaseName = "emspss";
            string userName = "emspss";
            string password = "Fattymilk123";
            bool success = false;
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
                        DateTime EndOfWeek = StartOfWeek.AddDays(6);

                        string query = "INSERT INTO workweek (StartDate, EndDate) Values( "
                            + "'" + StartOfWeek.ToString("yyyy-MM-dd") + "'" + " , " + "'" + EndOfWeek.ToString("yyyy-MM-dd") + "'" + ");";

                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                        // Connection has been made

                        try
                        {
                            command.ExecuteNonQuery();

                            lbMessage.Text = "New work week added successfully!";
                        }
                        catch
                        {
                            //insert did not work
                            lbMessage.Text = "Work Week failed to insert!";
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
                lbMessage.Text = "adding a work week was not successful!";
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

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (StartOfWeek.SelectedDate.Date.DayOfWeek == DayOfWeek.Monday)
            {
                WeekStartDate = StartOfWeek.SelectedDate.Date;
                lbMessage.Text = "";
            }
            else
            {
                lbMessage.Text = "The date selected is not a monday";
            }
        }

        protected void TimecardPage_Click(object sender, EventArgs e)
        {
            TimeCardForm.Visible = true;
            EnterNewWorkWeek.Visible = false;
            Workweek.Items.Clear();
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

                        string query = "select StartDate,EndDate from workweek order by startDate desc;";
                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                        // Connection has been made
                        try
                        {
                            MySqlDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {

                                string startOfWeek = ((DateTime)reader[0]).ToString("yyyy/MM/dd");
                                string endOfWeek = ((DateTime)reader[1]).ToString("yyyy/MM/dd");
                                ListItem newItem = new ListItem();
                                string DateRange = startOfWeek + "-" + endOfWeek;
                                newItem.Text = DateRange;
                                Workweek.Items.Add(newItem);
                            }
                            reader.Close();
                            lbMessage.Text = "";
                        }
                        catch
                        {
                            //insert did not work
                            lbMessage.Text = "Problems Loading dropdown!";
                            break;
                        }

                        break;

                    case System.Data.ConnectionState.Closed:
                        // Connection could not be made

                        break;

                    default:
                        // Connection is actively doing something
                        break;

                }
            }
            catch
            {
                lbMessage.Text = "Insert into employee was not successful!";
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

        protected void WeekEntryPage_Click(object sender, EventArgs e)
        {
            TimeCardForm.Visible = false;
            EnterNewWorkWeek.Visible = true;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            bool success = false;
            try
            {
                double.Parse(MondayHours.Text);
                double.Parse(TuesdayHours.Text);
                double.Parse(WednesdayHours.Text);
                double.Parse(ThursdayHours.Text);
                double.Parse(FridayHours.Text);
                double.Parse(SaturdayHours.Text);
                double.Parse(SundayHours.Text);

                if (EnterNewWorkWeek.Visible)
                {
                    success = AddNewWorkWeek(WeekStartDate);
                }
                else if (TimeCardForm.Visible)
                {
                    string query = "insert into WeeklyTimeCard(HoursMonday,HoursTuesday,HoursWednesday,HoursThursday,HoursFriday,HoursSaturday,HoursSunday,EId,StartDate)";
                    string[] lines = Workweek.SelectedItem.Text.ToString().Split('-');
                    DateTime startTime = DateTime.Parse(lines[0]);
                    query += " values(" + MondayHours.Text + ","
                    + TuesdayHours.Text+"," + WednesdayHours.Text + "," + ThursdayHours.Text + ","
                    + FridayHours.Text + "," + SaturdayHours.Text + "," + SundayHours.Text+",";
                    query += EmployeeId.Text + ", '" + startTime.ToString("yyyy-MM-dd") + "');";
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

                                MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                                // Connection has been made
                                try
                                {
                                    command.ExecuteNonQuery();
                                    lbMessage.Text = "Time card entry was a success!";
                                }
                                catch(Exception except)
                                {
                                    //insert did not work
                                    lbMessage.Text = "Problems Loading dropdown!";
                                    break;
                                }
                                break;

                            case System.Data.ConnectionState.Closed:
                                // Connection could not be made

                                break;

                            default:
                                // Connection is actively doing something
                                break;

                        }
                    }
                    catch
                    {
                        lbMessage.Text = "Insert into Time was not successful attempting to update!";
                        query = "UPDATE WeeklyTimeCard SET";
                        query += "HoursMonday=" + "" + MondayHours.Text + ", ";
                        query += "HoursTuesday=" + "" + TuesdayHours.Text + ", ";
                        query += "HoursWednesday=" + "" + WednesdayHours.Text + ", ";
                        query += "HoursThursday=" + "" + ThursdayHours.Text + ", ";
                        query += "HoursFriday=" + "" + FridayHours.Text + ",";
                        query += "HoursSaturday=" + "" + SaturdayHours.Text + ", ";
                        query += "HoursSunday=" + "" + SundayHours.Text + ", ";
                        string[] line = Workweek.SelectedItem.Text.ToString().Split('-');
                        DateTime startdate = DateTime.Parse(line[0]);
                        query += "where EId=" + EmployeeId.Text + " and startDate=" + "'"+startdate.ToString("yyyy-MM-dd")+"'";
                        try
                        {
                            mySqlConnection.Open();
                            if (mySqlConnection.State == mySqlConnection.State)
                            {
                                MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            lbMessage.Text = "The employee id was not found in the database";
                        }
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
            catch (Exception exe)
            {
                lbMessage.Text = "All Timecard hours must be either decimals or integers";
            }  
   }
    }
}