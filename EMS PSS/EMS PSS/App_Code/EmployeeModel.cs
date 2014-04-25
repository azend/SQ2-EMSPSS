using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using AllEmployees;

namespace EMS_PSS.App_Code
{
    public class EmployeeModel
    {

        public void InsertEmployee(string FirstName, string LastName, string SIN, string DateOfBirth, string EmployeeType, string Company)
        {

        }

        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

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
                        Employee employee = null;

                        string query = "SELECT eId, hiringCompanyName, employFirstName, employLastName, employSIN, employeeStatus, employeeType, dateOfBirth FROM Employee;";
                        MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                        // Connection has been made
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employee = null;
                                string employeeStatus = reader.GetString(5);
                                string employeeType = reader.GetString(6);

                                //if (employeeStatus.Equals("ACTIVE"))
                                //{
                                    switch (employeeType)
                                    {
                                        case "FULLTIME":
                                            employee = new FulltimeEmployee();
                                            break;
                                        case "PARTTIME":
                                            employee = new ParttimeEmployee();
                                            break;
                                        case "SEASONAL":
                                            employee = new SeasonalEmployee();
                                            break;
                                        case "CONTRACT":
                                            employee = new ContractEmployee();
                                            break;
                                    }

                                    if (employee != null)
                                    {
                                        employee.SetFirstName(reader.GetString(2));
                                        employee.SetLastName(reader.GetString(3));
                                        employee.SetSin(reader.GetString(4));

                                        if (!reader.IsDBNull(7))
                                        {
                                            employee.SetDateOfBirth((reader.GetDateTime(7)).ToShortDateString());
                                        }
                                        

                                        employees.Add(employee);
                                    }
                                //}
                                
                                
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
            catch(Exception e)
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

            

            return employees;
        }
    }
}