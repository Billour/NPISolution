<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCResponseList.ascx.cs" Inherits="AsusWeb.UserControl.UCResponseList" %>
<table align="center" width="100%">
    <tr>
        <td align="right">
            �^�Ъ��p�G<asp:DropDownList ID="ddlEnable" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEnable_SelectedIndexChanged">
                <asp:ListItem Text="������" Value="N"></asp:ListItem>
                <asp:ListItem Text="�w����" Value="Y"></asp:ListItem>
                <asp:ListItem Text="����" Value="A"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="center" valign="top"  width="100%">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False"  PageSize="10" SkinID="GridView" Width="100%" OnRowCommand="GridView1_RowCommand" DataKeyNames="FormId,FormStatus">                
                
            </asp:GridView>
        </td>
    </tr>
</table>