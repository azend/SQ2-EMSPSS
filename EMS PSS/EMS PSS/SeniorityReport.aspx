<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeniorityReport.aspx.cs" Inherits="EMS_PSS.SeniorityReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
<body>
    <form id="form1" runat="server">
        <div class="userInfo" id="userInfo" runat="server">
        </div>
        <div id="report" runat="server">
        </div>

        <div>
            <asp:label id="lbErrorMessage" runat="server"></asp:label>
        </div>
    </form>
</body>
</html>
