<%@ Page Title="" Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="EMS_PSS.AdminPage" %>
<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">

    <form id="form1" runat="server">

<<<<<<< HEAD
        <div id="menuView">
            <p>Choose one of the options below</p>
            <asp:Button ID="btnCreateEmployee" runat="server" Text="Create New Employee" OnClick="btnCreateEmployee_Click" /><br />
=======
    <title>EMS-PSS - Admin Home</title>

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
>>>>>>> 7e7f458ba4fa277ab7740ff348a05b39229fcf8d
        </div>

        <div class="clearfix"></div>
    </form>

</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>
