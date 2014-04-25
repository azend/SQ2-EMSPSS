<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="EMS_PSS.AdminPage" %>
<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">

    <form id="form1" runat="server">

        <div id="menuView">
            <p>Choose one of the options below</p>
            <asp:Button ID="btnCreateEmployee" runat="server" Text="Create New Employee" OnClick="btnCreateEmployee_Click" /><br />
        </div>

        <div class="clearfix"></div>
    </form>

</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>
