<%@ Page Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="ManageEmployeesPage.aspx.cs" Inherits="EMS_PSS.ManageEmployeesPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <form id="form1" runat="server">

        <div id="menuView">
            <p>Choose one of the options below</p>
            <asp:Button ID="btnCreateEmployee" runat="server" Text="Create New Employee" OnClick="btnCreateEmployee_Click" /><br />
            <asp:Button ID="btnSearchEmployee" runat="server" Text="Search Employees" OnClick="btnSearchEmployee_Click" /><br />
            <asp:Button ID="btnEditEmployee" runat="server" Text="Edit Employee" OnClick="btnEditEmployee_Click" /><br />
        </div>

        <div class="clearfix"></div>
    </form>
</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>