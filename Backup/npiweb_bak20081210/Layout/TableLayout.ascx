<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TableLayout.ascx.cs" Inherits="AsusWeb.Layout.TableLayout" %>

<!--©ñ¸m Table PlaceHolder 
    
-->
<asp:PlaceHolder ID="TableContainer" runat="server">
    
    <asp:Table ID="T000" runat="server" SkinID="TableLayoutSkin">
                
        <asp:TableRow>
            <asp:TableCell SkinID="CellTitleSkin" ></asp:TableCell>
            <asp:TableCell SkinID="CellSkin" Width="50" ></asp:TableCell>
        </asp:TableRow>
        
    </asp:Table>
    
</asp:PlaceHolder>