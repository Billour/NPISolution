<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRuleList.ascx.cs" Inherits="AsusWeb.UserControl.UCRuleList" %>
<!--�]�w�������A �Ф��n�H�K�ק�-->
<asp:Label ID="lbPageState" runat="server" Text="Create" Visible="false"></asp:Label>


<!--�[�J���W�h�{�� -->
<table align="center" width="100%">
    <tr>
        <td align="right">
           <asp:PlaceHolder ID="ph1" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
    <tr>
        <td align="right">
           <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="func" Text="�s��" ></asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td align="right">
            <hr />
            �O�_�ҥΡG<asp:DropDownList ID="ddlEnable" runat="server">
                <asp:ListItem Text="�O" Value="Y"></asp:ListItem>
                <asp:ListItem Text="�_" Value="N"></asp:ListItem>
                <asp:ListItem Text="����" Value="A"></asp:ListItem>
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