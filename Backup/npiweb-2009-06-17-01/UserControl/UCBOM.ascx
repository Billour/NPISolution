<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBOM.ascx.cs" Inherits="AsusWeb.UserControl.UCBOM" %>

<asp:Label ID="lbPageState" runat="server" Text="Modify" Visible="false"></asp:Label>

<%--­×§ïBOM¸ê®Æ --%>
<asp:PlaceHolder ID="ph1" runat="server"></asp:PlaceHolder>

<%--<asp:TextBox ID="AA" runat="server"></asp:TextBox>

<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="AA" FilterType="Numbers" />--%>

<ajaxToolkit:FilteredTextBoxExtender ID="ajax1" runat="server" TargetControlID="AtbPVTQty" FilterType="Numbers" />

<ajaxToolkit:FilteredTextBoxExtender ID="ajax2" runat="server" TargetControlID="AtbMPQ1Qty" FilterType="Numbers" />

<ajaxToolkit:FilteredTextBoxExtender ID="ajax3" runat="server" TargetControlID="AtbMPQ2Qty" FilterType="Numbers" />
