/** Program name: EMS
 * @file Employee.cs
 * @author Constantine Grigoriadis
 * @author Kelson Conyard
 * @author Richard Meijer
 * @author Sean Jellicoe
 * Date: November 14, 2013
 * @brief Parent class for employees, contains all information that is common across
 * all employees.
 */




using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using Supporting;




namespace AllEmployees
{
    public abstract class Employee
    {
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string employeeType= string.Empty;
        private string sin= string.Empty;
        private string company = "";
        private DateTime dateOfHire;
        private DateTime dateOfTermination;
        private DateTime dateOfBirth;
        readonly string[] EmployeeTypes = {"FT","PT","SN","CT"};

        //accessors start
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Sin
        {
            get { return sin; }
            set { sin = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        public string EmployeeType
        {
            get { return employeeType; }
            set { employeeType = value; }
        }
        public string Company
        {
            get { return company; }
            set { company = value; }
        }
        public DateTime DateOfHire
        {
            get { return dateOfHire; }
            set { dateOfHire = value; }
        }
        public DateTime DateofTermination
        {
            get { return dateOfTermination; }
            set { dateOfTermination = value; }
        }
        //accessors end

        public Employee()
        {
        }

        public Employee(string firstName, string lastName)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
        }
        /// <summary>
        /// Constructor that takes full details
        /// </summary>
        /// <param name="fName"> Employees first name </param>
        /// <param name="lName"> Employees last name </param>
        /// <param name="sNum"> Employees SIN NUMBER </param>
        /// <param name="dBirth"> Employees date of birth </param>
        public Employee(string fName, string lName, string sNum, string dBirth, string company)
        {
            SetFirstName(fName);
            SetLastName(lName);
            SetSin(sNum);
            SetDateOfBirth(dBirth);
            SetCompany(company);
        }

        public bool SetCompany(string tempCompany)
        {
            bool returnVal = false;

            if (tempCompany != "")
            {
                returnVal = true;
                company = tempCompany;
            }

            return returnVal;
        }

        /// <summary>
        /// Method name: SetFirstName
        /// 
        /// Purpose: Ensures the attribute firstName will only contain
        /// letters a-z or a ' or a -.  It Can also be blank.
        /// 
        /// Returns: true if valid, false if not
        /// </summary>
        /// <param name="tempName"></param>
        /// <returns></returns>
        public bool SetFirstName(string tempName)
        {
            if (Regex.IsMatch(tempName, "^[a-zA-Z'-]{1,20}$"))
            {
                FirstName = tempName;
                //Logging.Log("Employee.SetFirstName", "First Name Set (" + FirstName + ") - VALID");
                return true;
            }
            else if (tempName == "")
            {
                //Logging.Log("Employee.SetFirstName", "First Name Set (" + FirstName + ") - VALID");
                return true;
            }
            else
            {
                //Logging.Log("Employee.SetFirstName", "First Name Set (" + tempName + ") - INVALID");
                return false;
            }
        }



        /// <summary>
        /// Method name: SetLastName
        /// 
        /// Purpose: Validates the lastName attribute.  Ensures it can only
        /// contain letters a-z, a -, or a '.  Can also be blank.
        /// 
        /// Returns: true if valid, false if not
        /// </summary>
        /// <param name="tempName"></param>
        /// <returns></returns>
        public bool SetLastName(string tempName)
        {
            if (Regex.IsMatch(tempName, "^[a-zA-Z'-]{1,20}$"))
            {
                LastName = tempName;
                //Logging.Log("Employee.SetLastName", "Last Name Set (" + LastName + ") - VALID");
                return true;
            }
            else if (tempName == "")
            {
                //Logging.Log("Employee.SetLastName", "Last Name Set (" + LastName + ") - VALID");
                return true;
            }
            else
            {
                //Logging.Log("Employee.SetLastName", "Last Name Set (" + tempName + ") - INVALID");
                return false;
            }
        }



        /// <summary>
        /// Method name: SetDateOfBirth
        /// 
        /// Purpose: This method is used to validate 
        /// date of birth for the base employee class and to inherited 
        ///  
        ///  
        /// Returns: true if valid, false if not
        /// </summary>
        /// <param name="tempName"></param>
        /// <returns></returns>
        public bool SetDateOfBirth(string toValidate)
        {
            bool returnVal = false;
            string expectedFormat = "yyyy-MM-dd";
            bool result = DateTime.TryParseExact(
                toValidate,
                expectedFormat,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out dateOfBirth);
            if (result || toValidate == "")
            {
                returnVal = true;
                //Logging.Log("Employee.SetDateOfBirth", "Date of Birth Set (" + DateOfBirth.ToShortDateString() + ") - VALID");
            }
            else
            {
                //Logging.Log("Employee.SetDateOfBirth", "Date of Birth Set (" + toValidate + ") - INVALID");

                returnVal = false;
            }

            return returnVal;
        }



        /// <summary>
        /// Method name: SetSin
        /// 
        /// Purpose: This method is used to validate 
        /// Sin.  Allows blank or a valid sin.
        /// </summary>
        /// <param name="tempName"></param>
        /// <returns>true if valid, false if not</returns>
        public bool SetSin(string sinNumber)
        {
            bool returnVal = false;

            if (sinNumber.Contains(" "))
            {
                sinNumber = sinNumber.Replace(" ", "");
            }

            if (sinNumber == "" || IsValidSIN(sinNumber))
            {
                Sin = sinNumber;
                returnVal = true;
                //Logging.Log("Employee.SetSin", "Sin Set (" + Sin + ") - VALID");
            }
            else
            {
                Console.WriteLine("SIN is invalid");
                //Logging.Log("Employee.SetSin", "Sin Set (" + sinNumber + ") - INVALID");
            }

            return returnVal;
        }



        /// <summary>
        /// Method name: IsValidSIN
        /// 
        /// Purpose: Check if a SIN Number is valid
        /// </summary>
        /// <param name="sin"> The SIN number to validate </param>
        /// <returns> Whether or not the SIN was valid </returns>
        protected bool IsValidSIN(string sinNumber)
        {
            if (!Regex.IsMatch(sinNumber, @"^\d{3} {0,1}\d{3} {0,1}\d{3}$"))
            {
                return false;
            }

            int[] digits = new int[9];

            try
            {
                for (int i = 0; i < 9; i++)
                {
					digits[i] = int.Parse(sinNumber.ElementAt(i).ToString());
                }
            }
            catch
            {
                return false;
            }

            int checkSum = 0;

            for (int i = 0; i < 7; i += 2)
            {
                checkSum += digits[i];
                checkSum += (digits[i + 1] * 2) / 10 + (digits[i + 1] * 2) % 10;
            }

            checkSum += digits[8];

            if (checkSum % 10 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 
        /// Method name: ValidateEmployeeType
        /// 
        /// Purpose: to validate employeeType,
        /// Ensures the value is one of FT , PT , CT , SN .
        /// </summary>
        /// <param name="toValidate"></param>
        /// <returns>A bool representing pass or fail.</returns>
        public bool ValidateEmployeeType(string toValidate)
        {
            bool returnVal = false;
            foreach (string EmployeeType in EmployeeTypes)
            {
                //make sure the value is one of four seasons

                if (EmployeeType == toValidate) // check the string against the employeeType
                {
                    employeeType = toValidate;
                    returnVal = true;
                }
                else
                {
                    
                }
            }
            if (returnVal == false)
            {
                //Logging.Log("Employee.ValidateEmployeeType", "Employee Type (" + toValidate + ") - INVALID");
            }
            return returnVal;

        }

        /// <summary>
        /// Method name: Details
        /// 
        /// Purpose: Forces children classes to declare this method..
        /// </summary>
        public virtual void Details()
        {
        }

        /// <summary>
        /// Formats the SIN number to be displayed properly
        /// </summary>
        /// <returns> The formatted SIN number</returns>
        public virtual string GetFormattedSin()
        {
            string displaySin = Sin;

            if (displaySin != string.Empty)
            {
                displaySin = displaySin.Substring(0, 3) + " " + displaySin.Substring(3, 3) + " " + displaySin.Substring(6, 3);
            }
            else
            {
                displaySin = "N/A";
            }

            return displaySin;
        }

        public abstract string ToFileString();
        /// <summary>
        /// Checks if an employee is valid
        /// </summary>
        /// <returns> True if the employee is valid, false otherwhise</returns>
        public abstract bool Validate();

        
    }
}
