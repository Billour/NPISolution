<%@ Page Language="C#" MasterPageFile="~/NPI.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AsusWeb.Index" Title="Untitled Page" %>

<%@ Register Src="UserControl/GroupListUserControl.ascx" TagName="GroupListUserControl"
    TagPrefix="uc1" %>
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
                                            <asp:Label ID="Label1" SkinID="TitleSkin" runat="Server" Text="E-NPI���i"></asp:Label>
                                            <br />
                                            <span style="font-size: 10pt; color: blue; font-family: �s�ө���; background-color: white">
                                                (�������D�G<span style="font-size: 12pt; color: #000000; font-family: Times New Roman">Sam Chen(���y�@))</span></span>
                                            <br />
                                            <span style="font-size: 10pt; color: blue; font-family: �s�ө���; background-color: white">
                                                (�t�ΰ��D�G<span style="font-size: 12pt; color: #000000; font-family: Times New Roman">Yulin
                                                    Li(�����D)</span></span>
                                            
                                                    
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <hr style="font-size: 12pt; font-family: Times New Roman" />
                    <table width="98%" cellpadding=1 cellspacing=1 border=0 bgcolor=blue style="font-size: 12pt; font-family: Times New Roman">
                          <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2009/09/18<font color="red" size="20">(New)</font> 
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                
                                <ol>
                                    <li>
                                        E-NPI �[�JSourcer ���ʤ@�P���u�n�^�Ф@��Excel�ɮסA�ھڬd�߱���U���۹�����Excel<font color="red">9/22</font>����}�l�䴩�C<br />
                                        �Цp��������D�A�гq��MIS�H��<br />
                                    </li>
                                    <li>
                                        <br />
                                        (1)�зs�W�Ŀ�ﶵ,��user��ܳ����U���ɮצ^��
                                        <br />
                                        (2)�t�~ �Ш�U�NPM names �אּ���~�����O, �W�[�ɮת���Ū��

                                    </li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink2" runat="server" Text="�p��U�����d�߱��󪺦^��Excel" NavigateUrl="~/Excel/NPI_�p��Q�άd�߱���U��.doc"></asp:HyperLink>
                                    </li>
                                                                        
                                </ol>
                                
                                
                            </td>
                        </tr>
                          <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2009/06/23 
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                
                                <ol>
                                    <li>
                                        E-NPI �[�JSourcer ���ʤ@�P���u�n�^�Ф@��Excel�ɮסA���ݭn�A�w��C�@��PM�h���^�СA�w�p��<font color="red">6/23</font>����}�l�䴩�C<br />
                                        �Цp��������D�A�гq��MIS�H��<br />
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink1" runat="server" Text="�p��U���^��Excel" NavigateUrl="~/Excel/���ʦ^�и��.doc"></asp:HyperLink>
                                    </li>
                                                                        
                                </ol>
                                
                                
                            </td>
                        </tr>
                         <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2009/06/05<font color="red" size="20"></font> 
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                
                                <ol>
                                    <li>
                                        E-NPI �[�JSourcer ���ʤU��Excel�ɮפ䴩�i�Ƹ��s�աj�z��\��A�w�p��<font color="red">6/10</font>�}�l�䴩�C<br />
                                        �Цp��������D�A�гq��MIS�H��<br />
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="hy2" runat="server" Text="�p��ϥήƸ��s��" NavigateUrl="~/Excel/�p��ϥήƸ��s�տz��\��.doc"></asp:HyperLink>
                                    </li>
                                                                        
                                </ol>
                                
                                
                            </td>
                        </tr>
                         <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2009/5/17 
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                
                                <uc1:GroupListUserControl id="GroupListUserControl1" runat="server">
                                </uc1:GroupListUserControl>
                                
                                
                            </td>
                        </tr>
                         <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2009/1/14
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                <ol>
                                    <li>
                                        E-NPI SOP.xls ��� ��<asp:HyperLink ID="hy1" runat="server" NavigateUrl="~/Excel/NPI SOP.xls" Text="�U��">���</asp:HyperLink>
                                    </li>
                                    
                                </ol>
                            </td>
                        </tr>
                         <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2009/1/14
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                <ol>
                                    <li><span style="font-size: 10pt"><span style="color: #0000ff; font-family: �s�ө���"><span
                                        style="color: blue">�iBOM �����A�ЦU��Sourcer�i�H�W�h��g�^�Ф��e</span></span></span>
                                    </li>
                                     <li><span style="font-size: 10pt"><span style="color: #0000ff; font-family: �s�ө���"><span
                                        style="color: blue">�C�@�ѷ|�o�|��ĳ����ƫH��A�ЦUSourcer�w��|��ĳ����ƥhTipTopĳ���ɫ���</span></span></span>
                                    </li>
                                </ol>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2008/12/30
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                <ol>
                                    <li><span style="font-size: 10pt"><span style="color: #0000ff; font-family: �s�ө���"><span
                                        style="color: blue">9:00-�ץ�BOM���@�������D�A�ЦU��PM�W�h���@BOM��ơA�w�p��P���T�ߤW10:00�iBOM�C</span></span></span></li></ol>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2008/12/18
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                <ol>
                                    <li><span style="font-size: 10pt"><span style="color: #0000ff; font-family: �s�ө���"><span
                                        style="color: blue">�w�ץ��i<span style="font-size: 12pt; color: #000000; font-family: Times New Roman">Catherine
                                            Yue(����_�غ�Ĭ�{)</span>�j�H�Ρi<span style="font-size: 12pt; color: #000000; font-family: Times New Roman">Linday
                                                Zhang(�i�R�R_�غ�Ĭ�{)</span>�j���P���L�k�n�J�t�Ϊ����D�C</span></span></span></li></ol>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2008/12/18
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                <ol>
                                    <li><span style="font-size: 10pt"><span style="color: #0000ff; font-family: �s�ө���"><span
                                        style="color: blue">Joey Lin(�L���g)����</span>BOM��ƺ��@�A�U����</span><font color="blue"
                                            face="Comic Sans MS" size="2"><span lang="EN-US" style="color: blue; font-family: 'Comic Sans MS'">3</span></font><font
                                                color="blue" face="�s�ө���" size="2"><span style="color: blue; font-family: �s�ө���">��n��</span></font><font
                                                    color="blue" face="Comic Sans MS" size="2"><span lang="EN-US" style="color: blue;
                                                        font-family: 'Comic Sans MS'">MP</span></font><font color="blue" face="�s�ө���" size="2"><span
                                                            style="color: blue; font-family: �s�ө���">�����</span></font><font color="blue" face="Comic Sans MS"
                                                                size="2"><span lang="EN-US" style="color: blue; font-family: 'Comic Sans MS'">MP Q1</span></font><font
                                                                    color="blue" face="�s�ө���" size="2"><span style="color: blue; font-family: �s�ө���">�B</span></font><font
                                                                        color="blue" face="Comic Sans MS" size="2"><span lang="EN-US" style="color: blue;
                                                                            font-family: 'Comic Sans MS'">MP Q2</span></font><font color="blue" face="�s�ө���" size="2"><span
                                                                                style="color: blue; font-family: �s�ө���">���q�A�o�Ǹ�T�ڭ̳o�������M���A</span></font></span><font
                                                                                    color="blue" face="�s�ө���" size="2"><span style="font-size: 10pt; color: blue; font-family: �s�ө���">�����S�O����ﶵ�~��s�ɡA�аݸӫ�򰵩O?</span></font></li><li><font color="blue" face="�s�ө���" size="2"><span style="font-family: �s�ө���"><span
                                        style="font-size: 11pt"><span style="color: #ff3300">�p�G MP�ƶq�H�ήɶ��L�k�T�{�A�i���ζ�g(�w�]��=-1)�A�{���w�[�J��l�ȡC</span></span></span></font></li></ol>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
