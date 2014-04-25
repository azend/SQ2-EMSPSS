using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS_PSS.App_Code
{
    public class Log
    {
        public int LogId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string Action { get; set; }
        public string UserId { get; set; }
        public string AttributeChanged { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime EventTime { get; set; }
    }
}