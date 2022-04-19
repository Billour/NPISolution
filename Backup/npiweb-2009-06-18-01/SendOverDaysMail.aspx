<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendOverDaysMail.aspx.cs" Inherits="AsusWeb.SendOverDaysMail" %>

<%@ Register Src="UserControl/WaitingConfirmSourcerListUserControl.ascx" TagName="WaitingConfirmSourcerListUserControl"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PN議價資料寄給主管</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table height="100%" width="97%" border="0">
                    <tr>
                        <td valign="top">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table width="95%" height="23" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td valign="bottom">
                                                    <asp:Label ID="lbTitle" SkinID="TitleSkin" runat="Server" Text="未議價元件料號一覽表"></asp:Label>
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
                                        <asp:Panel ID="pnlQuery2" runat="Server" Visible="true">
                                            
                                            
                                            <uc1:WaitingConfirmSourcerListUserControl id="WaitingConfirmSourcerListUserControl1"
                                                runat="server">
                                            </uc1:WaitingConfirmSourcerListUserControl>
                                            
                                        </asp:Panel>
                                    </td>
                                </tr>
                                
                            </table>
                        </td>
                    </tr>
                </table>
    </div>
    </form>
</body>
</html>
