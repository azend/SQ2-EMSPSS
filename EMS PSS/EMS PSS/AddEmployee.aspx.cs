using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using System.Data.Odbc;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace EMS_PSS
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        string ipAddress = "localhost";
        string portNumber = "3306";
        string dataBaseName = "emspss";
        string userName = "root";
        string password = "admin";



        protected void Page_Load(object sender, EventArgs e)
        {
            string ConnectionString = "server=" + ipAddress + ";port=" + portNumber +
            ";userid=" + userName +
            ";password=" + password +
            ";database=" + dataBaseName + ";";
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection = new

            MySql.Data.MySqlClient.MySqlConnection();

            mySqlConnection.ConnectionString = ConnectionString;


            try
            {

                mySqlConnection.Open();

                switch (mySqlConnection.State)
                {

                    case System.Data.ConnectionState.Open:

                        string query = "select firstname from EMSUser";
                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                        // Connection has been made
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Response.Write(reader.GetString(0)); //read all the table names into a buffer
                            }
                        }

                        break;

                    case System.Data.ConnectionState.Closed:

                        // Connection could not be made, throw an error

                        throw new Exception("The database connection state is Closed");

                        break;

                    default:
                        // Connection is actively doing something
                        break;

                }
                // Place Your Code Here to Process Data //
            }
            catch (MySql.Data.MySqlClient.MySqlException mySqlException)
            {
                // Use the mySqlException object to handle specific MySql errors
            }
            catch (Exception exception)
            {
                // Use the exception object to handle all other non-MySql specific errors
            }
            finally
            {
                // Make sure to only close connections that are not in a closed state
                if (mySqlConnection.State != System.Data.ConnectionState.Closed)
                {
                    // Close the connection as a good Garbage Collecting practice
                    mySqlConnection.Close();
                }
            }
        }
    }
}