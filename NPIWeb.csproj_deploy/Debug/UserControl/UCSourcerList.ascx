<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSourcerList.ascx.cs" Inherits="AsusWeb.UserControl.UCSourcerList" %>
<table align="center" width="100%">
    <tr>
    <td>
          ����Ƹ��G
            <asp:DropDownList ID="ddlComponent" runat="server" AutoPostBack=true OnSelectedIndexChanged="ddlComponent_SelectedIndexChanged">
               
            </asp:DropDownList>
    </td>
        <td align="right">
            �H���O�_���ġG<asp:DropDownList ID="ddlEnable" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEnable_SelectedIndexChanged">
                <asp:ListItem Text="�O" Value="Y"></asp:ListItem>
                <asp:ListItem Text="�_" Value="N"></asp:ListItem>
                <asp:ListItem Text="����" Value="A"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="center" valign="top"  width="100%" colspan="2">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False"  PageSize="10" SkinID="GridView" Width="100%" OnRowCommand="GridView1_RowCommand" DataKeyNames="AccountNo">                
                
            </asp:GridView>
        </td>
    </tr>
</table>