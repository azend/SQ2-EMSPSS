<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EMS_PSS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    </style>
</head>
<body>
    <form id="form1" runat="server">

    <h1>EMS-PSS Login Page</h1>

    <div class="userInfo">
        <table>
            <tr>
                <td><label for="userName">User Name:</label></td>
                <td><input id="userName" type ="text" /></td>
            </tr>

            <tr>
                <td><label for="password">Password:</label></td>
                <td><input id="password" type="text" /></td>
            </tr>
            
            <tr>
                <td><input type="button" id="login" value="Login" /></td>
                <td><input type="button" id="reset" value="Reset" /></td>
            </tr>    
        </table>
         
    </div>
    </form>
</body>
</html>
