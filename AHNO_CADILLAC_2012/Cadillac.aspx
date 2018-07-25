<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cadillac.aspx.cs" Inherits="Cadillac" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadillac</title>
    <script type="text/javascript" src="javascript/swfobject.js"></script>
</head>
<body bgcolor="black">
    <center>
        <div style="width: 816px; height: 443px; position: relative" align="center">
            <div id="flashDiv">
                This text is replaced by the Flash movie.
            </div>
            <asp:Literal ID="ltrlFlash" runat="server"></asp:Literal>
            <%-- <script type="text/javascript">
                var so = new SWFObject("cadillacContainer.swf", "Cadillac", "816", "443", "8", "black");
                so.addParam("wmode", "transparent");
                so.addVariable("couponId", "SCGC-06539-NWSS-S7BK");
                so.write("flashDiv");
            </script>--%>
        </div>
    </center>
</body>
</html>