<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeneralUserPage.aspx.cs" Inherits="EMS_PSS.GeneralUserPage" %>

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

            <div id="menuView">
                <p>Choose one of the options below</p>
                <asp:Button ID="btnCreateEmployee" runat="server" Text="Create New Employee" OnClick="btnCreateEmployee_Click" /><br />
                <asp:Button ID="btnSeniorityReport" runat="server" Text="Generate Seniority Report" /><br />
                <asp:Button ID="btnWeeklyHoursWorkedReport" runat="server" Text="Generate Weekly Hours Worked Report" />
            </div>

            <div class="clearfix"></div>
        </form>

            <p class="footer">Copyright 2014 Default Team | <!-- leave that in there --> Design by <a href="http://www.internetsplash.com/">Internet Splash</a></p>
	    </div>
        <div id="nav">
            <h4>:: <span>EMS</span>PSS ::</h4>
            <div id="navcontainer">
                <ul id="navlist">
                <li class="active">Navigation</li>
                <li><a href="#" id="current">Home</a></li>
                <li><a href="#">Link</a></li>
                <li><a href="#">Link</a></li>
                <li><a href="#">Link</a></li>
                <li><a href="#">Link</a></li>
                <li><a href="#">Link</a></li>
                <li class="active nobo">
                <div class="userInfo" id="userInfo" runat="server">
                </div></li>
                </ul>
            </div>
        </div>
    </div>
</body>
</html>

