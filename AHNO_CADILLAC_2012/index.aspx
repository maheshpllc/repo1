<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Confirm Callaway Card | Chevrolet</title>
    <meta http-equiv="X-UA-Compatible" content="IE=8; IE=EmulateIE9">
    <!--[if IE 7]>
       <link rel="stylesheet" href="http://css.hsn.com/css/ie7.css?v96" type="text/css" />
       <![endif]-->
    <link type="text/css" rel="stylesheet" href="css/style.css" />
    <script type="text/javascript" src="Js/formValidations.js"></script>
    <script type="text/javascript">
        function chkval() {
            var v_CardNo = strip_lspaces(document.getElementById('<%=txtActivationCode.ClientID %>').value);
            var v_Dcode = strip_lspaces(document.getElementById('<%=txtDealerCode.ClientID %>').value);

            if (isEmpty(v_CardNo)) addErrorMessage('Enter 8-DIGIT ACTIVATION CODE');
            if (isEmpty(v_Dcode)) addErrorMessage('Enter DEALER CODE OR BAC CODE ');

            return displayErrors();
        }

    </script>
</head>
<body>
    <form id="Indexform1" name="enterForm" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="JavaScript" type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequest);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequest);

        function beginRequest(sender, args) {
            // show the popup

            $find('<%=MainMp1.ClientID%>').show();
        }

        function endRequest(sender, args) {
            //  hide the popup
            $find('<%=MainMp1.ClientID%>').hide();
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlLogInfo" runat="server" DefaultButton="imgSumbit">
                <div id="contentContainer">
                    <div id="form1">
                        <div class="ErrorText" id="div01" runat="server">
                            <asp:Literal ID="ltrlerror" runat="server"></asp:Literal>
                        </div>
                        <div class="floatL" id="div02" runat="server">
                            <asp:TextBox ID="txtActivationCode" runat="server" class="form1TextField" MaxLength="8"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtActivationCode"
                                FilterType="Numbers" runat="server" />
                        </div>
                        <div class="form1Text" id="div03" runat="server">
                            ENTER 8-DIGIT ACTIVATION CODE <span class="disclaimerText">(Located on Back of Card)</span></div>
                        <div class="floatL" id="div04" runat="server">
                            <asp:TextBox ID="txtDealerCode" runat="server" class="form1TextField" MaxLength="10"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtDealerCode"
                                FilterType="Numbers" runat="server" />
                        </div>
                        <div class="form1Text" id="div05" runat="server">
                            ENTER DEALER CODE OR BAC CODE</div>
                        <div class="floatL" style="margin-top: 4px; margin-left: -1px;" id="div06" runat="server">
                            <asp:ImageButton ID="imgSumbit" runat="server" ImageUrl="images/enterButton.png"
                                OnClientClick="return chkval();" OnClick="imgSumbit_Click" />
                        </div>
                        <div class="form1Text" id="div07" runat="server" style="display: none;">
                            <h2>
                                The 2012 Cadillac Test Drive Program has ended as of December 15th. Thank you for
                                your participation in another great season.
                                <br />
                                <br />
                                Please call 800-822-2257 if you have any questions about the program.
                            </h2>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>
                    <div id="loginButton">
                        <a href="http://www.gmholeinone.com/" target="_blank">
                            <img src="images/loginButton.png" /></a></div>
                    <div id="AHNOlogo" style="display: block;">
                        <a href="http://www.ahno.net" target="_blank">
                            <img src="images/ahnoadmin.jpg" /></a></div>
                </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <cc1:ModalPopupExtender BackgroundCssClass="modalBackground" ID="MainMp1" runat="server"
        PopupControlID="pnlPopup" TargetControlID="pnlPopup">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlPopup" runat="server" Style="display: none">
        <div align="center">
            <img src="images/loader.gif" rel="lightbox" caption="test" />
        </div>
    </asp:Panel>
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