<%@ Page Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="SearchEmployee.aspx.cs" Inherits="EMS_PSS.SearchEmployee" %>

<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">
    <form id="searchEmployeeForm" runat="server">
        <div id="menuView">
            <blockquote><strong>Search Employees</strong></blockquote>
            <table>
                <tr>
                    <td><asp:label id="lbLastName" runat="server">Last Name:</asp:label></td>
                    <td><asp:TextBox id="tbLastName" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:Button id="btnSubmit" runat="server" text="Submit" onClick="Submit_Click" /></td>
                    <td><asp:Button id="btnReset" runat="server" text="Reset" onClick="Reset_Click" /></td>
                </tr>
            </table>
            <div class="clearfix"></div>

            <!-- Display Results -->
            <div class="employeeInfo" id="Div1" runat="server"></div>
            
        </div>
    </form>
</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>
