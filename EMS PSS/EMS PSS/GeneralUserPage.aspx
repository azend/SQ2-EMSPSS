<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeneralUserPage.aspx.cs" Inherits="EMS_PSS.GeneralUserPage" %>

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

        .userInfo 
        {
            float:left;
            width:300px;
        }

        .clearfix
		{
			clear:both;
		}
    </style>
</head>
<body onload="noBack();"
    onpageshow="if (event.persisted) noBack();" onunload="">
    <form id="form1" runat="server">
        <div class="userInfo" id="userInfo" runat="server">
        </div>
        <div id="menuView">
            <p>Choose one of the options below</p>
            <asp:Button ID="btnCreateEmployee" runat="server" Text="Create New Employee" OnClick="btnCreateEmployee_Click" />
            <asp:Button ID="btnSeniorityReport" runat="server" Text="Generate Seniority Report" />
            <asp:Button ID="btnWeeklyHoursWorkedReport" runat="server" Text="Generate Weekly Hours Worked Report" />
        </div>

        <div class="clearfix"></div>
    </form>
</body>
</html>
