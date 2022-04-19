<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestWebApplication._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        UI 資料<br />
        &nbsp;<br />
        <asp:TextBox ID="TextBox1" runat="server" Text="Welcome" />
        <asp:Button ID="Button1" runat="server" Text="標準做法" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Reflection" /><br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
        <br />
        如何取得 Attribute 的值<br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="取得Flower_name" />
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="泛型的應用" />
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
        <br />
        .Net Framework History<br />
        <br />
        C# 4.0<br />
        F# http://msdn.microsoft.com/zh-tw/library/dd252673.aspx<br />
        ERLang http://erlang.org/&nbsp;<br />
        <br />
        <br />
        NPI System<br />
        Page/UserControl(Asp.Net)<br />
        Bussiness Rule Layer(From MVP)&nbsp; asp.net mvp framework<br />
        &nbsp; &nbsp; http://www.codeplex.com/aspnetmvp<br />
        JBoss Sean Framework<br />
        http://docs.jboss.com/seam/latest/reference/en-US/html/tutorial.html<br />
        <br />
        <br />
        Entity(Object)<br />
        簡介 ADO.NET 2.0-Entity Framework&nbsp; http://www.microsoft.com/taiwan/msdn/columns/jhu_ming_jhong/ADO.NET_Entity_Framework_Overview.htm<br />
        Like OR/Mapping Relation<br />
        https://www.hibernate.org/<br />
        LINQ(Net Framework 3.5)<br />
        T4 ToolBox-Code Generator http://www.codeplex.com/t4toolbox<br />
        <br />
        <br />
        <br />
        System.Attribute<br />
        http://msdn.microsoft.com/zh-tw/library/system.attribute(VS.80).aspx
        <br />
        <br />
        Reflection<br />
        http://msdn.microsoft.com/zh-tw/library/system.reflection(VS.80).aspx<br />
        <br />
        Generic<br />
        http://msdn.microsoft.com/zh-tw/library/system.collections.generic.aspx<br />
        <br />
    </div>
    </form>
</body>
</html>
