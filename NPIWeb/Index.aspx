<%@ Page Language="C#" MasterPageFile="~/NPI.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AsusWeb.Index" Title="Untitled Page" %>

<%@ Register Src="UserControl/GroupListUserControl.ascx" TagName="GroupListUserControl"
    TagPrefix="uc1" %>
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
                                            <asp:Label ID="Label1" SkinID="TitleSkin" runat="Server" Text="E-NPI公告"></asp:Label>
                                            <br />
                                            <span style="font-size: 10pt; color: blue; font-family: 新細明體; background-color: white">
                                                (相關問題：<span style="font-size: 12pt; color: #000000; font-family: Times New Roman">Sam Chen(陳慶昇))</span></span>
                                            <br />
                                            <span style="font-size: 10pt; color: blue; font-family: 新細明體; background-color: white">
                                                (系統問題：<span style="font-size: 12pt; color: #000000; font-family: Times New Roman">Yulin
                                                    Li(黎郁伶)</span></span>
                                            
                                                    
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <hr style="font-size: 12pt; font-family: Times New Roman" />
                    <table width="98%" cellpadding=1 cellspacing=1 border=0 bgcolor=blue style="font-size: 12pt; font-family: Times New Roman">
                          <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2009/09/18<font color="red" size="20">(New)</font> 
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                
                                <ol>
                                    <li>
                                        E-NPI 加入Sourcer 採購一星期只要回覆一份Excel檔案，根據查詢條件下載相對應的Excel<font color="red">9/22</font>之後開始支援。<br />
                                        請如有任何問題，請通知MIS人員<br />
                                    </li>
                                    <li>
                                        <br />
                                        (1)請新增勾選選項,讓user選擇部門下載檔案回覆
                                        <br />
                                        (2)另外 請協助將PM names 改為產品部門別, 增加檔案的易讀性

                                    </li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink2" runat="server" Text="如何下載有查詢條件的回覆Excel" NavigateUrl="~/Excel/NPI_如何利用查詢條件下載.doc"></asp:HyperLink>
                                    </li>
                                                                        
                                </ol>
                                
                                
                            </td>
                        </tr>
                          <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2009/06/23 
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                
                                <ol>
                                    <li>
                                        E-NPI 加入Sourcer 採購一星期只要回覆一份Excel檔案，不需要再針對每一個PM去做回覆，預計於<font color="red">6/23</font>之後開始支援。<br />
                                        請如有任何問題，請通知MIS人員<br />
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="HyperLink1" runat="server" Text="如何下載回覆Excel" NavigateUrl="~/Excel/採購回覆資料.doc"></asp:HyperLink>
                                    </li>
                                                                        
                                </ol>
                                
                                
                            </td>
                        </tr>
                         <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2009/06/05<font color="red" size="20"></font> 
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                
                                <ol>
                                    <li>
                                        E-NPI 加入Sourcer 採購下載Excel檔案支援【料號群組】篩選功能，預計於<font color="red">6/10</font>開始支援。<br />
                                        請如有任何問題，請通知MIS人員<br />
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="hy2" runat="server" Text="如何使用料號群組" NavigateUrl="~/Excel/如何使用料號群組篩選功能.doc"></asp:HyperLink>
                                    </li>
                                                                        
                                </ol>
                                
                                
                            </td>
                        </tr>
                         <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2009/5/17 
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                
                                <uc1:GroupListUserControl id="GroupListUserControl1" runat="server">
                                </uc1:GroupListUserControl>
                                
                                
                            </td>
                        </tr>
                         <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2009/1/14
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                <ol>
                                    <li>
                                        E-NPI SOP.xls 文件 請<asp:HyperLink ID="hy1" runat="server" NavigateUrl="~/Excel/NPI SOP.xls" Text="下載">文件</asp:HyperLink>
                                    </li>
                                    
                                </ol>
                            </td>
                        </tr>
                         <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2009/1/14
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                <ol>
                                    <li><span style="font-size: 10pt"><span style="color: #0000ff; font-family: 新細明體"><span
                                        style="color: blue">展BOM 完成，請各位Sourcer可以上去填寫回覆內容</span></span></span>
                                    </li>
                                     <li><span style="font-size: 10pt"><span style="color: #0000ff; font-family: 新細明體"><span
                                        style="color: blue">每一天會發尚未議價資料信件，請各Sourcer針對尚未議價資料去TipTop議價檔建檔</span></span></span>
                                    </li>
                                </ol>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2008/12/30
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                <ol>
                                    <li><span style="font-size: 10pt"><span style="color: #0000ff; font-family: 新細明體"><span
                                        style="color: blue">9:00-修正BOM維護換頁問題，請各位PM上去維護BOM資料，預計於星期三晚上10:00展BOM。</span></span></span></li></ol>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2008/12/18
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                <ol>
                                    <li><span style="font-size: 10pt"><span style="color: #0000ff; font-family: 新細明體"><span
                                        style="color: blue">已修正【<span style="font-size: 12pt; color: #000000; font-family: Times New Roman">Catherine
                                            Yue(岳芬_華碩蘇州)</span>】以及【<span style="font-size: 12pt; color: #000000; font-family: Times New Roman">Linday
                                                Zhang(張麗靜_華碩蘇州)</span>】兩位同仁無法登入系統的問題。</span></span></span></li></ol>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="center" bgcolor=white>
                                2008/12/18
                                
                            </td>
                            <td width="80%" align="left" bgcolor=white>
                                <ol>
                                    <li><span style="font-size: 10pt"><span style="color: #0000ff; font-family: 新細明體"><span
                                        style="color: blue">Joey Lin(林美君)提及</span>BOM資料維護，下面有</span><font color="blue"
                                            face="Comic Sans MS" size="2"><span lang="EN-US" style="color: blue; font-family: 'Comic Sans MS'">3</span></font><font
                                                color="blue" face="新細明體" size="2"><span style="color: blue; font-family: 新細明體">欄要填</span></font><font
                                                    color="blue" face="Comic Sans MS" size="2"><span lang="EN-US" style="color: blue;
                                                        font-family: 'Comic Sans MS'">MP</span></font><font color="blue" face="新細明體" size="2"><span
                                                            style="color: blue; font-family: 新細明體">日期及</span></font><font color="blue" face="Comic Sans MS"
                                                                size="2"><span lang="EN-US" style="color: blue; font-family: 'Comic Sans MS'">MP Q1</span></font><font
                                                                    color="blue" face="新細明體" size="2"><span style="color: blue; font-family: 新細明體">、</span></font><font
                                                                        color="blue" face="Comic Sans MS" size="2"><span lang="EN-US" style="color: blue;
                                                                            font-family: 'Comic Sans MS'">MP Q2</span></font><font color="blue" face="新細明體" size="2"><span
                                                                                style="color: blue; font-family: 新細明體">的量，這些資訊我們這邊比較不清楚，</span></font></span><font
                                                                                    color="blue" face="新細明體" size="2"><span style="font-size: 10pt; color: blue; font-family: 新細明體">但它又是必填選項才能存檔，請問該怎麼做呢?</span></font></li><li><font color="blue" face="新細明體" size="2"><span style="font-family: 新細明體"><span
                                        style="font-size: 11pt"><span style="color: #ff3300">如果 MP數量以及時間無法確認，可不用填寫(預設值=-1)，程式已加入初始值。</span></span></span></font></li></ol>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
