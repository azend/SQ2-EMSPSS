using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS_PSS
{
    public partial class GeneralUserPage : System.Web.UI.Page
    {
        private string userID;
        private string firstName;
        private string lastName;
        private string userType;

        protected void Page_Load(object sender, EventArgs e)
        {
            //check session variables to make sure user did not get to this page illegally
            userID = (string)Session["userID"];
            firstName = (string)Session["firstName"];
            lastName = (string)Session["lastName"];
            userType = (string)Session["userType"];

            

            userInfo.InnerHtml = "<table>" +
                "<tr><td>Username: </td><td>" + userID + "</td></tr>" +
                "<tr><td>First Name: </td><td>" + firstName + "</td></tr>" +
                "<tr><td>Last Name: </td><td>" + lastName + "</td></tr>" +
                "<tr><td>User Type: </td><td>" + userType + "</td></tr>" +
                "</table>";
        }

        protected void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateEmployee.aspx");
        }

        protected void btnSeniorityReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeniorityReport.aspx");
        }
    }
}