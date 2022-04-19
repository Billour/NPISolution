<%@ Page Language="C#" MasterPageFile="~/NPI.Master" ValidateRequest="false"   AutoEventWireup="true" Codebehind="BomBooking.aspx.cs"
    Inherits="AsusWeb.BomBooking" Title="BOM維護" EnableEventValidation="false"  %>

<%@ Register Src="UserControl/UploadExcelUserControl.ascx" TagName="UploadExcelUserControl"
    TagPrefix="uc4" %>

<%@ Register Src="UserControl/UCBOMList.ascx" TagName="UCBOMList" TagPrefix="uc1" %>
<%@ Register Src="UserControl/UCBOMCreate.ascx" TagName="UCBOMCreate" TagPrefix="uc2" %>
<%@ Register Src="UserControl/UCBOM.ascx" TagName="UCBOM" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<atlas:UpdatePanel runat="server" ID="UpdatePanel1">
        <Triggers>
           <atlas:AsyncPostBackTrigger ControlID="lnkDownlaodBomTemplate"  />
        </Triggers>
        <ContentTemplate>--%>
            <center>
                <table height="100%" width="97%" border="0">
                    <tr>
                        <td valign="top">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table width="95%" height="23" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td valign="bottom">
                                                    <asp:Label ID="lbTitle" SkinID="TitleSkin" runat="Server" Text="BOM 維護設定"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <hr />
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
                                            <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="func" Text="新增BOM料號" OnClick="lnkSubmit_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkUploadBom" runat="server" CssClass="func" Text="上傳ExcelBOM" OnClick="lnkUploadBom_Click" ></asp:LinkButton>
                                            <asp:LinkButton ID="lnkDownlaodBomTemplate" runat="server" CssClass="func" Text="下載BOM範本" OnClick="lnkDownlaodBomTemplate_Click"  ></asp:LinkButton>
                                            <asp:HyperLink ID="hy1" runat="server" NavigateUrl="~/Excel/NPI 如何上傳BOM 資料.doc" Text="如何上傳BOM" ></asp:HyperLink>
                                        </asp:Panel>
                                        <!--新增按鈕 結束-->
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="right">
                                        <!--新增按鈕 開始-->
                                        <asp:Panel ID="pnlUpload1" runat="Server" Visible="False">
                                            <asp:LinkButton ID="lnkBack2" runat="server" CssClass="func" Text="回上一頁" OnClick="lnkBack2_Click" ></asp:LinkButton>
                                            
                                        </asp:Panel>
                                        <!--新增按鈕 結束-->
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <!--新增按鈕 開始-->
                                        <asp:Panel ID="pnlCreate" runat="Server" Visible="false">
                                            <asp:LinkButton ID="lnkCreateSave" runat="server" CssClass="func" Text="存檔" OnClick="lnkCreateSave_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkCreateBack" runat="server" CssClass="func" Text="回上一頁" OnClick="lnkCreateBack_Click"></asp:LinkButton>
                                        </asp:Panel>
                                        <!--新增按鈕 結束-->
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <!--修改按鈕 開始-->
                                        <asp:Panel ID="pnlEdit" runat="Server" Visible="false">
                                            <asp:LinkButton ID="lnkSave" runat="server" CssClass="func" Text="存檔" OnClick="lnkSave_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkBack" runat="server" CssClass="func" Text="回上一頁" OnClick="lnkBack_Click"></asp:LinkButton>
                                        </asp:Panel>
                                        <!--修改按鈕 結束-->
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlQuery2" runat="Server" Visible="False">
                                            <uc1:UCBOMList ID="UCBOMList1" runat="server" OnResultClick="Result_Click"></uc1:UCBOMList>
                                            <!--放置使用者列表 -->
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlCreate2" runat="Server" Visible="False">
                                            <!--新增模式 -->
                                            <uc2:UCBOMCreate ID="UCBOMCreate1" runat="server"></uc2:UCBOMCreate>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="pnlEdit2" runat="server">
                                            <uc3:UCBOM ID="UCBOM1" runat="server"></uc3:UCBOM>
                                            <!--修改模式 -->
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlUpload2" runat="server" Visible=false>
                                            <!--Upload模式 -->
                                            <uc4:UploadExcelUserControl ID="UploadExcelUserControl1" runat="server" UpLoadMode="BOM" SourcerUserId="" />
                                         </asp:Panel>
                                        
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </center>
       <%-- </ContentTemplate>
    </atlas:UpdatePanel>--%>
</asp:Content>
