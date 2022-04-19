<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="TestWebApplication.WebForm3" %>

<%@ Register Src="UserControl/WebUserControl1.ascx" TagName="WebUserControl1" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:WebUserControl1 id="WebUserControl1_1" runat="server">
        </uc1:WebUserControl1><!--建立一個 UserControl 開始--></div>
        
        <asp:TextBox ID="tb1" runat="server" TextMode=MultiLine Columns=10 Rows=10  ></asp:TextBox>
    </form>
</body>
</html>
