<%@ Page Language="C#" MasterPageFile="~/NPI.Master" AutoEventWireup="true" CodeBehind="OnLineHelp.aspx.cs" Inherits="AsusWeb.OnLineHelp" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
        <table height="100%" width="80%" border="0">
            <tr>
                <td valign="top">
                    <table width="100%">
                        <tr>
                            <td>
                                <table width="95%" height="23" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="bottom">
                                            <asp:Label ID="Label1" SkinID="TitleSkin" runat="Server" Text="線上說明"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table width="98%" cellpadding=1 cellspacing=1 border=0 bgcolor=blue>
                        <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2008/12/18
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                <ol>
                                    <li>Fix:修改SRM帳號重複問題，包括解決Catherine Yue(岳芬_華碩蘇州)以及Linday Zhang(張麗靜_華碩蘇州)帳號重複</li><li>Fix:BOM資料維護，RD帳號不用填寫，方便PM作業，也為之後的BOM上傳做準備</li>
                                    <li>Add：新增BOM資料Excel格式程式準備工作</li>
                                </ol>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:RadioButtonList ID="rd1" runat="server"  ></asp:RadioButtonList>
    </center>
</asp:Content>
