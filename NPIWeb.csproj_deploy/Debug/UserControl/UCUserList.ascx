<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCUserList.ascx.cs" Inherits="AsusWeb.UserControl.UCUserList" %>
<!--使用者列表 -->

<table align="center" width="100%">
    <tr>
        <td align="right">
            是否啟用：<asp:DropDownList ID="ddlEnable" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEnable_SelectedIndexChanged">
                <asp:ListItem Text="是" Value="Y"></asp:ListItem>
                <asp:ListItem Text="否" Value="N"></asp:ListItem>
                <asp:ListItem Text="全部" Value="A"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="center" valign="top"  width="100%">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False"  PageSize="10" SkinID="GridView" Width="100%" OnRowCommand="GridView1_RowCommand" DataKeyNames="AccountNo">                
                
            </asp:GridView>
        </td>
    </tr>
</table>