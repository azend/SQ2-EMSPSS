/** Program name: EMS
 * @file ContractEmployee.cs
 * @author Constantine Grigoriadis
 * @author Kelson Conyard
 * @author Richard Meijer
 * @author Sean Jellicoe
 * Date: November 29, 2013
 * @brief Child of the Employee, the Contract Employee
 * has 3 additional fields contractStartDate, contractStopDate, fixedContractAmount
 */




using System;
using System.Collections.Generic;
using System.Text;
//using Supporting;




namespace AllEmployees
{
    public class ContractEmployee : Employee
    {
        private DateTime contractStartDate;
        private DateTime contractStopDate;
        private Double fixedContractAmount=0;
        public ContractEmployee()
        {
            this.ValidateEmployeeType("CT");
        }

        public ContractEmployee(string fName, string lName, string newDateOfBirth, string addSin, string newContract, string stopContract, string newAmount, string addCompany)
            : base(fName, lName, newDateOfBirth, addSin, addCompany)
        {
            ValidateEmployeeType("CT");
            SetContractStartDate(newContract);
            SetContractStopDate(stopContract);
            SetFixedContractAmount(newAmount);
        }
        //accessors start
        public Double FixedContractAmount
        {
            get { return fixedContractAmount; }
            set { fixedContractAmount = value; }
        }
        public DateTime ContractStartDate
        {
            get { return contractStartDate; }
            set { contractStartDate = value; }
        }
        public DateTime ContractStopDate
        {
            get { return contractStopDate; }
            set { contractStopDate = value; }
        }
        //accessors end



        /// <summary>
        /// Method name: SetContractStartDate
        /// 
        /// Purpose: Validates the contractStartDate attribute.  Ensures it can only
        /// be in the format yyyy-MM-dd .
        /// 
        /// Returns: true if valid, false if not
        /// </summary>
        /// <param name="toValidate">the string to be parsed.</param>
        /// <returns>A bool indicating pass or fail.</returns>
        public bool SetContractStartDate(string toValidate)
        {
            bool returnVal = false;
            string expectedFormat = "yyyy-MM-dd";
            bool result = DateTime.TryParseExact(
                toValidate,
                expectedFormat,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out contractStartDate);
            if (result || toValidate == "")
            {
                //Logging.Log("ContractEmployee.SetContractStartDate", "ContractEmployee Set (" + ContractStartDate.ToShortDateString() + ") - VALID");
                returnVal = true;
            }
            else
            {
                //Logging.Log("ContractEmployee.SetContractStartDate", "ContractEmployee Set (" + toValidate + ") - INVALID");
                returnVal = false;
            }
            return returnVal;
        }


        /// <summary>
        /// Method name: SetContractStopDate
        /// 
        /// Purpose: Validates the contractStopDate attribute.  Ensures it can only
        /// be in the format yyyy-MM-dd .
        /// 
        /// Returns: true if valid, false if not
        /// </summary>
        /// <param name="toValidate">the string to be parsed.</param>
        /// <returns>A bool indicating pass or fail.</returns>
        public bool SetContractStopDate(string toValidate)
        {
            bool returnVal = false;
            string expectedFormat = "yyyy-MM-dd";
            bool result = DateTime.TryParseExact(
                toValidate,
                expectedFormat,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out contractStopDate);
            if (result || toValidate == "")
            {
                //Logging.Log("ContractEmployee.SetContractStopDate", "ContractEmployee Set (" + ContractStopDate.ToShortDateString() + ") - VALID");
                returnVal = true;
            }
            else
            {
                //Logging.Log("ContractEmployee.SetContractStopDate", "ContractEmployee Set (" + toValidate + ") - INVALID");
            }
            return returnVal;
        }


        /// <summary>
        /// Method name: SetFixedContractAmount
        /// 
        /// Purpose: Validates the FixedContractRate attribute.  Ensures it can only
        /// be greater then 0 dollars
        /// </summary>
        /// <param name="toValidate">The double to validate.</param>
        /// <returns>A bool representing pass or fail.</returns>
        public bool SetFixedContractAmount(string toValidate)
        {
            bool returnVal = false;
            Double pay;

            Double.TryParse(toValidate, out pay);

            if (pay > 0 || toValidate == "")
            {
                FixedContractAmount = pay;
                returnVal = true;
                //Logging.Log("ContractEmployee.SetFixedContractRate", "ContractEmployee Set (" + FixedContractAmount.ToString() + ") - VALID");
            }
            else
            {
                //Logging.Log("ContractEmployee.SetFixedContractRate", "ContractEmployee Set (" + toValidate + ") - INVALID");
                returnVal = false;
            }
            return returnVal;
        }


