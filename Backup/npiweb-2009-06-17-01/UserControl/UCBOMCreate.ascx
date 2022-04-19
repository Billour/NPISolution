<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBOM.ascx.cs" Inherits="AsusWeb.UserControl.UCBOM" %>

<asp:Label ID="lbPageState" runat="server" Text="Create" Visible="false"></asp:Label>

<%--新增BOM資料 --%>
<asp:PlaceHolder ID="ph1" runat="server"></asp:PlaceHolder>

<ajaxToolkit:FilteredTextBoxExtender ID="ajax1" runat="server" TargetControlID="AtbPVTQty" FilterType="Numbers" />

<ajaxToolkit:FilteredTextBoxExtender ID="ajax2" runat="server" TargetControlID="AtbMPQ1Qty" FilterType="Numbers" />

<ajaxToolkit:FilteredTextBoxExtender ID="ajax3" runat="server" TargetControlID="AtbMPQ2Qty" FilterType="Numbers" />