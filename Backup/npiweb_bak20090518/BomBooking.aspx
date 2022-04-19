<%@ Page Language="C#" MasterPageFile="~/NPI.Master" ValidateRequest="false"   AutoEventWireup="true" Codebehind="BomBooking.aspx.cs"
    Inherits="AsusWeb.BomBooking" Title="BOM���@" EnableEventValidation="false"  %>

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
                                                    <asp:Label ID="lbTitle" SkinID="TitleSkin" runat="Server" Text="BOM ���@�]�w"></asp:Label>
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
                                            <asp:LinkButton ID="lnkUploadBom" runat="server" CssClass="func" Text="�W��ExcelBOM" OnClick="lnkUploadBom_Click" ></asp:LinkButton>
                                            <asp:LinkButton ID="lnkDownlaodBomTemplate" runat="server" CssClass="func" Text="�U��BOM�d��" OnClick="lnkDownlaodBomTemplate_Click"  ></asp:LinkButton>
                                            <asp:HyperLink ID="hy1" runat="server" NavigateUrl="~/Excel/NPI �p��W��BOM ���.doc" Text="�p��W��BOM" ></asp:HyperLink>
                                        </asp:Panel>
                                        <!--�s�W���s ����-->
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="right">
                                        <!--�s�W���s �}�l-->
                                        <asp:Panel ID="pnlUpload1" runat="Server" Visible="False">
                                            <asp:LinkButton ID="lnkBack2" runat="server" CssClass="func" Text="�^�W�@��" OnClick="lnkBack2_Click" ></asp:LinkButton>
                                            
                                        </asp:Panel>
                                        <!--�s�W���s ����-->
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <!--�s�W���s �}�l-->
                                        <asp:Panel ID="pnlCreate" runat="Server" Visible="false">
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
                                            <uc1:UCBOMList ID="UCBOMList1" runat="server" OnResultClick="Result_Click"></uc1:UCBOMList>
                                            <!--��m�ϥΪ̦C�� -->
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlCreate2" runat="Server" Visible="False">
                                            <!--�s�W�Ҧ� -->
                                            <uc2:UCBOMCreate ID="UCBOMCreate1" runat="server"></uc2:UCBOMCreate>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="pnlEdit2" runat="server">
                                            <uc3:UCBOM ID="UCBOM1" runat="server"></uc3:UCBOM>
                                            <!--�ק�Ҧ� -->
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlUpload2" runat="server" Visible=false>
                                            <!--Upload�Ҧ� -->
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
