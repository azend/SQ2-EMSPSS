<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EMS_PSS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        window.history.forward();
        function noBack() { window.history.forward(); }
    </script>

    <title>EMS-PSS</title>
    
    <style>
        body 
        {
            background-color:orange;
        }

        table 
        {
            margin-left:auto;
            margin-right:auto;
            width:250px;
        }

        h1 
        {
            text-align:center;
        }

        p 
        {
            text-align:center;
        }
    </style>
</head>
<body onload="noBack();"
    onpageshow="if (event.persisted) noBack();" onunload="">
    <form id="form1" runat="server">
        <div id="loginPage" class="userInfo" runat="server">

            <h1>EMS-PSS Login Page</h1>

            <p>Please enter your Username and Password.</p>

        
            <table>
                <tr>
                    <td><asp:label id="lbUserName" runat="server">Username:</asp:label></td>
                    <td><asp:TextBox id="userName" runat="server" /></td>
                </tr>

                <tr>
                    <td><asp:label id="lbPassword" runat="server">Password:</asp:label></td>
                    <td><asp:TextBox id="password" runat="server" /></td>
                </tr>
            
                <tr>
                    <td><asp:Button id="login" runat="server" text="Login" onClick="login_Click" /></td>
                    <td><asp:Button id="reset" runat="server" text="Reset" OnClick="reset_Click"/></td>
                </tr>
            </table>

            <asp:label id="lbErrorMessage" runat="server"></asp:label>      
        </div>
    </form>
</body>
</html>
