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
        <asp:ListView ID="ListView1" runat="server" DataSourceID="EmployeeDataSource">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
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
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
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
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                    <th runat="server">FirstName</th>
                                    <th runat="server">LastName</th>
                                    <th runat="server">Sin</th>
                                    <th runat="server">DateOfBirth</th>
                                    <th runat="server">EmployeeType</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
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
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="EmployeeDataSource" runat="server" SelectMethod="GetEmployees" TypeName="EMS_PSS.App_Code.EmployeeModel"></asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
