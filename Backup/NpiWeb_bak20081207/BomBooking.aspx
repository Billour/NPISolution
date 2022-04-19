<%@ Page Language="C#" MasterPageFile="~/NPI.Master" AutoEventWireup="true" CodeBehind="BomBooking.aspx.cs" Inherits="AsusWeb.BomBooking" Title="Untitled Page" %>

<%@ Register Src="UserControl/UCBOMList.ascx" TagName="UCBOMList" TagPrefix="uc1" %>
<%@ Register Src="UserControl/UCBOMCreate.ascx" TagName="UCBOMCreate" TagPrefix="uc2" %>
<%@ Register Src="UserControl/UCBOM.ascx" TagName="UCBOM" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                            <asp:Label ID="Label1" SkinID="TitleSkin" runat="Server" Text="BOM 維護設定"></asp:Label>
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
                                </asp:Panel>
                                <!--新增按鈕 結束-->
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <!--新增按鈕 開始-->
                                <asp:Panel ID="pnlCreate" runat="Server" Visible="false" >
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
                                    <uc1:UCBOMList id="UCBOMList1" runat="server" OnResultClick="Result_Click">
                                    </uc1:UCBOMList>
                                    <!--放置使用者列表 -->
                                    
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlCreate2" runat="Server" Visible="False">
                                    <!--新增模式 -->
                                    <uc2:UCBOMCreate id="UCBOMCreate1" runat="server">
                                    </uc2:UCBOMCreate>
                                    
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="pnlEdit2" runat="server">
                                    <uc3:UCBOM id="UCBOM1" runat="server">
                                    </uc3:UCBOM><!--修改模式 --></div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
