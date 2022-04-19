<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UCResponse.ascx.cs"
    Inherits="AsusWeb.UserControl.UCResponse" %>
<!--Response  -->
<asp:Label ID="lbPageState" runat="server" Text="Modify" Visible="false"></asp:Label>

<table align="center" width="100%">
    <tr>
        <td>
            <asp:Panel ID="pnlPN" runat="Server">
                 元件料號：
                <asp:DropDownList ID="ddlPNGroup" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPNGroup_SelectedIndexChanged">
                   
                </asp:DropDownList>
                總筆數：<asp:Label ID="lbPNCount" runat="server"></asp:Label>
            </asp:Panel>
           
            
        </td>
        <td>本BOM 展開時間為：<asp:Label ID="lbFormdate" runat="server"></asp:Label><asp:Label ID="lbPMName" runat="server"></asp:Label>
        </td>
       
    </tr>
    <tr>
        <td align="center" valign="top" colspan=2>
            
                <%--<div id="div-datagrid">--%>
                <asp:GridView ID="GridView1" SkinID="GridView" runat="server" AllowPaging="false" AllowSorting="false"
                    AutoGenerateColumns="False" PageSize="10" Width="100%"  DataKeyNames="FormId,PN" OnInit="GridView1_Init" OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated">
                   <%-- <Columns>
                        <asp:BoundField HeaderText="元件料號" DataField="No"  />
                        <asp:BoundField HeaderText="品名" DataField="Name"  />
                        <asp:BoundField HeaderText="規格" DataField="Spec"  />
                        <asp:BoundField HeaderText="70-MIB5G00-M3A78PRO-GA" DataField="BOM1"  />
                        <asp:BoundField HeaderText="70-MIB5G00-M3A78PRO-GB" DataField="BOM2"  />
                        <asp:BoundField HeaderText="70-MIB5G00-M3A78PRO-GC" DataField="BOM3"  />
                        <asp:BoundField HeaderText="70-MIB5G00-M3A78PRO-GD" DataField="BOM4"  />
                        <asp:BoundField HeaderText="70-MIB5G00-M3A78PRO-GE" DataField="BOM5"  />
                        <asp:BoundField HeaderText="70-MIB5G00-M3A78PRO-GF" DataField="BOM6"  />
                        <asp:BoundField HeaderText="70-MIB5G00-M3A78PRO-GG" DataField="BOM7"  />
                        <asp:BoundField HeaderText="70-MIB5G00-M3A78PRO-GH" DataField="BOM8"  />
                        <asp:BoundField HeaderText="70-MIB5G00-M3A78PRO-GI" DataField="BOM9"  />
                        <asp:BoundField HeaderText="70-MIB5G00-M3A78PRO-GJ" DataField="BOM10"  />
                        
                        <asp:TemplateField HeaderText="Risky Buy">
                            <ItemTemplate>
                                <asp:TextBox ID="tb" runat="server" Text='<%# Eval("RiskyBuy") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="long L/T(weeks)">
                            <ItemTemplate>
                                <asp:TextBox ID="tb" runat="server" Text='<%# Eval("LongTermWeeks") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="料號屬性">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlProperty" runat="server">
                                    <asp:ListItem Text="------"></asp:ListItem>
                                    <asp:ListItem Text="1.無意見"></asp:ListItem>
                                    <asp:ListItem Text="2.Custom parts"></asp:ListItem>
                                    <asp:ListItem Text="3.Unique parts"></asp:ListItem>
                                    <asp:ListItem Text="4.Single source"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="加入第二來源">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlProperty" runat="server">
                                    <asp:ListItem Text="------"></asp:ListItem>
                                    <asp:ListItem Text="1.無意見"></asp:ListItem>
                                    <asp:ListItem Text="2.Custom parts"></asp:ListItem>
                                    <asp:ListItem Text="3.Unique parts"></asp:ListItem>
                                    <asp:ListItem Text="4.Single source"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="EOL">
                            <ItemTemplate>
                                <asp:TextBox ID="tx" runat="server" Text='<%# Eval("EOL") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                    </Columns>--%>
                </asp:GridView>
           <%--</div>--%>
        </td>
    </tr>
</table>
