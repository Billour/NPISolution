<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGenList.ascx.cs" Inherits="AsusWeb.UserControl.UCGenList" %>

<!--產生 Genid -->
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
            <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AllowSorting="False"
                AutoGenerateColumns="False"  PageSize="10" SkinID="GridView" Width="100%" OnRowCommand="GridView1_RowCommand" DataKeyNames="MainId,WorkStatus">                
                <Columns>
                    <asp:BoundField DataField="MainName" HeaderText="產生日期" ItemStyle-HorizontalAlign="Center" />
                    <asp:ButtonField ButtonType="Link" HeaderText="下載Excel" Text="下載回覆Excel" ItemStyle-HorizontalAlign="Center" CommandName="ModifyCommand" />
                    <asp:ButtonField ButtonType="Link" HeaderText="上傳Excel" Text="上傳Excel" ItemStyle-HorizontalAlign="Center" CommandName="ModifyCommand2" />
                    <asp:ButtonField ButtonType="Link" HeaderText="觀看回覆結果" Text="觀看回覆結果" ItemStyle-HorizontalAlign="Center" CommandName="ModifyCommand3" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>