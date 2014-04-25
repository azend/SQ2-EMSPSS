<%@ Page Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EMS_PSS.Login" %>

<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">
    <form id="form1" runat="server">
        <div id="loginPage" class="userInfo" runat="server">

            <blockquote><strong>EMS-PSS Login</strong></blockquote>
            <p>Please enter your Username and Password.</p>

            <table>
                <tr>
                    <td><asp:label id="lbUserName" runat="server">Username:</asp:label></td>
                    <td><asp:TextBox id="userName" runat="server" /></td>
                </tr>

                <tr>
                    <td><asp:label id="lbPassword" runat="server">Password:</asp:label></td>
                    <td><asp:TextBox id="password" TextMode="Password" runat="server" /></td>
                </tr>
            
                <tr>
                    <td><asp:Button id="login" runat="server" text="Login" onClick="login_Click" /></td>
                    <td><asp:Button id="reset" runat="server" text="Reset" OnClick="reset_Click"/></td>
                </tr>
            </table>

            <asp:label id="lbErrorMessage" runat="server"></asp:label>      
        </div>
    </form>
</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>