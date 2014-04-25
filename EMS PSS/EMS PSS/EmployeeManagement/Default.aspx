<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EMS_PSS.EmployeeManagement.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%: Page.Title %>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="EmployeeDataSource" InsertItemPosition="LastItem">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SinLabel" runat="server" Text='<%# Eval("Sin") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DateOfBirthLabel" runat="server" Text='<%# Eval("DateOfBirth") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EmployeeTypeLabel" runat="server" Text='<%# Eval("EmployeeType") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CompanyLabel" runat="server" Text='<%# Eval("Company") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="SinTextBox" runat="server" Text='<%# Bind("Sin") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DateOfBirthTextBox" runat="server" Text='<%# Bind("DateOfBirth") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EmployeeTypeTextBox" runat="server" Text='<%# Bind("EmployeeType") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CompanyTextBox" runat="server" Text='<%# Bind("Company") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="SinTextBox" runat="server" Text='<%# Bind("Sin") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DateOfBirthTextBox" runat="server" Text='<%# Bind("DateOfBirth") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EmployeeTypeTextBox" runat="server" Text='<%# Bind("EmployeeType") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CompanyTextBox" runat="server" Text='<%# Bind("Company") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SinLabel" runat="server" Text='<%# Eval("Sin") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DateOfBirthLabel" runat="server" Text='<%# Eval("DateOfBirth") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EmployeeTypeLabel" runat="server" Text='<%# Eval("EmployeeType") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CompanyLabel" runat="server" Text='<%# Eval("Company") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                    <th runat="server"></th>
                                    <th runat="server">FirstName</th>
                                    <th runat="server">LastName</th>
                                    <th runat="server">Sin</th>
                                    <th runat="server">DateOfBirth</th>
                                    <th runat="server">EmployeeType</th>
                                    <th runat="server">Company</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SinLabel" runat="server" Text='<%# Eval("Sin") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DateOfBirthLabel" runat="server" Text='<%# Eval("DateOfBirth") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EmployeeTypeLabel" runat="server" Text='<%# Eval("EmployeeType") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CompanyLabel" runat="server" Text='<%# Eval("Company") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="EmployeeDataSource" runat="server" SelectMethod="GetEmployees" TypeName="EMS_PSS.App_Code.EmployeeModel" DataObjectTypeName="AllEmployees.Employee" OnInserting="EmployeeDataSource_Inserting">
        </asp:ObjectDataSource>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="EmployeeDataSource" DefaultMode="Insert">
            <EditItemTemplate>
                FirstName:
                <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                <br />
                LastName:
                <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                <br />
                Sin:
                <asp:TextBox ID="SinTextBox" runat="server" Text='<%# Bind("Sin") %>' />
                <br />
                DateOfBirth:
                <asp:TextBox ID="DateOfBirthTextBox" runat="server" Text='<%# Bind("DateOfBirth") %>' />
                <br />
                EmployeeType:
                <asp:TextBox ID="EmployeeTypeTextBox" runat="server" Text='<%# Bind("EmployeeType") %>' />
                <br />
                Company:
                <asp:TextBox ID="CompanyTextBox" runat="server" Text='<%# Bind("Company") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                FirstName:
                <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                <br />
                LastName:
                <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                <br />
                Sin:
                <asp:TextBox ID="SinTextBox" runat="server" Text='<%# Bind("Sin") %>' />
                <br />
                DateOfBirth:
                <asp:TextBox ID="DateOfBirthTextBox" runat="server" Text='<%# Bind("DateOfBirth") %>' />
                <br />
                EmployeeType:
                <asp:TextBox ID="EmployeeTypeTextBox" runat="server" Text='<%# Bind("EmployeeType") %>' />
                <br />
                Company:
                <asp:TextBox ID="CompanyTextBox" runat="server" Text='<%# Bind("Company") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                FirstName:
                <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Bind("FirstName") %>' />
                <br />
                LastName:
                <asp:Label ID="LastNameLabel" runat="server" Text='<%# Bind("LastName") %>' />
                <br />
                Sin:
                <asp:Label ID="SinLabel" runat="server" Text='<%# Bind("Sin") %>' />
                <br />
                DateOfBirth:
                <asp:Label ID="DateOfBirthLabel" runat="server" Text='<%# Bind("DateOfBirth") %>' />
                <br />
                EmployeeType:
                <asp:Label ID="EmployeeTypeLabel" runat="server" Text='<%# Bind("EmployeeType") %>' />
                <br />

                Company:
                <asp:Label ID="CompanyLabel" runat="server" Text='<%# Bind("Company") %>' />
                <br />
                <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />

            </ItemTemplate>
        </asp:FormView>
    </div>
    </form>
</body>
</html>
