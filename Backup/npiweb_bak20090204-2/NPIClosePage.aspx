<%@ Page Language="C#" MasterPageFile="~/NPI.Master" AutoEventWireup="true" CodeBehind="NPIClosePage.aspx.cs" Inherits="AsusWeb.NPIClosePage" Title="Untitled Page" %>
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
                                            <asp:Label ID="Label1" SkinID="TitleSkin" runat="Server" Text="�޲z�̭���"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table width="100%">
                        
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
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:LinkButton ID="lnkClose" runat="server" CssClass="func" Text="����" OnClick="lnkClose_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkSave" runat="server" CssClass="func" Text="�s��" OnClick="lnkSave_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkPrint" runat="server" CssClass="func"  Text="�U��Excel" OnClick="lnkPrint_Click" ></asp:LinkButton>
                                    <asp:LinkButton ID="lnkBack" runat="server" CssClass="func" Text="�^�W�@��" OnClick="lnkBack_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <asp:Label ID="AlertM" runat="server" ForeColor="red" Text="�U��Excel�ɡA�n�I��u�x�s�v�ܧA���q����A�}�ҡA�ѩ�Excel�ɮ׬O�Y�ɲ��͡A�����}�����ɷ|�W�[�t�έt��A�аt�X�����ʧ@"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                </asp:Panel>
                                <!--�ק���s ����-->
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlQuery2" runat="Server" Visible="False">
                                    
                                    <!--��m�C�� -->
                                    
                                        <uc1:UCResponseList id="UCResponseList1" OnResultClick="Result_Click" UseRole="Management" runat="server">
                                        </uc1:UCResponseList>
                                   
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
                                <asp:Panel ID="pnlEdit2" runat="Server" Visible="False">
                                    <!--�ק�Ҧ� -->
                                   
                                            <uc2:UCResponse id="UCResponse1" UseRole="Management" runat="server" Visible="false">
                                            </uc2:UCResponse>
                                                
                                            <uc3:UCResponseQuery ID="UCResponseQuery1" UseRole="management" runat="server" Visible=false />
                                        
                                    
                                    
                                    
                                </asp:Panel>
                               
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>