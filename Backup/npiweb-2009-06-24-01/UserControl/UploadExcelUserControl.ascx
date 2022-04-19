<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UploadExcelUserControl.ascx.cs"
    Inherits="AsusWeb.UserControl.UploadExcelUserControl" %>
<table align="center" width="100%">
    <tr>
        <td align="left" style="background-color: #5B6DB5; color: White">
            第一步驟：上傳Excel，尚未存檔
        </td>
    </tr>
    <tr>
        <td align="center" valign="top" width="100%">
            <asp:FileUpload ID="fpExcelUppload" runat="server" /><br />
            <asp:LinkButton ID="btnUpload" runat="server" CssClass="func" Text="(步驟1/2)上傳Excel檔案顯示資料於畫面上" OnClick="btnUpload_Click"></asp:LinkButton>
            <asp:Label ID="lbErrorMessage" runat="server" ForeColor="red"></asp:Label>
        </td>
    </tr>
</table>
<asp:Panel ID="pnlSave" runat="server" Visible="false">
    <table align="center" width="100%">
        <tr>
            <td align="left" style="background-color: #5B6DB5; color: White">
                第二步驟：存檔至NPI系統 
                確認資料 上傳人員：<asp:Label ID="lbSourcerName" runat="server"></asp:Label>
                上傳單號：<asp:Label ID="lbFormId" runat="server"></asp:Label>
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
                            Excel單號：<asp:Label ID="lbExcelFormId" runat="server"></asp:Label>
                         </td>
                          
                        <td align="center">
                            <asp:LinkButton ID="lnkSave" runat="server" CssClass="func" Text="(步驟2/2)確定存檔至NPI系統" OnClick="lnkSave_Click" Width="200"></asp:LinkButton>
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
                                <!--Get BOM使用 此項控制項是針對BOM上傳資料使用-->
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
