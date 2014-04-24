<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEmployee.aspx.cs" Inherits="EMS_PSS.CreateEmployee" %>

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

        .employeeInfo
        {
            float:left;
            width:600px;
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

        <div class="employeeInfo" runat="server">
            <div id="baseEmployee" visible="true" runat="server">
                <h1>Create Employee Menu</h1>
                <table>
                    <tr>
                        <td><asp:label id="lbEmployeeType" runat="server">Employee Type:</asp:label></td>
                        <td>
                            <asp:DropDownList id="ddlEmployeeType" runat="server">
                                <asp:ListItem>Full-time</asp:ListItem>
                                <asp:ListItem>Part-time</asp:ListItem>
                                <asp:ListItem>Seasonal</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:label id="lbFirstName" runat="server">First Name:</asp:label></td>
                        <td><asp:TextBox id="tbFirstName" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><asp:label id="lbLastName" runat="server">Last Name:</asp:label></td>
                        <td><asp:TextBox id="tbLastName" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><asp:label id="lbCompany" runat="server">Company:</asp:label></td>
                        <td><asp:TextBox id="tbCompany" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><asp:label id="lbSIN" runat="server">SIN:</asp:label></td>
                        <td><asp:TextBox id="tbSIN" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><asp:label id="lbDateOfBirth" runat="server">Date of Birth*:</asp:label></td>
                        <td><asp:TextBox id="tbDateOfBirth" runat="server" /></td>
                    </tr>

                    <tr>
                        <td><asp:Button id="btnSubmit" runat="server" text="Submit" onClick="Submit_Click" /></td>
                        <td><asp:Button id="btnReset" runat="server" text="Reset" onClick="Reset_Click" /></td>
                    </tr>
                </table>
            </div>

            <div id="fullAndPartTimeEmployee" visible="false" runat="server">
                <h1>Full/Part time Employee Specifics</h1>
                <table>
                    <tr>
                        <td><asp:label id="lbDateOfHire" runat="server">Date of Hire*:</asp:label></td>
                        <td><asp:TextBox id="tbDateOfHire" runat="server" /></td>
                    </tr>
                    
                    <tr>
                        <td><asp:Button id="btnCommit" runat="server" text="Commit" onClick="btnCommit_Click" /></td>
                        <td><asp:Button id="btnReset2" runat="server" text="Reset" onClick="Reset_Click" /></td
                    </tr>
                </table>
            </div>

            <div id="seasonalEmployee" visible="false" runat="server">
                <h1>Seasonal Employee Specifics</h1>
                <table>
                    <tr>
                        <td><asp:label id="lbSeason" runat="server">Season:</asp:label></td>
                        <td>
                            <asp:DropDownList id="ddlSeason" runat="server">
                                <asp:ListItem>SPRING</asp:ListItem>
                                <asp:ListItem>SUMMER</asp:ListItem>
                                <asp:ListItem>FALL</asp:ListItem>
                                <asp:ListItem>WINTER</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:label id="lbYear" runat="server">Year:</asp:label></td>
                        <td><asp:TextBox id="tbYear" runat="server" /></td>
                    </tr>

                    <tr>
                        <td><asp:Button id="btnCommit2" runat="server" text="Commit" onClick="btnCommit_Click" /></td>
                        <td><asp:Button id="btnReset3" runat="server" text="Reset" onClick="Reset_Click" /></td>
                    </tr>
                </table>
            </div>

            <p>*Date format in YYYY-MM-DD</p>
            <asp:label id="lbMessage" runat="server"></asp:label>  
        </div>

        <div class="clearfix"></div>

    </form>
</body>
</html>
