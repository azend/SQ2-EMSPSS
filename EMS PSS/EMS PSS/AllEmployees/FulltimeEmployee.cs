/** Program name: EMS
 * @file FulltimeEmployee.cs
 * @author Constantine Grigoriadis
 * @author Kelson Conyard
 * @author Richard Meijer
 * @author Sean Jellicoe
 * Date: November 30, 2013
 * @brief Child of the Employee, the fulltime Employee
 * has 3 additional fields dateOfHire, dateOfTermination, salary
 */




using System;
using System.Collections.Generic;
using System.Text;
//using Supporting;




namespace AllEmployees
{
    public class FulltimeEmployee : Employee
    {

        private DateTime dateOfHire;
        private DateTime dateOfTermination;
        private Double salary = 0;



        public FulltimeEmployee()
        {
            ValidateEmployeeType("FT");
        }

        /// <summary>
        /// Constructor that only takes the first and last names
        /// </summary>
        /// <param name="fName"> First Name </param>
        /// <param name="lName"> Last Name </param>
        public FulltimeEmployee(string firstName, string lastName)
            : base(firstName, lastName) 
        {
            ValidateEmployeeType("FT");
        }

        public FulltimeEmployee(string fName, string lName, string newDateOfBirth, string addSin, string newDateOfHire, string newDateOfTermination, string newHourlyRate, string addCompany)
            : base(fName, lName, newDateOfBirth, addSin, addCompany)
        {
            ValidateEmployeeType("FT");
            SetDateofHire(newDateOfHire);
            SetDateofTermination(newDateOfTermination);
            SetSalary(newHourlyRate);
        }


        //accessors start
        public Double Salary
        {
            get { return salary; }
            set { salary = value; }
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
        /// Method name: SetDateofTermination
        /// 
        /// Purpose: Validates the dateOfTermination attribute.  Ensures it can only
        /// be in the format yyyy-MM-dd .
        /// 
        /// Returns: true if valid, false if not
        /// </summary>
        /// <param name="toValidate">the string to be parsed</param>
        /// <returns></returns>
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
                returnVal = true;
                ////Logging.Log("FulltimeEmployee.SetDateofTermination", "Date of Termination Set (" + DateofTermination.ToShortDateString() + ") - VALID");
            }
            else
            {
                ////Logging.Log("FulltimeEmployee.SetDateofTermination", "Date of Termination Set (" + toValidate + ") - INVALID");
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
                returnVal = true;
                ////Logging.Log("FulltimeEmployee.SetDateofHire", "Date of Hire Set (" + DateOfHire.ToShortDateString() + ") - VALID");

            }
            else
            {
                ////Logging.Log("FulltimeEmployee.SetDateofHire", "Date of Hire Set (" + toValidate + ") - INVALID");
            }
            return returnVal;
        }



        /// <summary>
        /// Method name: SetSalary
        /// 
        /// Purpose: Validates the Salary attribute.  
        /// Makes sure the value is greater then 0 dollars
        /// </summary>
        /// <param name="toValidate">The double to validate.</param>
        /// <returns>A bool representing pass or fail.</returns>
        public bool SetSalary(string toValidate)
        {
            bool returnVal = false;
            Double Wage;

            Double.TryParse(toValidate, out Wage);

            if (Wage > 0 || toValidate == "")
            {
                Salary = Wage;
                returnVal = true;
                ////Logging.Log("FulltimeEmployee.SetSalary", "Salary Set (" + Salary + ") - VALID");

            }
            else
            {
                ////Logging.Log("FulltimeEmployee.SetSalary", "Salary Set (" + toValidate + ") - INVALID");
                returnVal = false;
            }
            return returnVal;
        }



        /// <summary>
        /// Method name: Details
        /// 
        /// Purpose: This method dumps the stats for
        /// the full time employee
        /// Dumps base employee info and
        /// Date of Hire , Date of Termination ,Salary
        /// </summary>
        /*public override void Details()
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
            Console.WriteLine("Salary : {0}", salary);

            //Logging.Log("FulltimeEmployee.Details", "Printed " 
                + "First name: " + FirstName + "\n"
                + "Last name: " + LastName + "\n"
                + "Date of Birth: " + DateOfBirth.ToShortDateString() + "\n"
                + "SIN: " + Sin + "\n"
                + "Date of Hire: " + DateOfHire.ToShortDateString() + "\n"
                + "Date of Termination: " + DateofTermination.ToShortDateString() + "\n"
                + "Salary: " + Salary.ToString());
        }*/


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
               salary.ToString() + "|";
        }


        public override bool Validate()
        {
            if (FirstName.Length == 0)
            {
                ////Logging.Log("FulltimeEmployee.Validate", "FulltimeEmployee Validated (" + FirstName + ") - INVALID");
                SetFirstName("");
                
                return false;
            }

            if (LastName.Length == 0)
            {
                ////Logging.Log("FulltimeEmployee.Validate", "FulltimeEmployee Validated (" + LastName + ") - INVALID");
                SetLastName("");
                
                return false;
            }

            if (DateOfBirth == DateTime.MinValue)
            {
                ////Logging.Log("FulltimeEmployee.Validate", "FulltimeEmployee Validated (" + DateOfBirth.ToShortDateString() + ") - INVALID");
                return false;
            }

            if (!IsValidSIN(Sin))
            {
                //Logging.Log("FulltimeEmployee.Validate", "FulltimeEmployee Validated (" + Sin + ") - INVALID");
                SetSin("");
                return false;
            }

            if (dateOfHire != DateTime.MinValue)
            {
                if (dateOfHire < DateOfBirth)
                {
                    //Logging.Log("FulltimeEmployee.Validate", "FulltimeEmployee Validated (" + DateOfHire.ToShortDateString() + ") - INVALID");
                    SetDateOfBirth("");
                    return false;
                }
            }
            else
            {
                //Logging.Log("FulltimeEmployee.Validate", "FulltimeEmployee Validated (" + DateOfHire.ToShortDateString() + ") - INVALID");
                return false;
            }

            if (dateOfTermination != DateTime.MinValue)
            {
                if ((dateOfTermination < dateOfHire) || (dateOfTermination < DateOfBirth))
                {
                    //Logging.Log("FulltimeEmployee.Validate", "FulltimeEmployee Validated (" + DateofTermination.ToShortDateString() + ") - INVALID");
                    SetDateofTermination("");
                    return false;
                }
            }

            if (salary <= 0)
            {
                //Logging.Log("FulltimeEmployee.Validate", "FulltimeEmployee Validated (" + Salary + ") - INVALID");
                salary = 0;
                return false;
            }

            //Logging.Log("FulltimeEmployee.Validate", "FulltimeEmployee Validated ("+ FirstName + ", " + LastName + ", " + Sin.ToString() + ") - VALID");

            return true;
        }


    }
}
