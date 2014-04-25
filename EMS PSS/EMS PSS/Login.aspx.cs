/* Program name: EMS-PSS
 * File name: Login.aspx.cs
 * Date: April 24, 2014
 * Programmer's names: Kelson, Sean, Constantine, Richard, Verdi
 * Description: Contains the server side code for the login page of the EMS-PSS web application.
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;




namespace EMS_PSS
{
    public partial class Login : System.Web.UI.Page
    {
        // !Change to match your DB password
        private static string mysqlPass = "admin";
        private static string userType;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /* Method: login_Click
         * Parameters: not used
         * Description: Called when the login button is clicked.  Checks for user name and password text fields to not
         * be blank, then tries to find them in the database.  If found the user type is saved and the user is passed onto
         * the appropriate page.  If the username or password is incorrect the user is brought back to the login page and
         * informed their information was incorrect.
         * Returns: nothing
         */
        protected void login_Click(object sender, EventArgs e)
        {
            string name = userName.Text;
            string pass = password.Text;

            //check userName is not blank and password is not blank
            if (name != "" && pass != "")
            {
                //sets label colors back to black if they were previously red from being blank
                lbUserName.ForeColor = System.Drawing.Color.Black;
                lbPassword.ForeColor = System.Drawing.Color.Black;

                //connect to database, check if userName/password combination is correct
                if (ConnectToDatabase(name, pass))
                {
                    //else if is used for future considerations or other types of users being created
                    //if correct, pass them to page depending what type of user they are
                    if (userType == "GENERAL")
                    {
                        //go to general user page
                       // loginPage.Visible = false;
                        //generalUserPage.Visible = true;
                        Response.Redirect("GeneralUserPage.aspx");
                    }
                    else if (userType == "ADMIN")
                    {
                        //go to admin user page
                        //loginPage.Visible = false;
                        Response.Redirect("AdminPage.aspx");
                    }
                }
                else
                {
                    //if not correct, bring them back to login page displaying that their userName/password is not correct
                    lbErrorMessage.Text = "Username and/or Password were incorrect.";
                }          
            }
            else//username and/or password were blank, will change the labels to red
            {
                if (name == "")
                {
                    lbUserName.ForeColor = System.Drawing.Color.Red;
                }

                if (pass == "")
                {
                    lbPassword.ForeColor = System.Drawing.Color.Red;
                }
            }  
        }



        /* Method: ConnectToDatabase
         * Parameters:
         *      string name - username
         *      string pass - password
         * Description: Connects to the database with the passed name and pass. If found stores the userType into the
         * class string.
         * Returns: boolean - true if user was found within the database, false if not
         */
        protected bool ConnectToDatabase(string name, string pass)
        {
            string type = "";
            string first = "";
            string last = "";
            string id = "";
            string ipAddress = "localhost";
            string portNumber = "3306";
            string dataBaseName = "emspss";
            string userName = "root";
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

                        string query = "SELECT userType, firstName, lastName, userID " +
                                       "FROM EMSUser " +
                                       "WHERE userID = '" + name +
                                       "' AND userPassword = '" + pass + "';";
                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                        // Connection has been made
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    type = reader.GetString(0);//read all the table names into a buffer
                                }
                                catch
                                {
                                }

                                try
                                {
                                    first = reader.GetString(1);
                                }
                                catch
                                {
                                }

                                try
                                {
                                    last = reader.GetString(2);
                                }
                                catch
                                {
                                }

                                try
                                {
                                    id = reader.GetString(3);
                                }
                                catch
                                {
                                }

                                Session["userType"] = type;//this is the userType
                                Session["firstName"] = first;
                                Session["lastName"] = last;
                                Session["userID"] = id;
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

            if (type != "")
            {
                //user exists and password is correct
                userType = type;//used to determine which page to send to
                return true;
            }
            else
            {
                //bad password or username
                return false;
            }
            
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            userName.Text = "";
            password.Text = "";
        }
    }
}