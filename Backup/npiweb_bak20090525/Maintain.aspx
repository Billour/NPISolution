<%@ Page Language="C#" MasterPageFile="~/NPI.Master" AutoEventWireup="true" CodeBehind="Maintain.aspx.cs" Inherits="AsusWeb.Maintain" Title="Untitled Page" %>
<%@ Register Src="UserControl/UCBOMList.ascx" TagName="UCBOMList" TagPrefix="uc1" %>
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
                                                    <asp:Label ID="lbTitle" SkinID="TitleSkin" runat="Server" Text="BOM資料瀏覽"></asp:Label>
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
                                    <td align="left">
                                        <!--新增按鈕 開始-->
                                        <asp:Panel ID="pnlQuery" runat="Server" Visible="False">
                                            <asp:LinkButton ID="lnkDownlaodBomTemplate" runat="server" CssClass="func" Text="下載BOM列表" OnClick="lnkDownlaodBomTemplate_Click"  ></asp:LinkButton>
                                        </asp:Panel>
                                        <!--新增按鈕 結束-->
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="right">
                                        <!--新增按鈕 開始-->
                                        <asp:Panel ID="pnlUpload1" runat="Server" Visible="False">
                                                                                        
                                        </asp:Panel>
                                        <!--新增按鈕 結束-->
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <!--新增按鈕 開始-->
                                        <asp:Panel ID="pnlCreate" runat="Server" Visible="false">
                                            
                                        </asp:Panel>
                                        <!--新增按鈕 結束-->
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <!--修改按鈕 開始-->
                                        <asp:Panel ID="pnlEdit" runat="Server" Visible="false">
                                            
                                        </asp:Panel>
                                        <!--修改按鈕 結束-->
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlQuery2" runat="Server" Visible="False">
                                            <uc1:UCBOMList ID="UCBOMList1" runat="server"></uc1:UCBOMList>
                                            <!--放置使用者列表 -->
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
                                        <div id="pnlEdit2" runat="server">
                                            
                                            <!--修改模式 -->
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlUpload2" runat="server" Visible=false>
                                            <!--Upload模式 -->
                                            
                                         </asp:Panel>
                                        
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </center>

</asp:Content>
