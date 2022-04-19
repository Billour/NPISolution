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
                                            <asp:Label ID="Label1" SkinID="TitleSkin" runat="Server" Text="BOM ���@�]�w"></asp:Label>
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
                                    <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="func" Text="�s�WBOM�Ƹ�" OnClick="lnkSubmit_Click"></asp:LinkButton>
                                </asp:Panel>
                                <!--�s�W���s ����-->
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <!--�s�W���s �}�l-->
                                <asp:Panel ID="pnlCreate" runat="Server" Visible="false" >
                                    <asp:LinkButton ID="lnkCreateSave" runat="server" CssClass="func" Text="�s��" OnClick="lnkCreateSave_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkCreateBack" runat="server" CssClass="func" Text="�^�W�@��" OnClick="lnkCreateBack_Click"></asp:LinkButton>
                                </asp:Panel>
                                <!--�s�W���s ����-->
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <!--�ק���s �}�l-->
                                <asp:Panel ID="pnlEdit" runat="Server" Visible="false">
                                    <asp:LinkButton ID="lnkSave" runat="server" CssClass="func" Text="�s��" OnClick="lnkSave_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkBack" runat="server" CssClass="func" Text="�^�W�@��" OnClick="lnkBack_Click"></asp:LinkButton>
                                </asp:Panel>
                                <!--�ק���s ����-->
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlQuery2" runat="Server" Visible="False">
                                    <uc1:UCBOMList id="UCBOMList1" runat="server" OnResultClick="Result_Click">
                                    </uc1:UCBOMList>
                                    <!--��m�ϥΪ̦C�� -->
                                    
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlCreate2" runat="Server" Visible="False">
                                    <!--�s�W�Ҧ� -->
                                    <uc2:UCBOMCreate id="UCBOMCreate1" runat="server">
                                    </uc2:UCBOMCreate>
                                    
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="pnlEdit2" runat="server">
                                    <uc3:UCBOM id="UCBOM1" runat="server">
                                    </uc3:UCBOM><!--�ק�Ҧ� --></div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
