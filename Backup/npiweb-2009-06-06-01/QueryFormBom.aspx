<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryFormBom.aspx.cs" Inherits="AsusWeb.QueryFormBom" %>

<%@ Register Src="UserControl/BOMListUserControl.ascx" TagName="BOMListUserControl"
    TagPrefix="uc1" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
        <table height="100%" width="90%" border="0">
            <tr>
                <td valign="top">
                    <table width="100%">
                        <tr>
                            <td>
                                <table width="95%" height="23" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="bottom">
                                            <asp:Label ID="Label1" SkinID="TitleSkin" runat="Server" Text="BOM¦Cªí"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table width="100%">
                        <tr>
                            <td>
                                <div id="pnlEdit2" runat="server">
                                  
                                    <uc1:BOMListUserControl id="BOMListUserControl1" runat="server">
                                    </uc1:BOMListUserControl></div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
    </div>
    </form>
</body>
</html>
