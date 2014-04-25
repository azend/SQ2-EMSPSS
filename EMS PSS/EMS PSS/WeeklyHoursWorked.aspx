<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="WeeklyHoursWorked.aspx.cs" Inherits="EMS_PSS.WeeklyHoursWorked" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
    <style>
        table {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">

    <h1>Weekly Hours Worked Report</h1>

    <form action="" method="get">
        <select name="workWeek">
            <% foreach(string workWeek in workWeeks) { %>
                <option value="<%=workWeek %>"><%=workWeek %></option>
            <% } %>
        </select>
        <input type="submit" value="Run report" />
    </form>

    <form id="form1" runat="server">
        
        <div id="report" runat="server">
            

            
            <% foreach( KeyValuePair<string, List<Dictionary<string,string>>> company in employees ) { %>
            <h2><%=company.Key %></h2>
            <h3>Full-time Employee</h3>
            <table border="1">
                <tr>
                    <th>Employee Name</th>
                    <th>SIN</th>
                    <th>Hours Worked</th>
                </tr>
                <% foreach(Dictionary<string, string> employee in company.Value) {
                    if (employee["EmployeeType"].Equals("FULLTIME")) { %>
                <tr>
                    <td><%=employee["LastName"] %>, <%=employee["FirstName"] %></td>
                    <td><%=employee["SIN"] %></td>
                    <td><%=employee["NumHoursWorked"] %></td>
                </tr>
                <% } } %>
            </table>
                <h3>Part-time Employee</h3>
                <table border="1">
                    <tr>
                    <th>Employee Name</th>
                    <th>SIN</th>
                    <th>Hours Worked</th>
                </tr>
                <% foreach(Dictionary<string, string> employee in company.Value) {
                    if (employee["EmployeeType"].Equals("PARTTIME")) { %>
                <tr>
                    <td><%=employee["LastName"] %>, <%=employee["FirstName"] %></td>
                    <td><%=employee["SIN"] %></td>
                    <td><%=employee["NumHoursWorked"] %></td>
                </tr>
                <% } } %>
            </table>
                <h3>Seasonal Employee</h3>
                <table border="1">
                    <tr>
                    <th>Employee Name</th>
                    <th>SIN</th>
                    <th>Hours Worked</th>
                </tr>
                <% foreach(Dictionary<string, string> employee in company.Value) {
                    if (employee["EmployeeType"].Equals("SEASONAL")) { %>
                <tr>
                    <td><%=employee["LastName"] %>, <%=employee["FirstName"] %></td>
                    <td><%=employee["SIN"] %></td>
                    <td><%=employee["NumHoursWorked"] %></td>
                </tr>
                <% } } %>
            </table>
                <h3>Contract Employee</h3>
                <table border="1">
                    <tr>
                    <th>Employee Name</th>
                    <th>SIN</th>
                    <th>Hours Worked</th>
                </tr>
                <% foreach(Dictionary<string, string> employee in company.Value) {
                    if (employee["EmployeeType"].Equals("CONTRACT")) { %>
                <tr>
                    <td><%=employee["LastName"] %>, <%=employee["FirstName"] %></td>
                    <td><%=employee["SIN"] %></td>
                    <td><%=employee["NumHoursWorked"] %></td>
                </tr>
                <% } } %>
            </table>
            <% } %>

            
        </div>

        <div>
            <asp:label id="lbErrorMessage" runat="server"></asp:label>
        </div>
    </form>

</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
</asp:Content>