        /// <summary>
        /// Method name: Details
        /// 
        /// Purpose: This method dumps the stats for
        /// the Contract time employee
        /// Dumps base employee info and
        /// Contract start date , Contract end date , Fixed Contract amount
        /// </summary>
        /*public override void Details()
        {
            Console.WriteLine("Corporation name : {0}", LastName);
            Console.WriteLine("Employee Type : {0}", EmployeeType);
            Console.WriteLine("Business Number : {0}", GetFormattedSin());
            if (DateOfBirth == new DateTime())
            {
                Console.WriteLine("Date Of Incorporation: N/A");
            }
            else
            {
                Console.WriteLine("Date Of Incorporation: {0}", DateOfBirth.ToShortDateString());
            }
            if (contractStartDate != new DateTime())
            {
                Console.WriteLine("Contract Start Date : {0}", contractStartDate.ToShortDateString());
            }
            else
            {
                Console.WriteLine("Contract Start Date : N/A");
            }
            if (contractStopDate != new DateTime())
            {
                Console.WriteLine("Contract Stop Date : {0}", contractStopDate.ToShortDateString());
            }
            else
            {
                Console.WriteLine("Contract Stop Date : N/A");
            }
            Console.WriteLine("Fixed Contract Amount : {0}", fixedContractAmount);

            Logging.Log("FulltimeEmployee.Details", "Printed "
                + "First name: " + FirstName + "\n"
                + "Corporation name: " + LastName + "\n"
                + "Incorporation Date: " + DateOfBirth.ToShortDateString() + "\n"
                + "Business Number: " + Sin + "\n"
                + "Contract Start Date: " + ContractStartDate.ToShortDateString() + "\n"
                + "Contract Stop Date: " + ContractStopDate.ToShortDateString() + "\n"
                + "Fixed Contract Amount: " + FixedContractAmount.ToString());
        }*/


        /// <summary>
        /// Formats the business number to be displayed properly
        /// </summary>
        /// <returns> The formatted SIN number</returns>
        public override string GetFormattedSin()
        {
            string displaySin = Sin;

            if (displaySin != string.Empty)
            {
                displaySin = displaySin.Substring(0, 5) + " " + displaySin.Substring(5, 4);
            }
            else
            {
                displaySin = "N/A";
            }

            return displaySin;
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
            return EmployeeType + "|" + LastName + "|" + FirstName + "|" + Sin + "|" + DateOfBirth.ToShortDateString() + "|"+
               contractStartDate.ToShortDateString() + "|" +
               contractStopDate.ToShortDateString() + "|" + 
               fixedContractAmount.ToString() + "|" ;
        }


        /// <summary>
        /// Method name: Validate
        /// 
        /// Purpose: Checks that each fields meets the requirements to be considered a valid
        /// contract employee.  
        /// 
        /// Returns: False if invalid, true if valid
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            if (LastName.Length == 0)
            {
                //Logging.Log("ContractEmployee.Validate", "ContractEmployee Validate Corporation Name (" + LastName + ") - INVALID");
                SetLastName("");
                return false;
            }

            if (DateOfBirth == DateTime.MinValue)
            {
                //Logging.Log("ContractEmployee.Validate", "ContractEmployee Validate Incorporation Date (" + DateOfBirth.ToShortDateString() + ") - INVALID");
                return false;
            }

            if (!IsValidSIN(Sin))
            {
                //Logging.Log("ContractEmployee.Validate", "ContractEmployee Validate Business Number (" + Sin + ") - INVALID");
                SetSin("");
                return false;
            }
            else
            {

                if (!SetContractSin())
                {
                    //Logging.Log("ContractEmployee.Validate", "ContractEmployee Validate Business Number (" + Sin + ") - INVALID");
                    SetSin("");
                    return false;
                }

            }

            if (contractStartDate != DateTime.MinValue)
            {
                if (contractStartDate < DateOfBirth)
                {
                    //Logging.Log("ContractEmployee.Validate", "ContractEmployee Validate Contract Start Date (" + ContractStartDate.ToShortDateString() + ") - INVALID");
                    SetContractStartDate("");
                    return false;
                }
            }
            else
            {
                //Logging.Log("ContractEmployee.Validate", "ContractEmployee Validate Contract Start Date (" + ContractStartDate.ToShortDateString() + ") - INVALID");
                return false;
            }

            if (contractStopDate != DateTime.MinValue)
            {
                if ((contractStopDate < contractStartDate) || (contractStartDate < DateOfBirth))
                {
                    //Logging.Log("ContractEmployee.Validate", "ContractEmployee Validate Contract Stop Date(" + ContractStopDate.ToShortDateString() + ") - INVALID");
                    SetContractStartDate("");
                    return false;
                }
            }
            else
            {
                //Logging.Log("ContractEmployee.Validate", "ContractEmployee Validate Contract Stop Date (" + ContractStopDate.ToShortDateString() + ") - INVALID");
                return false;
            }

            if (fixedContractAmount <= 0)
            {
                //Logging.Log("ContractEmployee.Validate", "ContractEmployee Validate Fixed Contract Amount(" + FixedContractAmount.ToString() + ") - INVALID");
                fixedContractAmount = 0;
                return false;
            }

            //Logging.Log("ContractEmployee.Validate", "ContractEmployee Validate (" + FirstName + ", " + LastName + ", " + Sin.ToString() + ") - VALID");

            return true;
        }

        /// <summary>
        /// Method name: SetContractSin
        /// 
        /// Purpose: Checks if the first two digits match the year of incorporation
        /// 
        /// Returns: false if invalid, true if valid
        /// </summary>
        /// <returns> True if its valid, false otherwhise </returns>
        public bool SetContractSin()
        {
            string sinCheck = Sin.Substring(0, 2);
            string year = DateOfBirth.Year.ToString().PadLeft(4, '0').Substring(2, 2);

            if (sinCheck == year)
            {
                //Logging.Log("ContractEmployee.SetContractSin", "ContractEmployee Set (" + Sin + ") - VALID");
                return true;
            }

            //Logging.Log("ContractEmployee.SetContractSin", "ContractEmployee Set (" + Sin + ") - INVALID");
            return false;
        }

    }
}
