<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBOMList.ascx.cs" Inherits="AsusWeb.UserControl.UCBOMList" %>

<table align="center" width="100%">
    <tr>
    <td align="left">
            是否結案：
            <asp:DropDownList ID="ddlIsClose" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlIsClose_SelectedIndexChanged">
                <asp:ListItem Text="是" Value="Y"></asp:ListItem>
                <asp:ListItem Text="否" Value="N" Selected="True"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td align="right">
            是否開啟：
            <asp:DropDownList ID="ddlEnable" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEnable_SelectedIndexChanged">
                <asp:ListItem Text="是" Value="Y" Selected="True"></asp:ListItem>
                <asp:ListItem Text="否" Value="N"></asp:ListItem>
                <asp:ListItem Text="全部" Value="A"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="center" valign="top" colspan="2" width="100%">
            <asp:GridView ID="GridView1"   runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False"  PageSize="10" SkinID="GridView" Width="100%" OnRowCommand="GridView1_RowCommand" DataKeyNames="EmpId,BOMId">                
                
            </asp:GridView>
        </td>
    </tr>
</table>