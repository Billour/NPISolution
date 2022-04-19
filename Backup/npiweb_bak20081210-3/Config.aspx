<%@ Page Language="C#" MasterPageFile="~/NPI.Master" AutoEventWireup="true" Codebehind="Config.aspx.cs"
    Inherits="AsusWeb.Config" Title="Untitled Page" %>

<%@ Register Src="UserControl/UCUserEdit.ascx" TagName="UCUserEdit" TagPrefix="uc3" %>

<%@ Register Src="UserControl/UCUserCreate.ascx" TagName="UCUserCreate" TagPrefix="uc2" %>
<%@ Register Src="UserControl/UCUserList.ascx" TagName="UCUserList" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/NPI.Master" %>
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
                                            <asp:Label ID="Label1" SkinID="TitleSkin" runat="Server" Text="使用者管理"></asp:Label>
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
                                    <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="func" Text="新增使用者" OnClick="lnkSubmit_Click"></asp:LinkButton></asp:Panel>
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
                                    <!--放置使用者列表 -->
                                    <uc1:UCUserList ID="UCUserList1" OnResultClick="Result_Click" runat="server" />
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlCreate2" runat="Server" Visible="False">
                                    <!--新增模式 -->
                                    <uc2:UCUserCreate ID="UCUserCreate1" runat="server" PageState="Create" />
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="pnlEdit2" runat="server">
                                    
                                    <uc3:UCUserEdit ID="UCUserEdit1" runat="server" PageState="Modify" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
