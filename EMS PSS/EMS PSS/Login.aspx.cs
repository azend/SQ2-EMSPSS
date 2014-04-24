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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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

                ConnectToDatabase(name, pass);
                //connect to database, check if userName/password combination is correct
                //if correct, pass them to page depending what type of user they are

                //if not correct, bring them back to login page displaying that their userName/password is not correct
            }
            else
            {
                if (name == "")
                {
                    lbUserName.ForeColor = System.Drawing.Color.Red;
                    lbErrorMessage.Text = "Connection could not be made to the database.";
                }

                if (pass == "")
                {
                    lbPassword.ForeColor = System.Drawing.Color.Red;
                }
            }  
        }

        protected bool ConnectToDatabase(string name, string pass)
        {
            string found = "";
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

                        string query = "SELECT userID, userPassword " +
                                       "FROM EMSUser " +
                                       "WHERE userID = " + name +
                                       " AND userPassword = " + pass + ";";
                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                        // Connection has been made
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                found = reader.GetString(0);//read all the table names into a buffer
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

            if (found != "")
            {
                //user is correct
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}