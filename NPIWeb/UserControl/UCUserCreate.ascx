<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCUserEdit.ascx.cs" Inherits="AsusWeb.UserControl.UCUserEdit" %>
<%@ Register Src="UCRuleList.ascx" TagName="UCRuleList" TagPrefix="uc1" %>

<asp:Label ID="lbPageState" runat="server" Text="Create" Visible="false"></asp:Label>

<%--建立使用者資料 --%>
<asp:PlaceHolder ID="ph1" runat="server"></asp:PlaceHolder>


