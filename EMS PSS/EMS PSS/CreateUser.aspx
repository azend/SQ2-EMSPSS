<%@ Page Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="EMS_PSS.CreateUser" %>

<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">
    <form id="searchEmployeeForm" runat="server">
        <div id="menuView">
            <blockquote><strong>Create new user</strong></blockquote>
            <table>
                <tr>
                    <td><asp:label id="lbUserID" runat="server">Username:</asp:label></td>
                    <td><asp:TextBox id="tbUserID" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:label id="lbUserPass" runat="server">Password:</asp:label></td>
                    <td><asp:TextBox id="tbUserPass" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:label id="lbFirstName" runat="server">First Name:</asp:label></td>
                    <td><asp:TextBox id="tbFirstName" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:label id="lbLastName" runat="server">Last Name:</asp:label></td>
                    <td><asp:TextBox id="tbLastName" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:Label id="lbUserType" runat="server">User Type:</asp:Label></td>
                    <td><asp:RadioButton id="rbUserTypeGen" Checked="true" text="GENERAL" GroupName="gnUserType" runat="server" /> 
                        <asp:RadioButton id="rbUserTypeAdmin" text="ADMIN" GroupName="gnUserType" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:Button id="btnSubmit" runat="server" text="Create" onClick="Submit_Click" /></td>
                    <td><asp:Button id="btnReset" runat="server" text="Reset" onClick="Reset_Click" /></td>
                </tr>
            </table>
            <div class="clearfix"></div>
            <asp:label id="lbMessage" runat="server"></asp:label> 
        </div>
    </form>
</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>
