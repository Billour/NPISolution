<%@ Page Language="C#" MasterPageFile="~/NPI.Master" AutoEventWireup="true" CodeBehind="Query.aspx.cs" Inherits="AsusWeb.Query" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:Panel ID="pnlVisible" runat="server" Visible="false">
    
    
    
    DB Query Tools Map
    
    <table>
        <tr><td>Data Source</td><td><asp:DropDownList ID="ddlSource" runat="server"></asp:DropDownList><asp:Button ID="btn1" runat="server" Text="Click" OnClick="btn1_Click" /></td></tr>
        <tr><td>Query Text</td><td><asp:TextBox ID="tbQuery" runat="server" TextMode="MultiLine" Width="600" Height="200"></asp:TextBox></td></tr>
        <tr><td colspan=2><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView></td></tr>
    </table>
    
    <br />
    
    Query User Account
    
    <table>
        <tr><td align=right>登入帳號</td><td><asp:TextBox ID="tbLoginId" runat="server"></asp:TextBox><asp:Button ID="btnUserQuery" runat="server" Text="查詢使用資料" OnClick="btnUserQuery_Click" /></td></tr>
        <tr><td colspan="2"><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true"></asp:GridView></td></tr>
    </table>
    <br />
    
    
    <br />
    
    找尋PN的生產地在何處
    <table>
        <tr><td align=right>輸入元件料號</td><td><asp:TextBox ID="tbPN" runat="server"></asp:TextBox><asp:Button ID="btnQueryBOMSite" runat="server" Text="查詢議價檔及Mode" OnClick="btnQueryBOMSite_Click"  /></td></tr>
        <tr><td colspan="2"><asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="true"></asp:GridView></td></tr>
        <tr><td colspan="2"><asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="true"></asp:GridView></td></tr>
    
    </table>
    
    <br />
    
    找尋目前等待展BOM的資料
    <table>
        <tr><td align=right></td><td><asp:Button ID="Button1" runat="server" Text="查詢目前需要展BOM資料" OnClick="Button1_Click"   /></td></tr>
        <tr><td colspan="2"><asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="true"></asp:GridView></td></tr>
        
    
    </table>
    
    </asp:Panel>
     
</asp:Content>
