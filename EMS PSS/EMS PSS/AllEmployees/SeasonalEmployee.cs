/** Program name: EMS
 * @file SeasonalEmployee.cs
 * @author Constantine Grigoriadis
 * @author Kelson Conyard
 * @author Richard Meijer
 * @author Sean Jellicoe
 * Date: November 30, 2013
 * @brief Child of the Employee, the SeasonalEmployee Employee
 * has 2 additional fields season and piecePay
 */




using System;
using System.Collections.Generic;
using System.Text;
//using Supporting;




namespace AllEmployees
{
    public class SeasonalEmployee : Employee
    {
        string season = "";
        private Double piecePay=0;
        public SeasonalEmployee()
        {
            this.ValidateEmployeeType("SN");
        }

        public SeasonalEmployee(string addSeason, string addPiecePay, string fName, string lName, string addDateOfBirth, string addSin)
            :base (fName, lName, addDateOfBirth, addSin)
        {
            ValidateEmployeeType("SN");
            SetSeason(addSeason);
            SetPiecePay(addPiecePay);

        }

        public  readonly string[] Seasons = { "WINTER", "SUMMER", "SPRING", "FALL" };
        //accessors start
        public Double PiecePay
        {
            get { return piecePay; }
            set { piecePay = value; }
        }
        public string Season
        {
            get { return season; }
            set { season = value; }
        }
        //accessors end


        /// <summary>
        /// Method name: SetPiecePay
        /// 
        /// Purpose: to validate the piecePay attribute, this method ensures 
        /// the value is above 0.
        /// </summary>
        /// <param name="toValidate"></param>
        /// <returns>A bool representing pass or fail.</returns>
        public bool SetPiecePay(string toValidate)
        {
            bool returnVal = false;
            Double pay;

            Double.TryParse(toValidate, out pay);
            if (pay > 0 || toValidate == "")
            {
                PiecePay = pay;
                //Logging.Log("SeasonalEmployee.SetPiecePay", "SeasonalEmployee Set (" + PiecePay + ") - VALID");
                returnVal = true;
            }
            else
            {
                //Logging.Log("SeasonalEmployee.SetPiecePay", "SeasonalEmployee Set (" + toValidate + ") - INVALID");
                Console.WriteLine("Must enter a number.");
                returnVal = false;
            }
            return returnVal;
        }
        

        /// <summary>
        /// 
        /// Method name: SetSeason
        /// 
        /// Purpose: to ensure the season is always valid,
        /// the season can be WINTER , SPRING, SUMMER , FALL.
        /// </summary>
        /// <param name="Season"></param>
        /// <returns>A bool representing pass or fail.</returns>
        public bool SetSeason(string newSeason)
        {
            bool returnVal = false;
            foreach (string CurrentSeason in Seasons)
            {
                //make sure the value is one of four seasons
               
                if (CurrentSeason == newSeason.ToUpper() || newSeason == "")
                {
                    Season = newSeason.ToUpper();
                    //Logging.Log("SeasonalEmployee.SetSeason", "SeasonalEmployee Set (" + Season + ") - VALID");
                    returnVal = true;
                }
            }
            
            if (returnVal == false)
            {
                //Logging.Log("SeasonalEmployee.SetSeason", "SeasonalEmployee Set (" + newSeason + ") - INVALID");
                returnVal = false;
            }

            return returnVal;
        }
        
        
        /// <summary>
        /// Method name: Details
        /// 
        /// Purpose: This method dumps the stats for
        /// the Seasonal employee class
        /// Dumps base employee info and
        /// PiecePay , and Season .
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
            Console.WriteLine("PiecePay : {0}", piecePay);
            Console.WriteLine("Season : {0}", season);

            //Logging.Log("SeasonalEmployee.Details", "Printed "
                + "First name: " + FirstName + "\n"
                + "last name: " + LastName + "\n"
                + "Date of Birth: " + DateOfBirth.ToShortDateString() + "\n"
                + "SIN: " + Sin + "\n"
                + "Piece Pay: " + PiecePay.ToString() + "\n"
                + "Season: " + Season + "\n");
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
            return EmployeeType + "|" + LastName + "|" + FirstName + "|" + Sin + "|" + DateOfBirth.ToShortDateString()+"|"
                + season+"|" + piecePay.ToString()+"|";
        }



        /// <summary>
        /// Method name: Validate
        /// 
        /// Purpose: Validates if the fields form together to make a valid seasonal employee.
        /// </summary>
        /// <returns>true if valid, false if not</returns>
        public override bool Validate()
        {
            if (FirstName.Length == 0)
            {
                //Logging.Log("SeasonalEmployee.Validate", "SeasonalEmployee Validate First Name (" + FirstName +  ") - INVALID");
                SetFirstName("");
                
                return false;
            }

            if (LastName.Length == 0)
            {
                //Logging.Log("SeasonalEmployee.Validate", "SeasonalEmployee Validate Last Name (" + LastName + ") - INVALID");
                SetLastName("");
                return false;
            }

            if (DateOfBirth == DateTime.MinValue)
            {
                //Logging.Log("SeasonalEmployee.Validate", "SeasonalEmployee Validate Date of Birth (" + DateOfBirth.ToShortDateString() + ") - INVALID");
                return false;
            }

            if (!IsValidSIN(Sin))
            {
                //Logging.Log("SeasonalEmployee.Validate", "SeasonalEmployee Validate Sin (" + Sin + ") - INVALID");
                SetSin("");
                return false;
            }

            if (piecePay <= 0)
            {
                //Logging.Log("SeasonalEmployee.Validate", "SeasonalEmployee Validate Piece Pay (" + PiecePay + ") - INVALID");
                PiecePay = 0;
                return false;
            }

            if (Season != "WINTER" && Season != "SUMMER" && Season != "FALL" && Season != "SPRING")
            {
                //Logging.Log("SeasonalEmployee.Validate", "SeasonalEmployee Validate Season (" + Season + ") - INVALID");
                return false;
            }

            //Logging.Log("SeasonalEmployee.Validate", "SeasonalEmployee Validate (" + FirstName + ", " + LastName + ", " + Sin.ToString() + ") - VALID");

            return true;
        }

    }
}
