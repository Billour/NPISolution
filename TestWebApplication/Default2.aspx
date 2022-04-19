<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="TestWebApplication.Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Data Access
        <br />
        <br />
        Config
        <br />
        1. Web.Config/App.Config &nbsp;Config ConnctionString-Web Config Section DBCoonection<br />
        2. Start DB Connection -Global.asa<br />
        3.Use DBAssistant<br />
        <br />
        Select<br />
        Case1 DataTable&nbsp;<br />
        DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);<br />
        <br />
        Case2 List&lt;T&gt;<br />
        <br />
        object[] args = new object[] { formId,pmUserId };&nbsp;<br />
        &nbsp;List&lt;T&gt; list= this.QueryList&lt;T&gt;<bombookingentity></bombookingentity>(sql,
        args,DataBaseDB.NPIDB);<br />
        <br />
        [DataColumn("FORM_ID")]<br />
        <br />
        Command<br />
        <br />
        Case 1 Add sql<br />
        int n=DbAssistant.DoCommand(sql,DataBaseDB.NPIDB);<br />
        <br />
        Case 2 Add Command<br />
        int n=DbAssistant.DoCommand(command,DataBaseDB.NPIDB);<br />
        <br />
        Case 3 Add List&lt;Command&gt;<br />
        int n=DbAssistant.DoCommand(List&lt;Command&gt;,DataBaseDB.NPIDB);<br />
        <br />
        
        <br />
        log4Net<br />
        1.Web.Config<br />
        2.Global.asax<br />
        3.Class ¨Ï¥Î<br />
        <br />
        Deploy
        <br />
        1.Publish<br />
        2.Deploy<br />
         
    
    </div>
    </form>
</body>
</html>
