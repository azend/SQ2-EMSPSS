<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeCardEntry.aspx.cs" Inherits="EMS_PSS.TimeCardEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EMS - TimeCards</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="heading">
    <h1>TimeCard Entry</h1>
    </div>
    <div id="userInfo" runat="server">

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
</body>
</html>
