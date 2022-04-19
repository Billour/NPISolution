<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendMailPNListUserControl.ascx.cs" Inherits="AsusWeb.UserControl.SendMailPNListUserControl" %>
<table align="center" width="100%">
    
    <tr>
    <td width="90%" >
        <asp:Label ID="lbUserMessage" runat="server"></asp:Label>
    </td>
    </tr>
    <tr>
        <td align="center" valign="top" width="90%">
            <asp:GridView ID="GridView1"   runat="server" AllowPaging="false" AutoGenerateColumns="False"  SkinID="GridView" Width="90%" >                
                
            </asp:GridView>
        </td>
    </tr>
</table>