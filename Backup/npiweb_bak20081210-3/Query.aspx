<%@ Page Language="C#" MasterPageFile="~/NPI.Master" AutoEventWireup="true" CodeBehind="Query.aspx.cs" Inherits="AsusWeb.Query" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    DB Query Tools Map
    
    <table>
        <tr><td>Data Source</td><td><asp:DropDownList ID="ddlSource" runat="server"></asp:DropDownList><asp:Button ID="btn1" runat="server" Text="Click" OnClick="btn1_Click" /></td></tr>
        <tr><td>Query Text</td><td><asp:TextBox ID="tbQuery" runat="server" TextMode="MultiLine" Width="600" Height="200"></asp:TextBox></td></tr>
        <tr><td colspan=2><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView></td></tr>
    </table>
    
    <br />
    
    
     
</asp:Content>
