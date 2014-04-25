<%@ Page Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="GeneralUserPage.aspx.cs" Inherits="EMS_PSS.GeneralUserPage" %>

<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">
    <form id="generalUserPageForm" runat="server">
        <div id="menuView">
            <p>Choose one of the options below</p>
            <asp:Button ID="btnCreateEmployee" runat="server" Text="Create New Employee" OnClick="btnCreateEmployee_Click" /><br />
            <asp:Button ID="btnSeniorityReport" runat="server" Text="Generate Seniority Report" /><br />
            <asp:Button ID="btnWeeklyHoursWorkedReport" runat="server" Text="Generate Weekly Hours Worked Report" />

        </div>
    </form>

</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>
