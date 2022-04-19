<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGenList.ascx.cs" Inherits="AsusWeb.UserControl.UCGenList" %>

<!--���� Genid -->
<table align="center" width="100%">
    <tr>
        <td align="right">
            �^�Ъ��p�G<asp:DropDownList ID="ddlEnable" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEnable_SelectedIndexChanged">
                <asp:ListItem Text="������" Value="N"></asp:ListItem>
                <asp:ListItem Text="�w����" Value="Y"></asp:ListItem>
                <asp:ListItem Text="����" Value="A"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="center" valign="top"  width="100%">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AllowSorting="False"
                AutoGenerateColumns="False"  PageSize="10" SkinID="GridView" Width="100%" OnRowCommand="GridView1_RowCommand" DataKeyNames="MainId,WorkStatus">                
                <Columns>
                    <asp:BoundField DataField="MainName" HeaderText="���ͤ��" ItemStyle-HorizontalAlign="Center" />
                    <asp:ButtonField ButtonType="Link" HeaderText="�U��Excel" Text="�U��Excel-�̷ӱ���U��(���I��-�i��U�@�B�J)" ItemStyle-HorizontalAlign="Center" CommandName="ModifyCommand" />
                    <asp:ButtonField ButtonType="Link" HeaderText="�W��Excel" Text="�W��Excel" ItemStyle-HorizontalAlign="Center" CommandName="ModifyCommand2" />
                    <asp:ButtonField ButtonType="Link" HeaderText="�[�ݦ^�е��G" Text="�[�ݦ^�е��G" ItemStyle-HorizontalAlign="Center" CommandName="ModifyCommand3" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
           <!-- �d�߱���Ĥ@�� �ثe�ݭn�ץ��ĤG�� ���\������ϥ� -->
           <asp:Panel ID="pnlVisible" runat="server" Visible="false">
                <table border=1>
                    <tr><td colspan="2">�U��Excel-�B�J2-�U������</td></tr>
                    <tr>
                        <td>
                            ��ܸs�աG<asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                                        
                                      </asp:DropDownList>
                        </td>
                        <td>
                            ���PM�G<asp:DropDownList ID="ddlPM" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPM_SelectedIndexChanged" >
                                      <asp:ListItem Text="---ALL---" Value="*"></asp:ListItem>
                                      </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Panel ID="pnlPNVisible" runat="server" Visible="false">
                                <table>
                                    <tr>
                                        <td>����G<asp:CheckBox ID="cbSelectAll" Checked="true" runat="server" AutoPostBack="true" OnCheckedChanged="cbSelectAll_CheckedChanged" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            �Ƹ��G
                                            <asp:GridView ID="GridView2"   runat="server" AllowPaging="false" AllowSorting="false"
                                                AutoGenerateColumns="False"  PageSize="10" SkinID="GridView" Width="100%" OnRowCommand="GridView1_RowCommand" DataKeyNames="EmpId,BOMId" OnInit="GridView2_Init">                
                                                
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnDownload" runat="server" Text="�U��Excel" OnClick="btnDownload_Click" />
                        </td>
                    </tr>
                 </table>
           </asp:Panel>
           <!--�ĤG�� �}�l���� -->
           <asp:Panel  ID="pnlVisible2" runat="server" Visible="false">
            <table border=1>
                    <tr><td colspan="2">�U��Excel-�B�J2-�U������</td></tr>
                    <tr>
                        <td>
                            ��ܸs�աG<asp:CheckBoxList ID="cblGroupList" runat="server" RepeatColumns="3" RepeatDirection="Vertical">
                                      
                                      </asp:CheckBoxList>
                        </td>
                        <td>
                            <asp:Button ID="btnShowBOM" runat="server" Text="��ܮƸ�" OnClick="btnShowBOM_Click"  />
                            <br />
                            <asp:Label ID="lbShowMsg" ForeColor="Red" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Panel ID="pnlShowBOM" runat="server" Visible="false">
                                <table>
                                    <tr>
                                        <td>����G<asp:CheckBox ID="chkSelect2" Checked="true" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect2_CheckedChanged"  /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnDownloadExcel3" runat="server" Text="�U��Excel" OnClick="btnDownloadExcel2_Click"  />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            �Ƹ��G
                                            <asp:GridView ID="GridView3"   runat="server" AllowPaging="false" AllowSorting="false"
                                                AutoGenerateColumns="False"  PageSize="10" SkinID="GridView" Width="100%" DataKeyNames="EmpId,BOMId" OnInit="GridView3_Init">                
                                                
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnDownloadExcel2" runat="server" Text="�U��Excel" OnClick="btnDownloadExcel2_Click"  />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    
                 </table>
           </asp:Panel>
            
        </td>
    </tr>
</table>