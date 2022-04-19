<%@ Page Language="C#" MasterPageFile="~/NPI.Master" AutoEventWireup="true" CodeBehind="BomProc.aspx.cs" Inherits="AsusWeb.BomProc" Title="Untitled Page"  EnableEventValidation="false" %>

<%@ Register Src="UserControl/UCResponseQuery.ascx" TagName="UCResponseQuery" TagPrefix="uc3" %>
<%@ Register Src="UserControl/UCResponseList.ascx" TagName="UCResponseList" TagPrefix="uc1" %>
<%@ Register Src="UserControl/UCResponse.ascx" TagName="UCResponse" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <center>
        <table height="100%" width="80%" border="0">
            <tr>
                <td valign="top">
                    <table width="100%">
                        <tr>
                            <td>
                                <table width="95%" height="23" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="bottom">
                                            <asp:Label ID="Label1" SkinID="TitleSkin" runat="Server" Text="PM Excel DownLoad"></asp:Label>
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
                                    
                                </asp:Panel>
                                <!--新增按鈕 結束-->
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <!--新增按鈕 開始-->
                                <asp:Panel ID="pnlCreate" runat="Server" Visible="false" >
                                    
                                </asp:Panel>
                                <!--新增按鈕 結束-->
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <!--修改按鈕 開始-->
                                <asp:Panel ID="pnlEdit" runat="Server" Visible="false">
                                    <table>
                                        <tr><td align="right">
                                            <asp:LinkButton ID="lnkViewBom" runat="server" CssClass="func" Text="看BOM詳細資料" OnClick="lnkViewBom_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkClose" runat="server" CssClass="func" Text="結案" OnClick="lnkClose_Click" ></asp:LinkButton>
                                            <asp:LinkButton ID="lnkSave" runat="server" CssClass="func" Text="下載Excel" OnClick="lnkSave_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkBack" runat="server" CssClass="func" Text="回上一頁" OnClick="lnkBack_Click"></asp:LinkButton>
                                        </td></tr>
                                        <tr><td>
                                            <asp:Label ID="AlertM" runat="server" ForeColor="red" Text="下載Excel時，要點選「儲存」至你的電腦後再開啟，由於Excel檔案是即時產生，直接開啟舊檔會增加系統負擔，請配合此項動作"></asp:Label>
                                        </td></tr>
                                    </table>
                                    
                                    
                                    
                                </asp:Panel>
                                <!--修改按鈕 結束-->
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlQuery2" runat="Server" Visible="False">
                                    <!--放置列表 -->
                                    
                                    <uc1:UCResponseList id="UCResponseList1" OnResultClick="Result_Click" UseRole="PM" runat="server">
                                    </uc1:UCResponseList>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlCreate2" runat="Server" Visible="False">
                                    <!--新增模式 -->
                                   
                                    
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlEdit2" runat="Server" Visible="False">
                                    <!--修改模式 -->
                                    
                                    <uc3:UCResponseQuery ID="UCResponseQuery1" runat="server" Visible="false" UseRole="PM" />
                                    
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
