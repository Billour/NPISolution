<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGenList.ascx.cs" Inherits="AsusWeb.UserControl.UCGenList" %>

<!--���� Genid -->
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
            <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AllowSorting="False"
                AutoGenerateColumns="False"  PageSize="10" SkinID="GridView" Width="100%" OnRowCommand="GridView1_RowCommand" DataKeyNames="MainId,WorkStatus">                
                <Columns>
                    <asp:BoundField DataField="MainName" HeaderText="���ͤ��" ItemStyle-HorizontalAlign="Center" />
                    <asp:ButtonField ButtonType="Link" HeaderText="�U��Excel" Text="�U���^��Excel" ItemStyle-HorizontalAlign="Center" CommandName="ModifyCommand" />
                    <asp:ButtonField ButtonType="Link" HeaderText="�W��Excel" Text="�W��Excel" ItemStyle-HorizontalAlign="Center" CommandName="ModifyCommand2" />
                    <asp:ButtonField ButtonType="Link" HeaderText="�[�ݦ^�е��G" Text="�[�ݦ^�е��G" ItemStyle-HorizontalAlign="Center" CommandName="ModifyCommand3" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>