<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupListUserControl.ascx.cs" Inherits="AsusWeb.UserControl.GroupListUserControl" %>
<table align="center" width="100%">
    
    <tr>
        <td align="center" valign="top" colspan="2" width="100%">
            <asp:GridView ID="GridView1"   runat="server" AllowPaging="false" AllowSorting="false"
                AutoGenerateColumns="False"  SkinID="GridView" Width="100%" >                
                <Columns>
                    <asp:BoundField DataField="GroupName" HeaderText="¸s²Õ" ItemStyle-Width="60"  />
                    <asp:BoundField DataField="MemberUserNames" HeaderText="¤H­û" ItemStyle-HorizontalAlign="Left"  />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>