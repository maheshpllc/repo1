<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Confirmation.aspx.cs" Inherits="Confirmation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadillac Dealer Registration Confirmation</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=8; IE=EmulateIE9">
    <!--[if IE 7]>
<link rel="stylesheet" href="http://css.hsn.com/css/ie7.css?v96" type="text/css" />
<![endif]-->
    <link type="text/css" rel="stylesheet" href="css/style.css" />
    <script type="text/javascript" language="javascript">
        function pagePrint() {
            var divMyArea = document.getElementById('divArea');
            if (divMyArea.innerHTML != "")
                window.open(",").document.write(divMyArea.innerHTML + '<input type="button" onclick="window.print();" value="Print">');
        }
    </script>
  <style media="print" type="text/css">
        #printicon
        {
            display: none;
        }

        @media all
        {
            .page-break
            {
                display: none;
            }
        }

        @media print
        {
            .page-break
            {
                display: block;
                page-break-before: always;
            }
            table
            {
                page-break-after: auto;
            }
            tr
            {
                page-break-inside: avoid;
                page-break-after: auto;
            }
            td
            {
                page-break-inside: avoid;
                page-break-after: auto;
            }
            thead
            {
                display: table-header-group;
            }
            tfoot
            {
                display: table-footer-group;
            }
        }
    </style>
</head>
<body>
    <form id="formReservationConfirmation" runat="server" name="myform">
    <div id="contentContainer2">
        <div id="divArea" runat="server">
            <div class="floatL">
                <img src="images/header.jpg" /></div>
            <div class="floatC">
                <table border="0" cellpadding="3" align="center" cellspacing="0">
                    <tr>
                        <td style="padding-top: 8px; padding-bottom: 8px; text-align: justify">
                            <span class="whiteText">
                                <asp:Literal ID="ltrlMessage" runat="server"></asp:Literal>
                                <asp:Label ID="lblMessage" class="text" ForeColor="red" runat="server"></asp:Label></span>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
     <script type="text/javascript">

              var _gaq = _gaq || [];
              _gaq.push(['_setAccount', 'UA-725913-6']);
              _gaq.push(['_trackPageview']);

              (function () {
                     var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
                     ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
                     var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
              })();

       </script>
</body>
</html>