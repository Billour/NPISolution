<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BOMListUserControl.ascx.cs" Inherits="AsusWeb.UserControl.BOMListUserControl" %>
<table align="center" width="100%">
    <tr>
        <td align="center" valign="top" colspan="2" width="100%">
            <asp:GridView ID="GridView1"   runat="server" AllowPaging=false AllowSorting=false
                AutoGenerateColumns="False"  PageSize="10" SkinID="GridView" Width="100%" >                
                
            </asp:GridView>
        </td>
    </tr>
</table>