<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EMS_PSS.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en-AU">
<head id="Head1" runat="server">
    <script type="text/javascript">
        window.history.forward();
        function noBack() { window.history.forward(); }
    </script>

    <title>EMS-PSS</title>

    <meta http-equiv="content-type" content="application/xhtml+xml; charset=UTF-8" />
    <meta name="author" content="Internet Splash" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link rel="stylesheet" type="text/css" href="assets/screenprint.css" media="screen, print" />
</head>
<body onload="noBack();" onpageshow="if (event.persisted) noBack();" onunload="">
    <div id="main">
        <h1>:: <span>EMS</span>PSS ::</h1>
 	    <div id="content">
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

            <p class="footer">Copyright 2014 Default Team | <!-- leave that in there --> Design by <a href="http://www.internetsplash.com/">Internet Splash</a></p>
	    </div>
        <div id="nav">
            <h4>:: <span>EMS</span>PSS ::</h4>
            <div id="navcontainer">
                <ul id="navlist">
                <li class="active">Navigation</li>
                <li><a href="#" id="current">Home</a></li>
                <li class="active nobo">Helping you manage your employee's since 2014</li>
                </ul>
            </div>
        </div>
    </div>
</body>
</html>