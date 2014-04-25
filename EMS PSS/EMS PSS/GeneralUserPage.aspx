<%@ Page Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="GeneralUserPage.aspx.cs" Inherits="EMS_PSS.GeneralUserPage" %>

<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">
    <form id="generalUserPageForm" runat="server">
        <div id="menuView">
            <p>Welcome to the EMS-PSS. Use the navigation menu on the left.</p>
        </div>
    </form>

</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>
