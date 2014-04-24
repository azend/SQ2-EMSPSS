/** Program name: EMS
 * @file ParttimeEmployee.cs
 * @author Constantine Grigoriadis
 * @author Kelson Conyard
 * @author Richard Meijer
 * @author Sean Jellicoe
 * Date: November 30, 2013
 * @brief Child of the Employee, the parttime Employee
 * has 3 additional fields dateOfHire, dateOfTermination, hourlyRate
 */




using System;
using System.Collections.Generic;
using System.Text;
using Supporting;




namespace AllEmployees
{
    public class ParttimeEmployee : Employee
    {
        private DateTime dateOfHire;
        private DateTime dateOfTermination;
        private Double hourlyRate=0;
        public ParttimeEmployee()
        {
            ValidateEmployeeType("PT");
        }

        public ParttimeEmployee(string fName, string lName, string newDateOfBirth, string addSin, string newDateOfHire, string newDateOfTermination, string newHourlyRate)
            : base(fName, lName, newDateOfBirth, addSin)
        {
            ValidateEmployeeType("PT");
            SetDateofHire(newDateOfHire);
            SetDateofTermination(newDateOfTermination);
            SetHourlyRate(newHourlyRate);
        }
        //accessors start
        public Double HourlyRate
        {
            get { return hourlyRate; }
            set { hourlyRate = value; }
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



        /// <summary>
        /// Constructor that only takes the first and last names
        /// </summary>
        /// <param name="fName"> First Name </param>
        /// <param name="lName"> Last Name </param>
        public ParttimeEmployee(string firstName, string lastName)
            : base(firstName, lastName)
        {
            ValidateEmployeeType("PT");
        }



        /// <summary>
        /// Method name: SetDateofTermination
        /// 
        /// Purpose: Validates the dateOfTermination attribute.  Ensures it can only
        /// be in the format yyyy-MM-dd .
        /// 
        /// Returns: true if valid, false if not
        /// </summary>
        /// <param name="toValidate">the string to be parsed.</param>
        /// <returns>A bool indicating pass or fail.</returns>
        public bool SetDateofTermination(string toValidate)
        {
            bool returnVal = false;
            string expectedFormat = "yyyy-MM-dd";
            bool result = DateTime.TryParseExact(
                toValidate,
                expectedFormat,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out dateOfTermination);
            if (result || toValidate == "")
            {
                Logging.Log("ParttimeEmployee.SetDateofTermination", "ParttimeEmployee Set (" + DateofTermination.ToShortDateString() + ") - VALID");
                returnVal = true;
            }
            else
            {
                Logging.Log("ParttimeEmployee.SetDateofTermination", "ParttimeEmployee Set (" + toValidate + ") - INVALID");
                Console.WriteLine("Please enter a valid date in the format yyyy-MM-dd");
                returnVal = false;

            }
            return returnVal;
        }



        /// <summary>
        /// Method name: SetDateofHire
        /// 
        /// Purpose: Validates the dateOfHire attribute.  Ensures it can only
        /// be in the format yyyy-MM-dd .
        /// </summary>
        /// <param name="toValidate">The value to be parsed.</param>
        /// <returns>A bool indicating success or fail.</returns>
        public bool SetDateofHire(string toValidate)
        {
            bool returnVal = false;
            string expectedFormat = "yyyy-MM-dd";
            bool result = DateTime.TryParseExact(
                toValidate,
                expectedFormat,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out dateOfHire);
            if (result || toValidate == "")
            {
                Logging.Log("ParttimeEmployee.SetDateofHire", "ParttimeEmployee Set (" + DateOfHire.ToShortDateString() + ") - VALID");
                returnVal = true;
            }
            else
            {
                Logging.Log("ParttimeEmployee.SetDateofHire", "ParttimeEmployee Set (" + toValidate + ") - INVALID");
                Console.WriteLine("Please enter a valid date in the format yyyy-MM-dd");
                returnVal = false;
            }
            return returnVal;
        }



        /// <summary>
        /// Method name: SetHourlyRate
        /// 
        /// Purpose: Validates the HourlyRate attribute.  Ensures it can only
        /// be greater then 0 dollars
        /// </summary>
        /// <param name="toValidate">The double to validate.</param>
        /// <returns>A bool representing pass or fail.</returns>
        public bool SetHourlyRate(string toValidate)
        {
            bool returnVal = false;

            Double rate;

            Double.TryParse(toValidate, out rate);
            if (rate > 0 || toValidate == "")
            {
                HourlyRate = rate;
                Logging.Log("ParttimeEmployee.SetHourlyRate", "ParttimeEmployee Set (" + HourlyRate.ToString() + ") - VALID");
                returnVal = true;
            }
            else
            {
                Logging.Log("ParttimeEmployee.SetHourlyRate", "ParttimeEmployee Set (" + toValidate + ") - INVALID");
                Console.WriteLine("Please enter a valid number.");
            }
            return returnVal;
        }



        /// <summary>
        /// Method name: Details
        /// 
        /// Purpose: This method dumps the stats for
        /// the part time employee.
        /// Dumps base employee info and
        /// Date of Hire , Date of Termination , hourlyRate
        /// </summary>
        public override void Details()
        {
            Console.WriteLine("First Name : {0}", FirstName);
            Console.WriteLine("Last Name : {0}", LastName);
            Console.WriteLine("Employee Type : {0}", EmployeeType);
            Console.WriteLine("Sin Number : {0}", GetFormattedSin());
            if (DateOfBirth == new DateTime())
            {
                Console.WriteLine("Date Of Birth: N/A");
            }
            else
            {
                Console.WriteLine("Date Of Birth: {0}", DateOfBirth.ToShortDateString());
            }

            if (dateOfHire != new DateTime())
            {
                Console.WriteLine("Date of Hire : {0}", dateOfHire.ToShortDateString());
            }
            else
            {
                Console.WriteLine("Date of Hire : N/A");
            }
            if (dateOfTermination != new DateTime())
            {
                Console.WriteLine("Date of Termination : {0}", dateOfTermination.ToShortDateString());
            }
            else
            {
                Console.WriteLine("Date of Termination : N/A");
            }
            Console.WriteLine("Hourly Rate : {0}", hourlyRate);

            Logging.Log("ParttimeEmployee.Details", "Printed "
                + "First name: " + FirstName + "\n"
                + "Last name: " + LastName + "\n"
                + "Date of Birth: " + DateOfBirth.ToShortDateString() + "\n"
                + "SIN: " + Sin + "\n"
                + "Date of Hire: " + DateOfHire.ToShortDateString() + "\n"
                + "Date of Termination: " + DateofTermination.ToShortDateString() + "\n"
                + "Hourly Rate: " + HourlyRate.ToString());
        }



        /// <summary>
        /// Method name: ToFileString
        /// 
        /// Purpose: This method creates a formatted string 
        /// that is ready to be written to a file
        /// </summary>
        /// <returns>a string to be written to the file</returns>
        public override string ToFileString()
        {
            return EmployeeType + "|" + LastName + "|" + FirstName + "|" + Sin + "|" + DateOfBirth.ToShortDateString() + "|" +
               dateOfHire.ToShortDateString() + "|" +
               dateOfTermination.ToShortDateString() + "|" +
               hourlyRate.ToString() + "|";
        }



        /// <summary>
        /// Method name: Validate
        /// 
        /// Purpose: Checks if the fields form together to form a valid part time employee.
        /// </summary>
        /// <returns>true if valid, false if not</returns>
        public override bool Validate()
        {
            if (FirstName.Length == 0)
            {
                Logging.Log("ParttimeEmployee.Validate", "ParttimeEmployee Validate First Name (" + FirstName + ") - INVALID");
                SetFirstName("");
                return false;
            }

            if (LastName.Length == 0)
            {
                Logging.Log("ParttimeEmployee.Validate", "ParttimeEmployee Validate Last Name (" + LastName + ") - INVALID");
                SetLastName("");
                return false;
            }

            if (DateOfBirth == DateTime.MinValue)
            {
                Logging.Log("ParttimeEmployee.Validate", "ParttimeEmployee Validate Date of Birth (" + DateOfBirth.ToShortDateString() + ") - INVALID");
                return false;
            }

            if (!IsValidSIN(Sin))
            {
                Logging.Log("ParttimeEmployee.Validate", "ParttimeEmployee Validate Sin (" + Sin + ") - INVALID");
                SetSin("");
                return false;
            }

            if (dateOfHire != DateTime.MinValue)
            {
                if (dateOfHire < DateOfBirth)
                {
                    Logging.Log("ParttimeEmployee.Validate", "ParttimeEmployee Validate Date of Hire (" + DateOfHire.ToShortDateString() + ") - INVALID");
                    SetDateOfBirth("");
                    return false;
                }
            }
            else
            {
                Logging.Log("ParttimeEmployee.Validate", "ParttimeEmployee Validate Date of Hire (" + DateOfHire.ToShortDateString() + ") - INVALID");
                return false;
            }

            if (dateOfTermination != DateTime.MinValue)
            {
                if ((dateOfTermination < dateOfHire) || (dateOfTermination < DateOfBirth))
                {
                    Logging.Log("ParttimeEmployee.Validate", "ParttimeEmployee Validate Date of Termination (" + DateofTermination.ToShortDateString() + ") - INVALID");
                    SetDateofTermination("");
                    return false;
                }
            }

            if (hourlyRate <= 0)
            {
                Logging.Log("ParttimeEmployee.Validate", "ParttimeEmployee Validate Hourly Rate (" + HourlyRate.ToString() + ") - INVALID");
                HourlyRate = 0;
                return false;
            }

            Logging.Log("ParttimeEmployee.Validate", "ParttimeEmployee Validate (" + FirstName + ", " + LastName + ", " + Sin.ToString() + ") - VALID");

            return true;
        }
    }
}
