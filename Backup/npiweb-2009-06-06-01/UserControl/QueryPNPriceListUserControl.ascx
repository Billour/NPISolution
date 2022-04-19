<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QueryPNPriceListUserControl.ascx.cs" Inherits="AsusWeb.UserControl.QueryPNPriceListUserControl" %>
<table align="center" width="100%">
    <tr>
    <td align="right">
         
        </td>
        <td align="left">
            元件料號<asp:TextBox ID="tbPN" runat="server"></asp:TextBox><asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
        </td>
    </tr>
    <tr>
        <td align="left" valign="middle" colspan="2" width="100%">
            <asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" valign="top" colspan="2" width="100%">
            <asp:GridView ID="GridView1"   runat="server" AllowPaging="false" AutoGenerateColumns="False"  SkinID="GridView" Width="100%" >                
                
            </asp:GridView>
        </td>
    </tr>
</table>