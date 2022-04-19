<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="NPIWeb._Default" %>

<%@ Register Src="Layout/TableLayout.ascx" TagName="TableLayout" TagPrefix="uc1" %>
<%@ Register Src="UserControl/UCUserEdit.ascx" TagName="UCUserEdit" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                Demo 網站</h1>
            <h3>
                設定權限頁面</h3>
            <a href="Config.aspx">Enter</a>
           <hr />
           
           <aspx:OpenCalendar ID="cal" runat="server" ></aspx:OpenCalendar>
           
           <asp:Button ID="bn" runat="server" Text="Click" OnClick="bn_Click"  />
           
           <asp:Label ID="lbUser" runat="server"></asp:Label>
           
           取得資料庫資料表<br />
           Tables<br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true">
            </asp:GridView>
            
            Columns Sex<br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true">
            </asp:GridView>
            
             Pimary Keyx<br />
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="true">
            </asp:GridView>  
            
             Foreign Keyx<br />
            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="true">
            </asp:GridView>  
           
            
        </div>
    </form>
</body>
</html>
