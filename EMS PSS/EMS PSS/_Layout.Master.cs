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
        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = (string)Session["userType"];
            if (userType == "GENERAL")
            {
                liUserHome.HRef = "GeneralUserPage.aspx";
            }
            else if (userType == "ADMIN")
            {
                liUserHome.HRef = "AdminPage.aspx";
            }
        }
    }
}