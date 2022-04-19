<%@ Page Language="C#" MasterPageFile="~/NPI.Master" AutoEventWireup="true" CodeBehind="SourcerGroup.aspx.cs" Inherits="AsusWeb.SourcerGroup" Title="Untitled Page" %>

<%@ Register Src="UserControl/UCSourcerList.ascx" TagName="UCSourcerList" TagPrefix="uc1" %>
<%@ Register Src="UserControl/UCSourcerCreate.ascx" TagName="UCSourcerCreate" TagPrefix="uc2" %>
<%@ Register Src="UserControl/UCSourcerEdit.ascx" TagName="UCSourcerEdit" TagPrefix="uc3" %>
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
                                        <td valign="bottom">
                                            <asp:Label ID="Label1" SkinID="TitleSkin" runat="Server" Text="Sourcer管理"></asp:Label>
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
                                    <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="func" Text="新增Sourcer" OnClick="lnkSubmit_Click"></asp:LinkButton></asp:Panel>
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
                                    
                                    <uc1:UCSourcerList id="UCSourcerList1" OnResultClick="Result_Click" runat="server">
                                    </uc1:UCSourcerList>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlCreate2" runat="Server" Visible="False">
                                    <!--新增模式 -->
                                    
                                    <uc2:UCSourcerCreate id="UCSourcerCreate1" runat="server" PageState="Create" >
                                    </uc2:UCSourcerCreate>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="pnlEdit2" runat="server">
                                    
                                    <uc3:UCSourcerEdit id="UCSourcerEdit1" runat="server" PageState="Modify"  ></uc3:UCSourcerEdit>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
