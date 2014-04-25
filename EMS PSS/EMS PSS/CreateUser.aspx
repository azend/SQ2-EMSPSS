<%@ Page Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="EMS_PSS.CreateUser" %>

<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">
    <form id="searchEmployeeForm" runat="server">
        <div id="menuView">
            <blockquote><strong>Create new user</strong></blockquote>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>
