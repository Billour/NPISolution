<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGenList.ascx.cs" Inherits="AsusWeb.UserControl.UCGenList" %>

<!--產生 Genid -->
<table align="center" width="100%">
    <tr>
        <td align="right">
            回覆狀況：<asp:DropDownList ID="ddlEnable" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEnable_SelectedIndexChanged">
                <asp:ListItem Text="未結案" Value="N"></asp:ListItem>
                <asp:ListItem Text="已結案" Value="Y"></asp:ListItem>
                <asp:ListItem Text="全部" Value="A"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="center" valign="top"  width="100%">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AllowSorting="False"
                AutoGenerateColumns="False"  PageSize="10" SkinID="GridView" Width="100%" OnRowCommand="GridView1_RowCommand" DataKeyNames="MainId,WorkStatus">                
                <Columns>
                    <asp:BoundField DataField="MainName" HeaderText="產生日期" ItemStyle-HorizontalAlign="Center" />
                    <asp:ButtonField ButtonType="Link" HeaderText="下載Excel" Text="下載Excel-依照條件下載(請點選-進行下一步驟)" ItemStyle-HorizontalAlign="Center" CommandName="ModifyCommand" />
                    <asp:ButtonField ButtonType="Link" HeaderText="上傳Excel" Text="上傳Excel" ItemStyle-HorizontalAlign="Center" CommandName="ModifyCommand2" />
                    <asp:ButtonField ButtonType="Link" HeaderText="觀看回覆結果" Text="觀看回覆結果" ItemStyle-HorizontalAlign="Center" CommandName="ModifyCommand3" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
           <!-- 查詢條件第一版 目前需要修正第二版 此功能先不使用 -->
           <asp:Panel ID="pnlVisible" runat="server" Visible="false">
                <table border=1>
                    <tr><td colspan="2">下載Excel-步驟2-下載條件</td></tr>
                    <tr>
                        <td>
                            選擇群組：<asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                                        
                                      </asp:DropDownList>
                        </td>
                        <td>
                            選擇PM：<asp:DropDownList ID="ddlPM" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPM_SelectedIndexChanged" >
                                      <asp:ListItem Text="---ALL---" Value="*"></asp:ListItem>
                                      </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Panel ID="pnlPNVisible" runat="server" Visible="false">
                                <table>
                                    <tr>
                                        <td>全選：<asp:CheckBox ID="cbSelectAll" Checked="true" runat="server" AutoPostBack="true" OnCheckedChanged="cbSelectAll_CheckedChanged" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            料號：
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
                            <asp:Button ID="btnDownload" runat="server" Text="下載Excel" OnClick="btnDownload_Click" />
                        </td>
                    </tr>
                 </table>
           </asp:Panel>
           <!--第二版 開始做此 -->
           <asp:Panel  ID="pnlVisible2" runat="server" Visible="false">
            <table border=1>
                    <tr><td colspan="2">下載Excel-步驟2-下載條件</td></tr>
                    <tr>
                        <td>
                            選擇群組：<asp:CheckBoxList ID="cblGroupList" runat="server" RepeatColumns="3" RepeatDirection="Vertical">
                                      
                                      </asp:CheckBoxList>
                        </td>
                        <td>
                            <asp:Button ID="btnShowBOM" runat="server" Text="顯示料號" OnClick="btnShowBOM_Click"  />
                            <br />
                            <asp:Label ID="lbShowMsg" ForeColor="Red" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Panel ID="pnlShowBOM" runat="server" Visible="false">
                                <table>
                                    <tr>
                                        <td>全選：<asp:CheckBox ID="chkSelect2" Checked="true" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect2_CheckedChanged"  /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnDownloadExcel3" runat="server" Text="下載Excel" OnClick="btnDownloadExcel2_Click"  />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            料號：
                                            <asp:GridView ID="GridView3"   runat="server" AllowPaging="false" AllowSorting="false"
                                                AutoGenerateColumns="False"  PageSize="10" SkinID="GridView" Width="100%" DataKeyNames="EmpId,BOMId" OnInit="GridView3_Init">                
                                                
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnDownloadExcel2" runat="server" Text="下載Excel" OnClick="btnDownloadExcel2_Click"  />
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