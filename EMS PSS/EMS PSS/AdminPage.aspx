<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="EMS_PSS.AdminPage" %>
<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">
        <div id="menuView">
            <p>Welcome to the EMS-PSS. Use the navigation menu on the left.</p>
        </div>
</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>
