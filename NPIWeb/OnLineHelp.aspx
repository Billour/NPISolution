<%@ Page Language="C#" MasterPageFile="~/NPI.Master" AutoEventWireup="true" CodeBehind="OnLineHelp.aspx.cs" Inherits="AsusWeb.OnLineHelp" Title="Untitled Page" %>
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
                                            <asp:Label ID="Label1" SkinID="TitleSkin" runat="Server" Text="�u�W����"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table width="98%" cellpadding=1 cellspacing=1 border=0 bgcolor=blue>
                        <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2008/12/18
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                <ol>
                                    <li>Fix:�ק�SRM�b�����ư��D�A�]�A�ѨMCatherine Yue(����_�غ�Ĭ�{)�H��Linday Zhang(�i�R�R_�غ�Ĭ�{)�b������</li><li>Fix:BOM��ƺ��@�ARD�b�����ζ�g�A��KPM�@�~�A�]�����᪺BOM�W�ǰ��ǳ�</li>
                                    <li>Add�G�s�WBOM���Excel�榡�{���ǳƤu�@</li>
                                </ol>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:RadioButtonList ID="rd1" runat="server"  ></asp:RadioButtonList>
    </center>
</asp:Content>
