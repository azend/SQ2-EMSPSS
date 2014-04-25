<%@ Page Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="SearchEmployee.aspx.cs" Inherits="EMS_PSS.SearchEmployee" %>

<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">
    <form id="searchEmployeeForm" runat="server">
        <div id="menuView">
            <blockquote><strong>Search Employees</strong></blockquote>
            <table>
                <tr>
                    <td><asp:label id="lbSearchLastName" runat="server">Last Name:</asp:label></td>
                    <td><asp:TextBox id="tbSearchLastName" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:Button id="btnSubmit" runat="server" text="Search" onClick="Submit_Click" /></td>
                    <td><asp:Button id="btnReset" runat="server" text="Reset" onClick="Reset_Click" /></td>
                </tr>
            </table>

            <div>
                <asp:label id="lbErrorMessage" runat="server"></asp:label>
            </div>

            <!-- Display Results -->
            <div class="employeeInfo" id="results" runat="server"></div>
            <!-- Prompt user to select the user ID of the employee they want to edit -->
            <div id="editID" runat="server">
                <table>
                    <tr>
                        <td><asp:label id="lbEditID" runat="server">Employee ID:</asp:label></td>
                        <td><asp:TextBox id="tbEditID" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><asp:Button id="btnEditEmployee" runat="server" text="Edit" onClick="SubmitEdit_Click" /></td>
                    </tr>
                </table>
            </div>

            <div class="clearfix"></div>
            <asp:label id="lbMessage" runat="server"></asp:label> 
            
        </div>
    </form>
</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>
