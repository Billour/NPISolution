<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRuleList.ascx.cs" Inherits="AsusWeb.UserControl.UCRuleList" %>
<!--設定網頁狀態 請不要隨便修改-->
<asp:Label ID="lbPageState" runat="server" Text="Create" Visible="false"></asp:Label>


<!--加入此規則程式 -->
<table align="center" width="100%">
    <tr>
        <td align="right">
           <asp:PlaceHolder ID="ph1" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
    <tr>
        <td align="right">
           <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="func" Text="存檔" ></asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td align="right">
            <hr />
            是否啟用：<asp:DropDownList ID="ddlEnable" runat="server">
                <asp:ListItem Text="是" Value="Y"></asp:ListItem>
                <asp:ListItem Text="否" Value="N"></asp:ListItem>
                <asp:ListItem Text="全部" Value="A"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="center" valign="top"  width="100%">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False"  PageSize="10" SkinID="GridView" Width="100%" OnRowCommand="GridView1_RowCommand">                
                
            </asp:GridView>
        </td>
    </tr>
</table>