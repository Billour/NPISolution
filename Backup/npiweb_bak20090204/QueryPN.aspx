<%@ Page Language="C#" MasterPageFile="~/NPI.Master" AutoEventWireup="true" CodeBehind="QueryPN.aspx.cs" Inherits="AsusWeb.QueryPN" Title="Untitled Page" %>

<%@ Register Src="UserControl/QueryPNPriceListUserControl.ascx" TagName="QueryPNPriceListUserControl"
    TagPrefix="uc1" %>
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
                                            <asp:Label ID="Label1" SkinID="TitleSkin" runat="Server" Text="�����d��"></asp:Label>
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
                                <!--�s�W���s �}�l-->
                                <asp:Panel ID="pnlQuery" runat="Server" Visible="False">
                                </asp:Panel>    
                                <!--�s�W���s ����-->
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <!--�s�W���s �}�l-->
                                <asp:Panel ID="pnlCreate" runat="Server" Visible="false" >
                                   
                                </asp:Panel>
                                <!--�s�W���s ����-->
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <!--�ק���s �}�l-->
                                <asp:Panel ID="pnlEdit" runat="Server" Visible="false">
                                   
                                </asp:Panel>
                                <!--�ק���s ����-->
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlQuery2" runat="Server" Visible="False">
                                    <!--��m�C�� -->
                                    
                                    <uc1:QueryPNPriceListUserControl id="QueryPNPriceListUserControl1" runat="server">
                                    </uc1:QueryPNPriceListUserControl>
                                    
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlCreate2" runat="Server" Visible="False">
                                    <!--�s�W�Ҧ� -->
                                    
                                   
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="pnlEdit2" runat="server">
                                    
                                    <!--�ק�Ҧ� -->
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
