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
        <center>
        <div>
            
            <h1>
                NPI Demo ����-�w�� <asp:Label ID="lbLoginUser" runat="server"></asp:Label></h1>
            <table width="80%">
                <tr>
                    <td><a href="Config.aspx">�]�wPM�H��</a></td>
                    <td><a href="SourcerGroup.aspx">�]�wSourcer�H��</a></td>
                    <td> <a href="BomBooking.aspx">PM-BOM</a></td>
                    <td><a href="BomResponse.aspx">Sourcer�^��</a></td>
                    <td><a href="BomProc.aspx">PM �U��</a></td>
                    <td><a href="NPIClosePage.aspx">�޲z�̵���</a></td>
                </tr>
            </table>
            
        </div>
        </center>
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    </form>
</body>
</html>
