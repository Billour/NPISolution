<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AlertSourcerMail.aspx.cs"
    Inherits="AsusWeb.AlertSourcerMail" %>

<%@ Register Src="UserControl/SendMailPNListUserControl.ascx" TagName="SendMailPNListUserControl"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sourcer尚未取得議價資料</title>
    <style>
       	

body 
{
    border-bottom-width:0;    
    margin: 0;
    padding: 0;
    

 }

.menuDiv
{
	cursor:pointer;
	margin-bottom: 0px;
	
	color:#FFFFFF;
	padding:5px;
	text-align:center;
	font-weight:bold;
	
}

.menuDivHover
{
	color: #41519A;  
	cursor:hand; 
	background-color:white;
	
}

.menuDivSelected
{
	color: #41519A;  
	background-color:Yellow;
	
}


		

		
p
{
	line-height: 1.4em;
}

.title
{
    text-transform: uppercase;
    font-family: verdana;
    font-size: large;
    font-weight: bold;
    color: #41519A;
 }
 
 .pageTitle
 {
	text-transform: uppercase;
    font-family: verdana;
    font-size:small;
    font-weight: bold;
    color: #41519A;
}
 
.login
{
    text-transform: uppercase;
    font-family: verdana;
    font-size:x-small;
    font-weight: bold;
    color: #41519A;
 }

hr {
	border: 0;
	border-top: 2px solid #41519A;
	height: 2px;
}

img
{
	border-width: 0;
}

ul
{
	list-style-image: url(Images/bullet.jpg);
	list-style-position: outside;
	list-style-type: disc;
	color: #000000;
	font-family: verdana;
}

.menutextindent
{
    font-size: x-small;
    
}

/* Table Menu CSS */

.tableMenu
{
  
  border-bottom-color:Black;
  border-bottom-style:none;
  background-color:Transparent;	
}

.tableMenu table th
{
  background-color:#99ACDD;
  color:#41519A;
  font-weight: bold; 	
}

.tableMenu table tr
{
   background-color:#ffffff;
   border-bottom-color:#6B7EBF;
   border-bottom-style:outset;
   border-bottom-width:1px;
}

/* Headings                    */
/*-----------------------------*/
h1
{
	font-size: large;
	color: #6B7EBF
}

h2
{
	font-family: Verdana;
	font-size: medium;
	margin-top: 30;
	color: #6B7EBF;
	margin-bottom: -15;
}
	
h3
{
	font-family: Verdana;
	font-size: small;
	margin-bottom: -15;
	color: #6B7EBF;
	padding-left: 15;
}

h1, h2, h3, h4
{
	margin: 0;
	font-family: Verdana;
}

/* Tables                      */
/*-----------------------------*/	
table
{
	font-size: 1em;
}

table.header
{
	  background-color:#5B6DB5;
}

td.logo
{
	text-align: left;
	width: 184px;
}

td.title 
	{
		text-align: center;
		font-family: verdana;
		font-size: x-large;
		font-weight: bolder;
		color: #FFFFFF;
	}

td.headerbar 
{
	background-image: url(Images/bar.jpg);
	text-align: right;
	height: 24px;
}

td.menu 
{
	background-color:#41519A;
	width: 0px;
	
	vertical-align: top;
}

td.footer
{
	background-color:#5B6DB5;
	font-family: Verdana;
	font-size:xx-small;
	font-weight: normal;
	color: #FFFFFF;
	text-align: center;
}

/* 針對所的Table 欄位 */

.editTableTitle
{
	 background-color:Red;
	 font-family: "Arial", "Helvetica", "sans-serif";
	 font-size: 12px;
	 line-height: 18px;
	 color: #FFFFFF;
	 
	 
	}

.editTableContent
{
	background-color:#FFFFFF;
	 font-family: "Arial", "Helvetica", "sans-serif";
	 font-size: 12px;
	 line-height: 18px;
	 
	
}

/* 按鈕 */
.func{
	font-family: "Arial", "Helvetica", "sans-serif";
	font-size: 12px;
	line-height: 18px;
	color: #FFFFFF;
	background-color:#41519A;
	padding-right: 2px;
	padding-left: 2px;
	margin-left: 5px;
	padding-top: 2px;
	border-style:solid;
	border-color:#877F87;
	border-width:1px;
	text-decoration:none;
	height: 20px;
	width:120px;
	vertical-align:middle;
	text-align:center;
	
}


 A.func:visited 	{ color: #FFFFFF; text-decoration:none; }
 A.func:hover 	{ color: yellow;  cursor:hand; text-decoration:"underline"; }
 
 
 div#div-datagrid {
width: 900px;
height: 500px;
overflow: auto;
scrollbar-base-color:#ffeaff;
}
 
 /* Locks the left column */
th.locked {
font-size: 14px;
font-weight: bold;
text-align: center;
background-color: #41519A;
color: white;
border-right: 1px solid white;
position:relative;
cursor: default; 
left: expression(document.getElementById("div-datagrid").scrollLeft-2); /*IE5+ only*/
}

td.locked {
font-size: 14px;
font-weight: bold;
text-align: center;
background-color: #99ACDD;
color: black;
border-right: 1px solid white;
border-bottom: 1px solid white;
position:relative;
cursor: default; 
left: expression(document.getElementById("div-datagrid").scrollLeft-2); /*IE5+ only*/
}	

/* Locks table header */
th {
font-size: 14px;
font-weight: bold;
text-align: center;
background-color: #41519A;
color: white;
border-right: 1px solid silver;
position:relative;
cursor: default; 
top: expression(document.getElementById("div-datagrid").scrollTop-2); /*IE5+ only*/
z-index: 10;
}

/* Keeps the header as the top most item. Important for top left item*/
th.locked {z-index: 99;}


/*GridView*/
.GridViewPager
{
	background: #EEEEEE;
	font-size: 12px;
	font-family: Arial,新細明體; 
	color: #000000; 
	text-decoration: none;
}


.gvHeaderBlue {
	background-color: #587b9e;
	font-size: 13px;
	font-style: normal;
	line-height: 18px;
	font-weight: normal;
	font-variant: normal;
	text-transform: none;
	color: #FFFFFF;
	font-family: Arial, Helvetica, sans-serif;
	
}
.gvAlterRowBlue {
	font-size: 14px;
	color: #000000;
	background-color: #F3EBEF;
		text-transform: none;
}
.gvItemRowBlue {
	font-size: 14px;
	color: #000000;
	TEXT-DECORATION: none;
}


.gvFootBlue {
	border-top-style: dotted;
	border-right-style: dotted;
	border-bottom-style: dotted;
	border-left-style: dotted;
	
}
.gvBorderBlue {
	border: thin double #FFFFFF;

}
.gvSelectBlue {
	font-size: 14px;
	background-color: #E6F2F2;
}

.ReMark
{
   color:Red;	
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                                    <tr>
                                        <td>System send this mail to inform you this Info. Current Time:<asp:Label ID="lbnowDate" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom">
                                            E-NPI系統<asp:HyperLink ID="hy1" NavigateUrl="https://scm.asus.com/npi/Index.aspx" runat="server" Text="https://scm.asus.com/npi/Index.aspx"></asp:HyperLink>
                                            
                                            <br />
                                            
                                            系統有任何問題 請聯絡 Sam Chen(陳慶昇)
                                            <br /> 
                                            系統問題 Wen-Bin Tsai(蔡文斌) 
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
                                    <uc1:SendMailPNListUserControl ID="SendMailPNListUserControl1" runat="server"></uc1:SendMailPNListUserControl>
                                    <!--放置使用者列表 -->
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
