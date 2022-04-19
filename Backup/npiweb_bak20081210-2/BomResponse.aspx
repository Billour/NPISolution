<%@ Page Language="C#" MasterPageFile="~/NPI.Master" AutoEventWireup="true" Codebehind="BomResponse.aspx.cs"
    Inherits="AsusWeb.BomResponse" Title="Untitled Page" %>

<%@ Register Src="UserControl/UploadExcelUserControl.ascx" TagName="UploadExcelUserControl"
    TagPrefix="uc4" %>

<%@ Register Src="UserControl/UCResponseQuery.ascx" TagName="UCResponseQuery" TagPrefix="uc3" %>
<%@ Register Src="UserControl/UCResponseList.ascx" TagName="UCResponseList" TagPrefix="uc1" %>
<%@ Register Src="UserControl/UCResponse.ascx" TagName="UCResponse" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <table height="100%" width="90%" border="0">
            <tr>
                <td valign="top">
                    <table width="100%">
                        <tr>
                            <td>
                                <table width="95%" height="23" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label1" SkinID="TitleSkin" runat="Server" Text="採購 回覆處理"></asp:Label>
                                        </td>
                                        <td>
                                            <!--加入 所有的 Button 開始-->
                                            <table width="100%">
                                                <tr>
                                                    <td valign="top">
                                                        <table>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <!--新增按鈕 開始-->
                                                        <asp:Panel ID="pnlQuery" runat="Server" Visible="False">
                                                        </asp:Panel>
                                                        <!--新增按鈕 結束-->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <!--新增按鈕 開始-->
                                                        <asp:Panel ID="pnlCreate" runat="Server" Visible="false">
                                                           
                                                            <asp:LinkButton ID="lnkBack2" runat="server" CssClass="func" Text="回上一頁" OnClick="lnkBack2_Click"></asp:LinkButton>
                                                        </asp:Panel>
                                                        <!--新增按鈕 結束-->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <!--修改按鈕 開始-->
                                                        <asp:Panel ID="pnlEdit" runat="Server" Visible="false">
                                                            <table>
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:Label ID="lbWarning" Visible="true" runat="server" ForeColor="red" Text="請注意只有勾選【上傳】才會更新異動此筆資料。"></asp:Label>
                                                                        <asp:LinkButton ID="lnkViewBom" runat="server" CssClass="func" Text="看BOM詳細資料" OnClick="lnkViewBom_Click"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkSave" runat="server" CssClass="func" Text="存檔" OnClick="lnkSave_Click"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkPrint" runat="server" CssClass="func"  Text="下載Excel"
                                                                            OnClick="lnkPrint_Click"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkUploadExcel" runat="server" CssClass="func"  Text="上傳Excel" OnClick="lnkUploadExcel_Click"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkBack" runat="server" CssClass="func" Text="回上一頁" OnClick="lnkBack_Click"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="AlertM" Visible="false" runat="server" ForeColor="red" Text="下載Excel時，要點選「儲存」至你的電腦後再開啟，由於Excel檔案是即時產生，直接開啟舊檔會增加系統負擔，請配合此項動作"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <!--修改按鈕 結束-->
                                                    </td>
                                                </tr>
                                            </table>
                                            <!--加入 所有的 Button 結束-->
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Panel ID="pnlQuery2" runat="Server" Visible="False">
                                    <!--放置列表 -->
                                    <uc1:UCResponseList ID="UCResponseList1" OnResultClick="Result_Click" UseRole="Sourcer"
                                        runat="server"></uc1:UCResponseList>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlCreate2" runat="Server" Visible="False">
                                    <!--新增模式 -->
                                    
                                    <uc4:UploadExcelUserControl id="UploadExcelUserControl1" runat="server">
                                    </uc4:UploadExcelUserControl>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlEdit2" runat="Server" Visible="False">
                                    <!--修改模式 -->
                                    <uc2:UCResponse ID="UCResponse1" UseRole="Sourcer" runat="server" Visible="false"></uc2:UCResponse>
                                    <uc3:UCResponseQuery ID="UCResponseQuery1" UseRole="Sourcer" runat="server" Visible="false" />
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
