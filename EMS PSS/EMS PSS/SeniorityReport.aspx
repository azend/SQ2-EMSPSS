<%@ Page Language="C#" MasterPageFile="~/_Layout.Master" AutoEventWireup="true" CodeBehind="SeniorityReport.aspx.cs" Inherits="EMS_PSS.SeniorityReport" %>

<asp:Content ID="Content" ContentPlaceHolderID="content" runat="server">
    <form id="form1" runat="server">
        <div class="userInfo" id="userInfo" runat="server">
        </div>
        <div id="report" runat="server">
        </div>

        <div>
            <asp:label id="lbErrorMessage" runat="server"></asp:label>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Debug" ContentPlaceHolderID="debug" runat="server">
    <li class="active nobo">
        <div class="userInfo" id="Div1" runat="server"></div>
    </li>
</asp:Content>
