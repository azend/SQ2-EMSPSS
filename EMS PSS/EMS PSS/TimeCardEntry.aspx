<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeCardEntry.aspx.cs" Inherits="EMS_PSS.TimeCardEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EMS - TimeCards</title>
    <style type="text/css">
        .auto-style1 {
            width: 149px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="heading">
    <h1>TimeCard Entry</h1>
    </div>
    <div id="userInfo" runat="server">

    </div>
    <div id="TimeCardSettings">
        <asp:Button ID="TimecardPage" runat="server" Text="Time Cards" OnClick="TimecardPage_Click" /><asp:Button ID="WeekEntryPage" runat="server" Text="Week Creation" OnClick="WeekEntryPage_Click" />
    </div>
    <div id="TimeCardForm" visible="false" runat="server" >
    <table>
            <tr>
                    <td>Select Work Week:</td> 
                    <td>
                    <asp:ListBox ID="Workweek" runat="server" OnSelectedIndexChanged="Workweek_SelectedIndexChanged" Width="211px"> </asp:ListBox>
                    </td>
            </tr>
            <tr>
                    <td>Enter EmployeeID:</td> 
                    <td>
                    <asp:TextBox ID="EmployeeId" runat="server" Width="209px"></asp:TextBox> 
                    </td>
            </tr>
             <tr>
                    <td>Enter Monday Hours </td> 
                    <td><asp:TextBox ID="MondayHours" runat="server" Width="209px"></asp:TextBox></td>
            </tr>
                     <tr>
                    <td>Enter Tuesday Hours </td> 
                    <td><asp:TextBox ID="TuesdayHours" runat="server" style="margin-right: 3px" Width="208px"></asp:TextBox></td>
            </tr>
                     <tr>
                    <td>Enter Wednesday Hours </td> 
                    <td><asp:TextBox ID="WednesdayHours" runat="server" Width="210px"></asp:TextBox></td>
            </tr>
                     <tr>
                    <td>Enter Thursday Hours </td> 
                    <td><asp:TextBox ID="ThursdayHours" runat="server" Width="211px"></asp:TextBox></td>
            </tr>
                     <tr>
                    <td>Enter Friday Hours </td> 
                    <td><asp:TextBox ID="FridayHours" runat="server" Width="210px"></asp:TextBox></td>
            </tr>
                     <tr>
                    <td>Enter Saturday Hours </td> 
                    <td><asp:TextBox ID="SaturdayHours" runat="server" Width="209px"></asp:TextBox></td>
            </tr>
                     <tr>
                    <td>Enter Sunday Hours </td> 
                    <td><asp:TextBox ID="SundayHours" runat="server" Width="211px"></asp:TextBox></td>
                    </tr>
                 <tr>


    </table>
    </div>
        <div id="EnterNewWorkWeek" visible="false" runat="server">
            <table>
                <tr>
                    <td class="auto-style1"> Select a monday on the calender to start a new work week! </td>
                    <td>
                        <asp:Calendar ID="StartOfWeek" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar> </td>
                </tr>

            </table>

        </div >
        <table>   
            <tr>
                   <td > <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
                     <asp:Button ID="Reset" runat="server" Text="Reset" />
                   </td>
            </tr></table>
         <div id="Error">
             <asp:Label ID="lbMessage" runat="server" Text="Label"></asp:Label>
        </div >
    </form>
</body>
</html>
