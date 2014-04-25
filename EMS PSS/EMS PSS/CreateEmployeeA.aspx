<%@ Page Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="CreateEmployeeA.aspx.cs" Inherits="EMS_PSS.CreateEmployeeA" %>
<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">
    <form id="createEmployeeForm" runat="server">

            <div id="Div1" class="employeeInfo" runat="server">
                <div id="baseEmployee" visible="true" runat="server">
                    <blockquote><strong>Create Employee Menu</strong></blockquote>
                    <table>
                        <tr>
                            <td><asp:label id="lbEmployeeType" runat="server">Employee Type:</asp:label></td>
                            <td>
                                <asp:DropDownList id="ddlEmployeeType" runat="server">
                                    <asp:ListItem>Full-time</asp:ListItem>
                                    <asp:ListItem>Part-time</asp:ListItem>
                                    <asp:ListItem>Seasonal</asp:ListItem>
                                    <asp:ListItem>Contract</asp:ListItem>
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
                            <td class="auto-style1"><asp:label id="lbDateOfHire" runat="server">Date of Hire*:</asp:label></td>
                            <td class="auto-style1"><asp:TextBox id="tbDateOfHire" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><asp:label id="lbDateOfBirth" runat="server">Date of Birth*:</asp:label></td>
                            <td class="auto-style1"><asp:TextBox id="tbDateOfBirth" runat="server" /></td>
                        </tr>

                        <tr>
                            <td><asp:Button id="btnSubmit" runat="server" text="Submit" onClick="Submit_Click" /></td>
                            <td><asp:Button id="btnReset" runat="server" text="Reset" onClick="Reset_Click" /></td>
                        </tr>
                    </table>
                    <p>*Date format in YYYY-MM-DD</p>
                </div>

                <div id="fullAndPartTimeEmployee" visible="false" runat="server">
                    <blockquote><strong>Full/Part time Employee Specifics</strong></blockquote>
                    <table>
                        <tr>
                            <td class="auto-style1"><asp:label id="lbWage" visible="false" runat="server">Hourly Wage:</asp:label></td>
                            <td class="auto-style1"><asp:TextBox id="tbWage" visible="false" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><asp:label id="lbSalary" visible="false" runat="server">Salary:</asp:label></td>
                            <td class="auto-style1"><asp:TextBox id="tbSalary" visible="false" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><asp:Button id="btnCommit" runat="server" text="Commit" onClick="btnCommit_Click" /></td>
                            <td><asp:Button id="btnReset2" runat="server" text="Reset" onClick="Reset_Click" /></td>
                        </tr>
                        <tr>
                            <td><asp:label id="confirm1" runat="server">Are you sure you want to submit?</asp:label></td>
                        </tr>
                    </table>
                </div>

                <div id="seasonalEmployee" visible="false" runat="server">
                    <blockquote><strong>Seasonal Employee Specifics</strong></blockquote>
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
                            <td><asp:label id="lbPiecePay" runat="server">Piece Pay:</asp:label></td>
                            <td><asp:TextBox id="tbPiecePay" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><asp:label id="confirm2" runat="server">Are you sure you want to submit?</asp:label></td>
                        </tr>
                        <tr>
                            <td><asp:Button id="btnCommit2" runat="server" text="Commit" onClick="btnCommit_Click" /></td>
                            <td><asp:Button id="btnReset3" runat="server" text="Reset" onClick="Reset_Click" /></td>
                        </tr>
                    </table>
                </div>

                <div id="contractEmployee" visible="false" runat="server">
                    <blockquote><strong>Contract Employee Specifics</strong></blockquote>
                    <table>
                        <tr>
                            <td><asp:label id="lbContractEnd" runat="server">Contract Ends*:</asp:label></td>
                            <td><asp:TextBox id="tbContractEnd" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><asp:label id="lbFixedAmount" runat="server">Fixed Amount:</asp:label></td>
                            <td><asp:TextBox id="tbFixedAmount" runat="server" /></td>
                        </tr>
                        <tr>
                            <td><asp:label id="Label4" runat="server">Are you sure you want to submit?</asp:label></td>
                        </tr>
                        <tr>
                            <td><asp:Button id="btnCommit3" runat="server" text="Commit" onClick="btnCommit_Click" /></td>
                            <td><asp:Button id="btnReset4" runat="server" text="Reset" onClick="Reset_Click" /></td>
                        </tr>
                    </table>
                    <p>*Date format in YYYY-MM-DD</p>
                </div>

                <asp:label id="lbMessage" runat="server"></asp:label>  
            </div>

            <div class="clearfix"></div>

        </form>
</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>
