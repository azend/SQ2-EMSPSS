<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeCardEntry.aspx.cs" Inherits="EMS_PSS.TimeCardEntry" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en-AU">
<head id="Head1" runat="server">
    <script type="text/javascript">
        window.history.forward();
        function noBack() { window.history.forward(); }
    </script>

    <title>EMS-PSS - Time Card</title>

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
            <div id="heading">
            <h1>TimeCard Entry</h1>
            </div>

            <div id="Time Card Entry">
            <table>
                    <tr>
                            <td>Select Work Week:</td> 
                            <td>
                            <asp:ListBox ID="Workweek" runat="server" OnSelectedIndexChanged="Workweek_SelectedIndexChanged" Width="128px"> </asp:ListBox>
                            </td>
                    </tr>
                     <tr>
                            <td>Enter Monday Hours </td> 
                            <td><asp:TextBox ID="MondayHours" runat="server"></asp:TextBox></td>
                    </tr>
                             <tr>
                            <td>Enter Tuesday Hours </td> 
                            <td><asp:TextBox ID="TuesdayHours" runat="server"></asp:TextBox></td>
                    </tr>
                             <tr>
                            <td>Enter Wednesday Hours </td> 
                            <td><asp:TextBox ID="WednesdayHours" runat="server"></asp:TextBox></td>
                    </tr>
                             <tr>
                            <td>Enter Thursday Hours </td> 
                            <td><asp:TextBox ID="ThursdayHours" runat="server"></asp:TextBox></td>
                    </tr>
                             <tr>
                            <td>Enter Friday Hours </td> 
                            <td><asp:TextBox ID="FridayHours" runat="server"></asp:TextBox></td>
                    </tr>
                             <tr>
                            <td>Enter Saturday Hours </td> 
                            <td><asp:TextBox ID="SaturdayHours" runat="server"></asp:TextBox></td>
                    </tr>
                             <tr>
                            <td>Enter Sunday Hours </td> 
                            <td><asp:TextBox ID="SundayHours" runat="server"></asp:TextBox></td>
                            </tr>

            </table>
            </div>
        </form>
            
            <p class="footer">Copyright 2014 Default Team | <!-- leave that in there --> Design by <a href="http://www.internetsplash.com/">Internet Splash</a></p>
	    </div>
        <div id="nav">
            <h4>:: <span>EMS</span>PSS ::</h4>
            <div id="navcontainer">
                <ul id="navlist">
                <li class="active">Navigation</li>
                <li><a href="GeneralUserPage.aspx" id="current">Home</a></li>
                <li><a href="ManageEmployeesPage.aspx">Manage Employees</a></li>
                <li><a href="ReportsPage.aspx">Reports</a></li>
                <li><a href="TimeCardEntry.aspx">Time Card</a></li>
                <li class="active nobo"><div class="userInfo" id="userInfo" runat="server"></div></li>
                </ul>
            </div>
        </div>
    </div>
</body>
</html>