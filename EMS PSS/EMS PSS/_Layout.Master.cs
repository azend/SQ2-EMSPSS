using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS_PSS
{
    public partial class _Layout : System.Web.UI.MasterPage
    {
        protected bool IsLoggedIn = false;
        protected string UserType = null;
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                IsLoggedIn = true;

                if (Session["userType"] != null)
                {
                    UserType = (string)Session["userType"];
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            // Redirect any unauthenticated users back to the login page so that
            // they can log in.
            if (Session["userId"] == null && !Request.Path.StartsWith("/Login"))
            {
                Response.Redirect("Login.aspx");
            }

            string userType = (string)Session["userType"];
            if (userType != null)
            {
                if (userType.Equals("GENERAL"))
                {
                    userHome.NavigateUrl = "GeneralUserPage.aspx";
                }
                else if (userType.Equals("ADMIN"))
                {
                    userHome.NavigateUrl = "AdminPage.aspx";
                }
            }

        }
    }
}