<%@ Page Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="TimeCardEntry.aspx.cs" Inherits="EMS_PSS.TimeCardEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <blockquote><strong>TimeCard Entry</strong></blockquote>
    <form id="form1" runat="server">
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
</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>
