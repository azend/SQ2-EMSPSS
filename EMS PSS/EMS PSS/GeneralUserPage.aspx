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
        <div>
            <h1>Logged in as a General User</h1>
        </div>
    </form>
</body>
</html>
