<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="EMS_PSS.AdminPage" %>

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
            <p>Welcome Admin.<br />
                Select an option from the navigation menu to the left to begin.
            </p>

            <p class="footer">Copyright 2014 Default Team | <!-- leave that in there --> Design by <a href="http://www.internetsplash.com/">Internet Splash</a></p>
	    </div>
        <div id="nav">
            <h4>:: <span>EMS</span>PSS ::</h4>
            <div id="navcontainer">
                <ul id="navlist">
                <li class="active">Navigation</li>
                <li><a href="AdminPage.aspx" id="current">Home</a></li>
                <li><a href="ManageEmployeesPage.aspx">Manage Employees</a></li>
                <li><a href="ReportsPage.aspx">Reports</a></li>
                <li><a href="AuditLog.aspx">Audit Log</a></li>
                <li><a href="CreateUser.aspx">Create New User</a></li>
                <li class="active nobo"><div class="userInfo" id="userInfo" runat="server"></div></li>
                </ul>
            </div>
        </div>
    </div>
</body>
</html>

