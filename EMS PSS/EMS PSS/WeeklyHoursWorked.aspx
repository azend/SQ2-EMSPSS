<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="WeeklyHoursWorked.aspx.cs" Inherits="EMS_PSS.WeeklyHoursWorked" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
    <style>
        table {
            display: block;
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
            <table>
                <% foreach(Dictionary<string, string> employee in company.Value) { %>
                <tr>
                    <td><%=employee["LastName"] %>, <%=employee["FirstName"] %></td>
                    <td><%=employee["SIN"] %></td>
                    <td><%=employee["NumHoursWorked"] %></td>
                </tr>
                <% } %>
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
