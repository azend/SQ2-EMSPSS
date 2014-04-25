using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS_PSS.EmployeeManagement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Hello world";
        }

        protected void EmployeeDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void EmployeeDataSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}