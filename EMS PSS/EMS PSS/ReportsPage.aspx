<%@ Page Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="ReportsPage.aspx.cs" Inherits="EMS_PSS.ReportsPage" %>

<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">
            <form id="form1" runat="server">

                <div id="menuView">
                    <p>Choose one of the options below</p>
                    <asp:Button ID="btnSeniorityReport" runat="server" Text="Generate Seniority Report" OnClick="btnSeniorityReport_Click" /><br />
                    <asp:Button ID="btnWeeklyHoursWorkedReport" runat="server" Text="Generate Weekly Hours Worked Report" OnClick="btnWeeklyHoursWorkedReport_Click" />
                </div>

                <div class="clearfix"></div>
            </form>

    
</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>
