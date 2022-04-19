<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCResponseList.ascx.cs" Inherits="AsusWeb.UserControl.UCResponseList" %>
<table align="center" width="100%">
    <tr>
        <td align="right">
            回覆狀況：<asp:DropDownList ID="ddlEnable" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEnable_SelectedIndexChanged">
                <asp:ListItem Text="未結案" Value="N"></asp:ListItem>
                <asp:ListItem Text="已結案" Value="Y"></asp:ListItem>
                <asp:ListItem Text="全部" Value="A"></asp:ListItem>
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