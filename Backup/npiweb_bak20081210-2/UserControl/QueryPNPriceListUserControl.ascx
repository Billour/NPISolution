<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QueryPNPriceListUserControl.ascx.cs" Inherits="AsusWeb.UserControl.QueryPNPriceListUserControl" %>
<table align="center" width="100%">
    <tr>
    <td align="left">
            
        </td>
        <td align="right">
            ±ø¥ó
        </td>
    </tr>
    <tr>
        <td align="center" valign="top" colspan="2" width="100%">
            <asp:GridView ID="GridView1"   runat="server" AllowPaging="True" AutoGenerateColumns="False"  PageSize="10" SkinID="GridView" Width="100%" >                
                
            </asp:GridView>
        </td>
    </tr>
</table>