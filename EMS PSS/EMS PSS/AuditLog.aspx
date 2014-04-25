<%@ Page Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="AuditLog.aspx.cs" Inherits="EMS_PSS.AuditLog" %>

<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">

    <form runat="server">
    <asp:ListView ID="AuditLogListView" runat="server" DataSourceID="AuditLogDataSource">
        <AlternatingItemTemplate>
            <span style="">LogId:
            <asp:Label ID="LogIdLabel" runat="server" Text='<%# Eval("LogId") %>' />
            <br />
            EmployeeId:
            <asp:Label ID="EmployeeIdLabel" runat="server" Text='<%# Eval("EmployeeId") %>' />
            <br />
            Action:
            <asp:Label ID="ActionLabel" runat="server" Text='<%# Eval("Action") %>' />
            <br />
            UserId:
            <asp:Label ID="UserIdLabel" runat="server" Text='<%# Eval("UserId") %>' />
            <br />
            AttributeChanged:
            <asp:Label ID="AttributeChangedLabel" runat="server" Text='<%# Eval("AttributeChanged") %>' />
            <br />
            OldValue:
            <asp:Label ID="OldValueLabel" runat="server" Text='<%# Eval("OldValue") %>' />
            <br />
            NewValue:
            <asp:Label ID="NewValueLabel" runat="server" Text='<%# Eval("NewValue") %>' />
            <br />
            EventTime:
            <asp:Label ID="EventTimeLabel" runat="server" Text='<%# Eval("EventTime") %>' />
            <br />
            <br />
            </span>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <span style="">LogId:
            <asp:TextBox ID="LogIdTextBox" runat="server" Text='<%# Bind("LogId") %>' />
            <br />
            EmployeeId:
            <asp:TextBox ID="EmployeeIdTextBox" runat="server" Text='<%# Bind("EmployeeId") %>' />
            <br />
            Action:
            <asp:TextBox ID="ActionTextBox" runat="server" Text='<%# Bind("Action") %>' />
            <br />
            UserId:
            <asp:TextBox ID="UserIdTextBox" runat="server" Text='<%# Bind("UserId") %>' />
            <br />
            AttributeChanged:
            <asp:TextBox ID="AttributeChangedTextBox" runat="server" Text='<%# Bind("AttributeChanged") %>' />
            <br />
            OldValue:
            <asp:TextBox ID="OldValueTextBox" runat="server" Text='<%# Bind("OldValue") %>' />
            <br />
            NewValue:
            <asp:TextBox ID="NewValueTextBox" runat="server" Text='<%# Bind("NewValue") %>' />
            <br />
            EventTime:
            <asp:TextBox ID="EventTimeTextBox" runat="server" Text='<%# Bind("EventTime") %>' />
            <br />
            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            <br />
            <br />
            </span>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <span>No data was returned.</span>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <span style="">LogId:
            <asp:TextBox ID="LogIdTextBox" runat="server" Text='<%# Bind("LogId") %>' />
            <br />
            EmployeeId:
            <asp:TextBox ID="EmployeeIdTextBox" runat="server" Text='<%# Bind("EmployeeId") %>' />
            <br />
            Action:
            <asp:TextBox ID="ActionTextBox" runat="server" Text='<%# Bind("Action") %>' />
            <br />
            UserId:
            <asp:TextBox ID="UserIdTextBox" runat="server" Text='<%# Bind("UserId") %>' />
            <br />
            AttributeChanged:
            <asp:TextBox ID="AttributeChangedTextBox" runat="server" Text='<%# Bind("AttributeChanged") %>' />
            <br />
            OldValue:
            <asp:TextBox ID="OldValueTextBox" runat="server" Text='<%# Bind("OldValue") %>' />
            <br />
            NewValue:
            <asp:TextBox ID="NewValueTextBox" runat="server" Text='<%# Bind("NewValue") %>' />
            <br />
            EventTime:
            <asp:TextBox ID="EventTimeTextBox" runat="server" Text='<%# Bind("EventTime") %>' />
            <br />
            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
            <br />
            <br />
            </span>
        </InsertItemTemplate>
        <ItemTemplate>
            <span style="">LogId:
            <asp:Label ID="LogIdLabel" runat="server" Text='<%# Eval("LogId") %>' />
            <br />
            EmployeeId:
            <asp:Label ID="EmployeeIdLabel" runat="server" Text='<%# Eval("EmployeeId") %>' />
            <br />
            Action:
            <asp:Label ID="ActionLabel" runat="server" Text='<%# Eval("Action") %>' />
            <br />
            UserId:
            <asp:Label ID="UserIdLabel" runat="server" Text='<%# Eval("UserId") %>' />
            <br />
            AttributeChanged:
            <asp:Label ID="AttributeChangedLabel" runat="server" Text='<%# Eval("AttributeChanged") %>' />
            <br />
            OldValue:
            <asp:Label ID="OldValueLabel" runat="server" Text='<%# Eval("OldValue") %>' />
            <br />
            NewValue:
            <asp:Label ID="NewValueLabel" runat="server" Text='<%# Eval("NewValue") %>' />
            <br />
            EventTime:
            <asp:Label ID="EventTimeLabel" runat="server" Text='<%# Eval("EventTime") %>' />
            <br />
            <br />
            </span>
        </ItemTemplate>
        <LayoutTemplate>
            <div id="itemPlaceholderContainer" runat="server" style="">
                <span runat="server" id="itemPlaceholder" />
            </div>
            <div style="">
            </div>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <span style="">LogId:
            <asp:Label ID="LogIdLabel" runat="server" Text='<%# Eval("LogId") %>' />
            <br />
            EmployeeId:
            <asp:Label ID="EmployeeIdLabel" runat="server" Text='<%# Eval("EmployeeId") %>' />
            <br />
            Action:
            <asp:Label ID="ActionLabel" runat="server" Text='<%# Eval("Action") %>' />
            <br />
            UserId:
            <asp:Label ID="UserIdLabel" runat="server" Text='<%# Eval("UserId") %>' />
            <br />
            AttributeChanged:
            <asp:Label ID="AttributeChangedLabel" runat="server" Text='<%# Eval("AttributeChanged") %>' />
            <br />
            OldValue:
            <asp:Label ID="OldValueLabel" runat="server" Text='<%# Eval("OldValue") %>' />
            <br />
            NewValue:
            <asp:Label ID="NewValueLabel" runat="server" Text='<%# Eval("NewValue") %>' />
            <br />
            EventTime:
            <asp:Label ID="EventTimeLabel" runat="server" Text='<%# Eval("EventTime") %>' />
            <br />
            <br />
            </span>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="AuditLogDataSource" runat="server" DataObjectTypeName="EMS_PSS.App_Code.Log" InsertMethod="InsertAuditLog" SelectMethod="GetAuditLogs" TypeName="EMS_PSS.App_Code.AuditLogModel"></asp:ObjectDataSource>
    </form>
</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="userInfo" runat="server"></div>
    </li>
</asp:Content>
