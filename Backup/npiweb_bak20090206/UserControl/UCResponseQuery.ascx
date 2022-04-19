<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UCResponse.ascx.cs"  Inherits="AsusWeb.UserControl.UCResponse" %>

<!--Response  -->
<asp:Label ID="lbPageState" runat="server" Text="Query" Visible="false"></asp:Label>

<table align="center" width="100%">
    <tr>
        <td>
            
            <asp:Panel ID="pnlPN" runat="Server">
             元件料號：
                <asp:DropDownList ID="ddlPNGroup" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlPNGroup_SelectedIndexChanged">
               
                </asp:DropDownList>
                
                總筆數：<asp:Label ID="lbPNCount" runat="server"></asp:Label>
            </asp:Panel>
            
            本BOM 展開時間為：<asp:Label ID="lbFormdate" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" valign="top">
            
                <%--<div id="div-datagrid">--%>
                <asp:GridView ID="GridView1" SkinID="GridView" runat="server" AllowPaging="false" AllowSorting="false"
                    AutoGenerateColumns="False" PageSize="10" Width="100%"  DataKeyNames="FormId,PN" OnInit="GridView1_Init" OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated">
                  
                </asp:GridView>
          <%-- </div>--%>
        </td>
    </tr>
</table>
