<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UploadExcelUserControl.ascx.cs"
    Inherits="AsusWeb.UserControl.UploadExcelUserControl" %>
<table align="center" width="100%">
    <tr>
        <td align="left" style="background-color: #5B6DB5; color: White">
            �Ĥ@�B�J�G�W��Excel
        </td>
    </tr>
    <tr>
        <td align="center" valign="top" width="100%">
            <asp:FileUpload ID="fpExcelUppload" runat="server" /><br />
            <asp:LinkButton ID="btnUpload" runat="server" CssClass="func" Text="�W��" OnClick="btnUpload_Click"></asp:LinkButton>
            <asp:Label ID="lbErrorMessage" runat="server" ForeColor="red"></asp:Label>
        </td>
    </tr>
</table>
<asp:Panel ID="pnlSave" runat="server" Visible="false">
    <table align="center" width="100%">
        <tr>
            <td align="left" style="background-color: #5B6DB5; color: White">
                �ĤG�B�J�G�T�{��� �W�ǤH���G<asp:Label ID="lbSourcerName" runat="server"></asp:Label>
                �W�ǳ渹�G<asp:Label ID="lbFormId" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" width="100%">
                <table width="100%">
                    <tr>
                        <td colspan=2>
                            <asp:Label ID="lbErrMsg" runat="server"></asp:Label>
                         </td>
                    </tr>
                    <tr>
                        <td>
                            Excel�渹�G<asp:Label ID="lbExcelFormId" runat="server"></asp:Label>
                         </td>
                          
                        <td align="right">
                            <asp:LinkButton ID="lnkSave" runat="server" CssClass="func" Text="�T�w�s��" OnClick="lnkSave_Click"></asp:LinkButton>
                            <asp:Label ID="lbSaveErrMsg" runat="server" ForeColor="red"></asp:Label>
                        </td>
                    
                    </tr>
                    <tr>
                        <td colspan=2>
                           <%-- <div id="div-datagrid">--%>
                                <asp:GridView ID="GridView1" SkinID="GridView" runat="server" AllowPaging="false"
                                    AllowSorting="false" AutoGenerateColumns="False" PageSize="10" Width="100%" DataKeyNames="FormId,PN"
                                    OnInit="GridView1_Init" OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated">
                                </asp:GridView>
                                <!--Get BOM�ϥ� ��������O�w��BOM�W�Ǹ�ƨϥ�-->
                                 <asp:GridView ID="GridView2" SkinID="GridView" runat="server" AllowPaging="false"
                                    AllowSorting="false" AutoGenerateColumns="False" PageSize="10" Width="100%">
                                </asp:GridView>
                            <%--</div>--%>
                        </td>
                    </tr>
                   
                    
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
