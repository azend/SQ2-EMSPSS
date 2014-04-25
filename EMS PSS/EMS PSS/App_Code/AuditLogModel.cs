using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace EMS_PSS.App_Code
{
    public class AuditLogModel
    {

        public void InsertAuditLog(Log l)
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

                        string query = "INSERT INTO AuditLog (eId, action, userId, attributeChanged, oldValue, newValue, eventTime) " +
                                        "VALUES (@eId, @action, @userId, @attributeChanged, @oldValue, @newValue, @eventTime)";
                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                        command.Parameters.AddWithValue("@eId", l.EmployeeId);
                        command.Parameters.AddWithValue("@action", l.Action);
                        command.Parameters.AddWithValue("@userId", l.UserId);
                        command.Parameters.AddWithValue("@attributeChanged", l.AttributeChanged);
                        command.Parameters.AddWithValue("@oldValue", l.OldValue);
                        command.Parameters.AddWithValue("@newValue", l.NewValue);
                        command.Parameters.AddWithValue("@eventTime", l.EventTime);
                        // Connection has been made

                        command.ExecuteNonQuery();
                        

                        break;

                    case System.Data.ConnectionState.Closed:
                        // Connection could not be made

                        break;

                    default:
                        // Connection is actively doing something
                        break;

                }
            }
            catch (Exception e)
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
        public IEnumerable<Log> GetAuditLogs()
        {
            List<Log> logs = new List<Log>();

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

                        string query = "SELECT auditLogId, eId, action, userId, attributeChanged, oldValue, newValue, eventTime FROM AuditLog;";
                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                        // Connection has been made
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Log log = new Log();

                                log.LogId = reader.GetInt32(0);

                                if (!reader.IsDBNull(1))
                                {
                                    log.EmployeeId = reader.GetInt32(1);
                                }

                                if (!reader.IsDBNull(2))
                                {
                                    log.Action = reader.GetString(2);
                                }

                                if (!reader.IsDBNull(3))
                                {
                                    log.UserId = reader.GetString(3);
                                }

                                if (!reader.IsDBNull(4))
                                {
                                    log.AttributeChanged = reader.GetString(4);
                                }

                                if (!reader.IsDBNull(5))
                                {
                                    log.OldValue = reader.GetString(5);
                                }

                                if (!reader.IsDBNull(6))
                                {
                                    log.NewValue = reader.GetString(6);
                                }

                                if (!reader.IsDBNull(7))
                                {
                                    log.EventTime = reader.GetDateTime(7);
                                }
                                
                                logs.Add(log);


                            }
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
            catch (Exception e)
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



            return logs;
        }
    }
}