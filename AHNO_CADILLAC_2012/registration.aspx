<<<<<<< HEAD
﻿

testiing is going onnnnn......
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="registration"
=======
﻿register the solution ahno and push

thank you





%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="registration"
>>>>>>> 6802bf842124f014cd525618daf7fecd403b1846
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadillac Dealer Registration</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=8; IE=EmulateIE9">
    <!--[if IE 7]>
       <link rel="stylesheet" href="http://css.hsn.com/css/ie7.css?v96" type="text/css" />
       <![endif]-->
    <link type="text/css" rel="stylesheet" href="css/style.css" />
    <script type="text/javascript" src="Js/formValidations.js"></script>
    <script type="text/javascript" src="Scripts/jquery-1.4.4.min.js">
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtEmail').live("cut copy paste", function (e) {
                e.preventDefault();
            });
        });

        $(document).ready(function () {
            $('#txtCopyEamil').live("cut copy paste", function (e) {
                e.preventDefault();
            });
        });
    </script>
    <script type="text/javascript">
        function chkval() {

            var l_today = new Date();              // Initialize Date in raw form
            var l_cdate = l_today.getDate();       //   Get the numerical date
            var l_cyear = l_today.getFullYear()    // Get the year
            var l_cday = l_today.getDay();          // Get the day in number form (0,1,2,3,etc.)
            var l_cmonth = l_today.getMonth() + 1;   // Get the month
            var l_crrdt = l_cmonth + '/' + l_cdate + '/' + l_cyear;

            // Test Drive

            // var CadillacRbtnElr = document.getElementById('rdnELR').checked;
            var CadillacRbtnSportwagon = document.getElementById('rdnCtsSportsWagon').checked;
            var CadillacRbtnSrx = document.getElementById('rdnSRX').checked;
            // var CadillacRbtnAts = document.getElementById('rdnATS').checked;
            var CadillacRbtnCtssedan = document.getElementById('rdnCtsSedan').checked;
            var CadillacRbtnEscalade = document.getElementById('rdnEscalade').checked;
            var CadillacRbtnEscaladeHybrid = document.getElementById('rdnEscaladeHybrid').checked;
            var CadillacRbtnEscaladeESV = document.getElementById('rdnEscaladeESV').checked;
            var CadillacRbtnEscaladeEXT = document.getElementById('rdnEscaladeEXT').checked;
            var CadillacRbtnXLRRoadster = document.getElementById('rdnXLRRoadster').checked;
            var CadillacRbtnXTS = document.getElementById('rdnXTS').checked;
            var CadillacRbtnSportsWagon = document.getElementById('rdnSportsWagon').checked;

            // General Information
            var fname = strip_lspaces(document.getElementById('txtFirstName').value);
            var lname = strip_lspaces(document.getElementById('txtLastName').value);
            var addr = strip_lspaces(document.getElementById('txtAddress').value);
            var city = strip_lspaces(document.getElementById('txtCity').value);
            var state = document.getElementById('ddlState').value;
            var zip = strip_lspaces(document.getElementById('txtZipCode').value);
            var email = strip_lspaces(document.getElementById('txtEmail').value);
            var cemail = strip_lspaces(document.getElementById('txtCopyEamil').value);
            var phone = strip_lspaces(document.getElementById('txtPhoneNumber').value);
            var Pw = document.getElementById('rdnWorkPhone').checked;
            var Ph = document.getElementById('rdnHomePhone').checked;

            // var CadillacchkElr = document.getElementById('chkELR').checked;
            var CadillacchkCtssportwagon = document.getElementById('chkCtsSportsWagon').checked;
            var CadillacchkSrx = document.getElementById('chkSRX').checked;
            var CadillacchkAts = document.getElementById('chkATS').checked;
            var CadillacchkCtsSedan = document.getElementById('chkCtsSedan').checked;
            var CadillacchkEscalade = document.getElementById('chkEscalade').checked;
            var CadillacchkEscaladeHybrid = document.getElementById('chkEscaladeHybrid').checked;
            var CadillacchkEscaladeESV = document.getElementById('chkEscaladeESV').checked;
            var CadillacchkEscaladeEXT = document.getElementById('chkEscaladeEXT').checked;
            var CadillacchkXLRRoadster = document.getElementById('chkXLRRoadster').checked;
            var CadillacchkXTS = document.getElementById('chkXTS').checked;
            var CadillacchkSportsWagon = document.getElementById('chkSportsWagon').checked;

            // Contact Dealer Request
            var cntDealerYes = document.getElementById('rdnContactYes').checked;
            var cntDealerNo = document.getElementById('rdnContactNo').checked;

            // Preferred Dealer
            var contactY = document.getElementById('rdnpreferredDealerYes').checked;
            var contactN = document.getElementById('rdnpreferredDealerNo').checked;
            var contactdealer = strip_lspaces(document.getElementById('txtpreferredDealerName').value);

            // Planning
            var plan_purchase = document.getElementById('rdnPurchasing').checked;
            var plan_lease = document.getElementById('rdnLeasing').checked;

            // With In
            var Within1 = document.getElementById('rdnWithin01').checked;
            var Within2 = document.getElementById('rdnWithin02').checked;
            var Within3 = document.getElementById('rdnWithin03').checked;
            var Within4 = document.getElementById('rdnWithin04').checked;
            var Within5 = document.getElementById('rdnWithin05').checked;

            // Vehicle Purpose
            var personal = document.getElementById('rdnPersonalUse').checked;
            var business = document.getElementById('rdnBusinessUse').checked;

            // Vehicle Replace 01

            var rep_make01 = document.getElementById('ddlMake01').value;
            var rep_model01 = document.getElementById('ddlModel01').value;
            var rep_year01 = document.getElementById('ddlYear01').value;

            // Vehicle Replace 02
            var rep_make02 = document.getElementById('ddlMake02').value;
            var rep_model02 = document.getElementById('ddlModel02').value;
            var rep_year02 = document.getElementById('ddlYear02').value;

            // Check Confirm
            var cof = document.getElementById('chkiConfirm').checked;

            // Test Drive Dealer & Salesperson
            var dealer = strip_lspaces(document.getElementById('txtDealerName').value);
            var dealer_email = strip_lspaces(document.getElementById('txtDealerEmail').value);
            var salesperson = strip_lspaces(document.getElementById('txtSalespersonName').value);
            var salesperson_email = strip_lspaces(document.getElementById('txtSalesEmailAddress').value);
            var testdrivedt = strip_lspaces(document.getElementById('txtTestDriveDate').value);

            // Currently House Hold Vehicles
            // House Hold Vehicle 01
            var Replace_Make01 = document.getElementById('ddlMake01').value;
            var Replace_Model01 = document.getElementById('ddlModel01').value;
            var Replace_OtherMake01 = strip_lspaces(document.getElementById('txtOtherMake01').value);
            var Replace_OtherModel01 = strip_lspaces(document.getElementById('txtOtherModel01').value);
            var Replace_Year01 = document.getElementById('ddlYear01').value;

            // House Hold Vehicle 02
            var Replace_Make02 = document.getElementById('ddlMake02').value;
            var Replace_Model02 = document.getElementById('ddlModel02').value;
            var Replace_OtherMake02 = strip_lspaces(document.getElementById('txtOtherMake02').value);
            var Replace_OtherModel02 = strip_lspaces(document.getElementById('txtOtherModel02').value);
            var Replace_Year02 = document.getElementById('ddlYear02').value;

            var d = new Date();
            var today = d.getDate();

            //            if (!(CadillacRbtnElr || CadillacRbtnSportwagon || CadillacRbtnSrx || CadillacRbtnAts || CadillacRbtnCtssedan || CadillacRbtnEscalade || CadillacRbtnEscaladeHybrid || CadillacRbtnEscaladeESV || CadillacRbtnEscaladeEXT || CadillacRbtnXLRRoadster || CadillacRbtnXTS || CadillacRbtnSportsWagon)) {
            //                addErrorMessage('Select At least one Cadillac Model Test Drive');
            //            }
            if (!(CadillacRbtnSportwagon || CadillacRbtnSrx || CadillacRbtnCtssedan || CadillacRbtnEscalade || CadillacRbtnEscaladeHybrid || CadillacRbtnEscaladeESV || CadillacRbtnEscaladeEXT || CadillacRbtnXLRRoadster || CadillacRbtnXTS || CadillacRbtnSportsWagon)) {
                addErrorMessage('Select At least one Cadillac Model Test Drive');
            }

            // General Information
            if (isEmpty(fname)) addErrorMessage('Enter First Name');
            else if (isNotAlphaNumeric(fname)) addErrorMessage('Invalid First Name. Enter AlphaNumeric only!');

            if (isEmpty(lname)) addErrorMessage('Enter Last Name');
            else if (isNotAlphaNumeric(lname)) addErrorMessage('Invalid Last Name. Enter AlphaNumeric only!');

            if (isEmpty(phone)) addErrorMessage('Enter Phone Number');
            else if (isNotPhoneNumber(phone)) addErrorMessage('Invalid Phone Number');

            if (!Pw && !Ph) {
                addErrorMessage('Select Phone Type');
            }

            if (isEmpty(addr)) addErrorMessage('Enter Address');

            if (isEmpty(city)) addErrorMessage('Enter City');
            else if (isNotCity(city)) addErrorMessage('Invalid City. Enter AlphaNumeric only!');

            if (state == "0") { addErrorMessage('Select State'); }

            if (isEmpty(zip)) addErrorMessage('Enter Zip Code');
            else if (isNaN(zip)) addErrorMessage('Invalid Zip Code. Enter Numeric only!');
            else if (isNotZipCode(zip)) addErrorMessage('Invalid Zip Code');

            if (isEmpty(email)) addErrorMessage('Enter Email Address');
            else if (isNotAnEmail(email)) addErrorMessage('Invalid Email Address');

            if (isEmpty(cemail)) addErrorMessage('Enter Confirm Email Address');
            else if (isNotAnEmail(cemail)) addErrorMessage('Invalid Confirm Email Address');

            if (email != "" && cemail != "") {
                if (email != cemail) {
                    addErrorMessage('Entered Email Address and Confirm Email Address does not match.');
                }
            }

            // Cadillac Model
            if (!(CadillacchkCtssportwagon || CadillacchkCtssportwagon || CadillacchkSrx || CadillacchkAts || CadillacchkCtsSedan || CadillacchkEscalade || CadillacchkEscaladeHybrid || CadillacchkEscaladeESV || CadillacchkEscaladeEXT || CadillacchkXLRRoadster || CadillacchkXTS || CadillacchkSportsWagon)) {
                addErrorMessage('Select At least one Cadillac Model to Send Information');
            }

            // Contact Dealer
            if (!cntDealerYes && !cntDealerNo) { addErrorMessage('Select whether you like dealer representative to contact you about the Cadillac models you are interested in ?'); }

            // Preferred Dealer
            if (!contactY && !contactN) { addErrorMessage('Select if you have preferred dealer'); }
            if (contactY) { if (isEmpty(contactdealer)) addErrorMessage('Enter preferred dealer name'); }

            // Planning
            if (!plan_purchase && !plan_lease) { addErrorMessage('Select Planning to purchase or lease your next vehicle'); }

            // With In
            if (!Within1 && !Within2 && !Within3 && !Within4 && !Within5) { addErrorMessage('Select time frame on purchase or lease your next vehicle'); }

            // Vehicle Purpose
            if (!personal && !business) { addErrorMessage('Select your interested in a vehicle usage for'); }

            //Currently in your Household 01
            if (Replace_Make01 != "0") {
                if (Replace_Make01 == "OTH") {

                    if (Replace_Year01 == "0") {

                        addErrorMessage('Select Vehicle Year in your Household');
                    }
                    if (isEmpty(Replace_OtherMake01)) addErrorMessage('Enter Other Vehicle Make in your Household');
                    if (isEmpty(Replace_OtherModel01)) addErrorMessage('Enter Other Vehicle Model in your Household');
                } else {

                    if (Replace_Model01 == "0") {
                        addErrorMessage('Select Vehicle Model in your Household');
                    }

                    if (Replace_Year01 == "0") {

                        addErrorMessage('Select Vehicle Year in your Household');
                    }
                }
            }

            //Currently in your Household 02
            if (Replace_Make02 != "0") {
                if (Replace_Make02 == "OTH") {
                    if (Replace_Year02 == "0") {

                        addErrorMessage('Select Vehicle Year in your Household');
                    }
                    if (isEmpty(Replace_OtherMake02)) addErrorMessage('Enter Other Vehicle Make in your Household');
                    if (isEmpty(Replace_OtherModel02)) addErrorMessage('Enter Other Vehicle Model in your Household');
                } else {
                    if (Replace_Model02 == "0") {
                        addErrorMessage('Select Vehicle Model in your Household');
                    }

                    if (Replace_Year02 == "0") {

                        addErrorMessage('Select Vehicle Year in your Household');
                    }
                }

            }

            // Confirm Check
            if (!cof) { addErrorMessage('Please verify all the test drive information entered is authentic and correct.'); }

            // Test Drive Dealer and Salesperson Information

            if (isEmpty(dealer)) addErrorMessage('Enter Dealership Name');
            else if (isNotDealerAlphaNumeric(dealer)) addErrorMessage('Invalid Dealership Name. Enter AlphaNumeric only!');

            if (isEmpty(testdrivedt)) { addErrorMessage('Enter Date of Test Drive'); }
            else if (isNotDate(testdrivedt)) { addErrorMessage('Invalid Date of Test Drive'); }
            else if (testdrivedt == "00/00/0000") { addErrorMessage('Invalid Date of Test Drive'); }
            else if (CompareTodayDate(testdrivedt)) { addErrorMessage('Invalid Date for Test Drive. It should be Greater than or equal to Current Date'); }

            if (isEmpty(salesperson)) addErrorMessage('Enter Salesperson Name');
            else if (isNotAlphaNumeric(salesperson)) addErrorMessage('Invalid Salespersons Name. Enter AlphaNumeric only!');

            if (isEmpty(salesperson_email)) addErrorMessage('Enter Salesperson Email Address');
            else if (isNotAnEmail(salesperson_email)) addErrorMessage('Invalid Salesperson Email Address');

            if (email != "" && salesperson_email != "") {
                if (email == salesperson_email) {
                    addErrorMessage('Enter Valid Salesperson Email Address. Sales Person Email address cannot be same as Test Drive Email Address');
                }
            }

            return displayErrors();
        }

        function ChangePreferDealer() {
            var cntY = document.getElementById('rdnpreferredDealerYes').checked;
            var cntN = document.getElementById('rdnpreferredDealerNo').checked;
            var cntDealer = document.getElementById('txtpreferredDealerName');
            if (cntY == true) {
                cntDealer.setAttribute("class", "textFieldOther"); //For Most Browsers
                cntDealer.setAttribute("className", "textFieldOther"); //For IE; harmless to other browsers.
                cntDealer.getAttribute('className', 'textFieldOther'); //for IE
                cntDealer.getAttribute('class', 'textFieldOther'); //everybody else
                cntDealer.focus();
            }
            else if (cntN == true) {
                cntDealer.setAttribute("class", "textFieldMediumTxt"); //For Most Browsers
                cntDealer.setAttribute("className", "textFieldMediumTxt"); //For IE; harmless to other browsers.
                cntDealer.getAttribute('className', 'textFieldMediumTxt'); //for IE
                cntDealer.getAttribute('class', 'textFieldMediumTxt'); //everybody else
            }
            else {
                cntDealer.setAttribute("class", "textFieldMediumTxt"); //For Most Browsers
                cntDealer.setAttribute("className", "textFieldMediumTxt"); //For IE; harmless to other browsers.
                cntDealer.getAttribute('className', 'textFieldMediumTxt'); //for IE
                cntDealer.getAttribute('class', 'textFieldMediumTxt'); //everybody else
            }
        }

        function ChangeReplaceModel01() {
            var l_vmake01 = document.getElementById('ddlMake01').value;
            var l_other_vmodel01 = document.getElementById('divReplaceModelOther01');
            var l_vmodel01 = document.getElementById('divReplaceModel01');

            if (l_vmake01 == "OTH") {
                l_other_vmodel01.style.display = "block";
                l_vmodel01.style.display = "none";
                l_other_vmodel01.focus();
                return false;

            } else {
                l_other_vmodel01.style.display = "none";
                l_vmodel01.style.display = "block";
                l_vmodel01.focus();

            }
        }

        function ChangeReplaceModel02() {
            var l_vmake02 = document.getElementById('ddlMake02').value;
            var l_other_vmodel02 = document.getElementById('divReplaceOtherModel02');
            var l_vmodel02 = document.getElementById('divReplaceModel02');

            if (l_vmake02 == "OTH") {
                l_other_vmodel02.style.display = "block";
                l_vmodel02.style.display = "none";
                l_other_vmodel02.focus();
                return false;

            } else {
                l_other_vmodel02.style.display = "none";
                l_vmodel02.style.display = "block";
                l_vmodel02.focus();
                l_vmodel02.setAttribute("AutoPostBack", "True");

            }
        }
    </script>
</head>
<body>
    <form id="formReservation" runat="server" name="myform">
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
            <div id="contentContainer2">
                <div class="floatL">
                    <img src="images/header.jpg" /></div>
                <div class="floatC" style="margin-top: 20px; margin-bottom: 40px;">
                    <span class="whiteText">Please complete and submit the information below to activate
                        the customer's $75 Callaway Golf e-Coupon, courtesy of your dealership.<br />
                        The $75 Callaway Golf e-Coupon will be sent to the customer's email address, as
                        listed below.</span></div>
                <div class="floatC">
                    <div id="testDriveModel">
                        <div align="left" style="padding-left: 80px; padding-top: 2px;">
                            <div style="padding-left: 240px;">
                                CADILLAC Model Test Drive<br />
                                <br />
                            </div>
                            <div class="row" align="left">
                                <%-- <div class="checkBoxDiv" style="width: 200px;">
                                    <label for="<%=rdnELR.ClientID%>">
                                        <asp:RadioButton ID="rdnELR" runat="server" GroupName="TestDrive" TextAlign="Right"
                                            TabIndex="1" />
                                        All New 2014 ELR
                                    </label>
                                </div>--%>
                                <div class="checkBoxDiv" style="width: 200px;">
                                    <label for="<%=rdnCtsSportsWagon.ClientID%>">
                                        <asp:RadioButton ID="rdnCtsSportsWagon" runat="server" GroupName="TestDrive" TextAlign="Right"
                                            TabIndex="1" />
                                        CTS Sports Wagon</label>
                                </div>
                                <div class="checkBoxDiv" style="width: 200px;">
                                    <label for="<%=rdnSRX.ClientID%>">
                                        <asp:RadioButton ID="rdnSRX" runat="server" GroupName="TestDrive" TextAlign="Right"
                                            TabIndex="1" />
                                        SRX Crossover</label>
                                </div>
                                <div class="checkBoxDiv" style="width: 200px;">
                                    <label for="<%=rdnCtsSedan.ClientID%>">
                                        <asp:RadioButton ID="rdnCtsSedan" runat="server" GroupName="TestDrive" TextAlign="Right"
                                            TabIndex="1" />
                                        CTS Sedan</label>
                                </div>
                            </div>
                            <div class="row" align="left">
                                <div class="checkBoxDiv" style="width: 200px;">
                                    <label for="<%=rdnEscaladeHybrid.ClientID%>">
                                        <asp:RadioButton ID="rdnEscaladeHybrid" runat="server" GroupName="TestDrive" TextAlign="Right"
                                            TabIndex="1" />
                                        Escalade Hybrid</label>
                                </div>
                                <div class="checkBoxDiv" style="width: 200px;">
                                    <label for="<%=rdnEscaladeESV.ClientID%>">
                                        <asp:RadioButton ID="rdnEscaladeESV" runat="server" GroupName="TestDrive" TextAlign="Right"
                                            TabIndex="1" />
                                        Escalade ESV</label>
                                </div>
                                <div class="checkBoxDiv">
                                    <label for="<%=rdnEscaladeEXT.ClientID%>">
                                        <asp:RadioButton ID="rdnEscaladeEXT" runat="server" GroupName="TestDrive" TextAlign="Right"
                                            TabIndex="1" />
                                        Escalade EXT</label>
                                </div>
                                <div class="row" align="left">
                                    <div class="checkBoxDiv" style="width: 200px;">
                                        <label for="<%=rdnXLRRoadster.ClientID%>">
                                            <asp:RadioButton ID="rdnXLRRoadster" runat="server" GroupName="TestDrive" TextAlign="Right"
                                                TabIndex="1" />
                                            XLR Roadster</label>
                                    </div>
                                    <div class="checkBoxDiv" style="width: 200px;">
                                        <label for="<%=rdnXTS.ClientID%>">
                                            <asp:RadioButton ID="rdnXTS" runat="server" GroupName="TestDrive" TextAlign="Right"
                                                TabIndex="1" />
                                            All-New XTS</label>
                                    </div>
                                    <div class="checkBoxDiv" style="width: 200px;">
                                        <label for="<%=rdnSportsWagon.ClientID%>">
                                            <asp:RadioButton ID="rdnSportsWagon" runat="server" GroupName="TestDrive" TextAlign="Right"
                                                TabIndex="1" />
                                            CTS-V Sports Wagon</label>
                                    </div>
                                </div>
                            </div>
                            <div class="row" align="left">
                                <%-- <div class="checkBoxDiv" style="width: 200px;">
                                    <label for="<%=rdnATS.ClientID%>">
                                        <asp:RadioButton ID="rdnATS" runat="server" GroupName="TestDrive" TextAlign="Right"
                                            TabIndex="1" />
                                        ATS</label>
                                </div>--%>
                                <div class="checkBoxDiv" style="width: 200px;">
                                    <label for="<%=rdnEscalade.ClientID%>">
                                        <asp:RadioButton ID="rdnEscalade" runat="server" GroupName="TestDrive" TextAlign="Right"
                                            TabIndex="1" />
                                        Escalade</label>
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="redText">
                        <br />
                        By providing my contact information below, I consent that GM and/or a GM dealer
                        can contact me
                        <br />
                        with any GM offers and GM Product information.
                        <%-- <label for="<%=chkContactInfo.ClientID%>">
                                                 <asp:CheckBox ID="chkContactInfo" TabIndex="1" runat="server" TextAlign="Right" Text=" By providing my contact information below, I consent that GM and/or a GM dealer can contact me <BR /> with any GM offers and GM Product information." />
                                          </label>--%>
                    </div>
                </div>
                <div class="floatL" style="margin-left: 120px; margin-top: 34px;">
                    <asp:Label ID="lblErrMessage" Visible="false" Font-Bold="true" class="text" ForeColor="red"
                        runat="server"></asp:Label>
                    <asp:HiddenField ID="hdnTournamentId" runat="server" />
                    <asp:HiddenField ID="hdnDealerId" runat="server" />
                    <asp:HiddenField ID="hdnDealerCode" runat="server" />
                    <asp:HiddenField ID="hdnBACode" runat="server" />
                    <asp:HiddenField ID="hdnContractID" runat="server" />
                    <asp:HiddenField ID="hdnActivateId" runat="server" />
                    <asp:HiddenField ID="hdnRegion" runat="server" />
                </div>
                <div class="floatL" style="margin-left: 700px; margin-top: 5px; margin-bottom: 20px;">
                    <span class="redText">*Required Fields</span>
                </div>
                <div id="form2">
                    <div class="row">
                        <div class="formField">
                            <label for="<%=txtFirstName.ClientID%>">
                                First Name<span class="required">*</span><br />
                                <asp:TextBox ID="txtFirstName" runat="server" TabIndex="1" MaxLength="30" class="textField"></asp:TextBox>
                            </label>
                        </div>
                        <div class="formField">
                            <label for="<%=txtLastName.ClientID%>">
                                Last Name<span class="required">*</span><br />
                                <asp:TextBox ID="txtLastName" runat="server" TabIndex="1" MaxLength="30" class="textField"></asp:TextBox>
                            </label>
                        </div>
                        <div class="formField">
                            <label for="<%=txtPhoneNumber.ClientID%>">
                                Phone Number<span class="required">*</span><br />
                                <asp:TextBox ID="txtPhoneNumber" runat="server" TabIndex="1" MaxLength="17" class="textField"
                                    onkeyup="formatphonenumber(this);" ToolTip="Use this format(XXX-XXX-XXXX)"></asp:TextBox><br />
                                <label id="ph_format" style="display: none;" runat="server">
                                    (XXX-XXX-XXXX)</label>
                            </label>
                        </div>
                        <div class="formField" style="padding-top: 12px;">
                            <asp:RadioButton ID="rdnWorkPhone" runat="server" TabIndex="1" TextAlign="Right"
                                GroupName="PhoneType" Text=" Work" class="padLeft8" />
                            <asp:RadioButton ID="rdnHomePhone" runat="server" TabIndex="1" TextAlign="Right"
                                GroupName="PhoneType" Text=" Home" class="padLeft8" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="formField">
                            <label for="<%=txtAddress.ClientID%>">
                                Address<span class="required">*</span><br />
                                <asp:TextBox ID="txtAddress" runat="server" TabIndex="1" class="textFieldLong" MaxLength="150"></asp:TextBox>
                            </label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="formField">
                            <label for="<%=txtCity.ClientID%>">
                                City<span class="required">*</span><br />
                                <asp:TextBox ID="txtCity" runat="server" TabIndex="1" MaxLength="15" class="textFieldMedium"></asp:TextBox>
                            </label>
                        </div>
                        <div class="formField">
                            <label for="<%=ddlState.ClientID%>">
                                State<span class="required">*</span><br />
                                <asp:DropDownList ID="ddlState" runat="server" class="selectField" TabIndex="1">
                                    <asp:ListItem Selected="True" Text="-- Select State --" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </label>
                        </div>
                        <div class="formField">
                            <label for="<%=txtZipCode.ClientID%>">
                                Zip Code<span class="required">*</span><br />
                                <asp:TextBox ID="txtZipCode" runat="server" TabIndex="1" MaxLength="6" class="textFieldZip"></asp:TextBox>
                            </label>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 12px;">
                        <span class="redText">Please ensure the email address is correct - the Callaway Gift
                            Card Code (e-Coupon) will be emailed to this address
                            <br />
                            upon submission.</span>
                    </div>
                    <div class="row" style="margin-top: 6px;">
                        <div class="formField">
                            <label for="<%=txtEmail.ClientID%>">
                                Email Address<span class="required">*</span><br />
                                <asp:TextBox ID="txtEmail" runat="server" TabIndex="1" MaxLength="150" class="textFieldMediumTxt"></asp:TextBox>
                            </label>
                        </div>
                        <div class="formField">
                            <label for="<%=txtCopyEamil.ClientID%>">
                                Confirm Email Address<span class="required">*</span><br />
                                <asp:TextBox ID="txtCopyEamil" runat="server" TabIndex="1" MaxLength="150" class="textFieldMediumTxt"></asp:TextBox>
                            </label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="formField">
                            <label for="<%=txtTournamentName.ClientID%>">
                                Tournament Name<br />
                                <asp:TextBox ID="txtTournamentName" ReadOnly="true" runat="server" TabIndex="1" MaxLength="150"
                                    class="textFieldMediumTxt"></asp:TextBox>
                            </label>
                        </div>
                        <div class="formField">
                            <label for="<%=txtTourDate.ClientID%>">
                                Tournament Date<br />
                                <asp:TextBox ID="txtTourDate" ReadOnly="true" runat="server" TabIndex="1" MaxLength="150"
                                    class="textFieldMediumTxt"></asp:TextBox>
                            </label>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 16px;">
                        <div class="boldTitle">
                            Please send me information on the following Cadillac Model(s):<span class="required">*</span></div>
                    </div>
                    <div class="row">
                        <div class="box">
                            <div class="row" align="left">
                                <div class="checkBoxDiv" style="width: 200px;">
                                    <%-- <label for="<%=chkELR.ClientID%>">
                                        <asp:CheckBox ID="chkELR" runat="server" TextAlign="Right" TabIndex="1" />
                                        All New 2014 ELR
                                    </label>--%>
                                </div>
                                <div class="checkBoxDiv" style="width: 200px;">
                                    <label for="<%=chkCtsSportsWagon.ClientID%>">
                                        <asp:CheckBox ID="chkCtsSportsWagon" runat="server" TextAlign="Right" TabIndex="1" />
                                        CTS Sports Wagon</label>
                                </div>
                                <div class="checkBoxDiv" style="width: 200px;">
                                    <label for="<%=chkSRX.ClientID%>">
                                        <asp:CheckBox ID="chkSRX" runat="server" TextAlign="Right" TabIndex="1" />
                                        SRX Crossover</label>
                                </div>
                            </div>
                            <div class="row" align="left">
                                <div class="checkBoxDiv" style="width: 200px;">
                                    <label for="<%=chkATS.ClientID%>">
                                        <asp:CheckBox ID="chkATS" runat="server" TextAlign="Right" TabIndex="1" />
                                        All-New ATS</label>
                                </div>
                                <div class="checkBoxDiv" style="width: 200px;">
                                    <label for="<%=chkCtsSedan.ClientID%>">
                                        <asp:CheckBox ID="chkCtsSedan" runat="server" TextAlign="Right" TabIndex="1" />
                                        CTS Sedan</label>
                                </div>
                                <div class="checkBoxDiv">
                                    <label for="<%=chkEscalade.ClientID%>">
                                        <asp:CheckBox ID="chkEscalade" runat="server" TextAlign="Right" TabIndex="1" />
                                        Escalade</label>
                                </div>
                            </div>
                            <div class="row" align="left">
                                <div class="checkBoxDiv" style="width: 200px;">
                                    <label for="<%=chkEscaladeHybrid.ClientID%>">
                                        <asp:CheckBox ID="chkEscaladeHybrid" runat="server" TextAlign="Right" TabIndex="1" />
                                        Escalade Hybrid</label>
                                </div>
                                <div class="checkBoxDiv" style="width: 200px;">
                                    <label for="<%=chkEscaladeESV.ClientID%>">
                                        <asp:CheckBox ID="chkEscaladeESV" runat="server" TextAlign="Right" TabIndex="1" />
                                        Escalade ESV</label>
                                </div>
                                <div class="checkBoxDiv">
                                    <label for="<%=chkEscaladeEXT.ClientID%>">
                                        <asp:CheckBox ID="chkEscaladeEXT" runat="server" TextAlign="Right" TabIndex="1" />
                                        Escalade EXT</label>
                                </div>
                                <div class="row" align="left">
                                    <div class="checkBoxDiv" style="width: 200px;">
                                        <label for="<%=chkXLRRoadster.ClientID%>">
                                            <asp:CheckBox ID="chkXLRRoadster" runat="server" TextAlign="Right" TabIndex="1" />
                                            XLR Roadster</label>
                                    </div>
                                    <div class="checkBoxDiv" style="width: 200px;">
                                        <label for="<%=rdnXTS.ClientID%>">
                                            <asp:CheckBox ID="chkXTS" runat="server" TextAlign="Right" TabIndex="1" />
                                            All-New XTS</label>
                                    </div>
                                    <div class="checkBoxDiv" style="width: 200px;">
                                        <label for="<%=chkSportsWagon.ClientID%>">
                                            <asp:CheckBox ID="chkSportsWagon" runat="server" GroupName="TestDrive" TextAlign="Right"
                                                TabIndex="1" />
                                            CTS-V Sports Wagon</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 16px;">
                        <div class="boldTitle" style="width: 100%;">
                            <label for="<%=rdnContactYes.ClientID%>">
                                Would you like a dealer representative to contact you about the Cadillac model(s)
                                you are interested in?<span class="required">*</span></label></div>
                        <div class="formText" style="width: 300px; margin-top: 12px;">
                            <asp:RadioButton ID="rdnContactYes" runat="server" TabIndex="1" GroupName="GroupContact"
                                TextAlign="Right" Text=" Yes" />
                        </div>
                        <div class="formText" style="width: 300px; margin-top: 12px;">
                            <asp:RadioButton ID="rdnContactNo" runat="server" TabIndex="1" GroupName="GroupContact"
                                TextAlign="Right" Text=" No" /></div>
                    </div>
                    <div class="row" style="margin-top: 16px;">
                        <div class="boldTitle" style="width: 100%;">
                            <label for="<%=rdnpreferredDealerYes.ClientID%>">
                                Do you have a preferred dealer?<span class="required">*</span></label></div>
                        <div class="formText" style="width: 300px; margin-top: 12px;">
                            <asp:RadioButton ID="rdnpreferredDealerYes" runat="server" TabIndex="1" GroupName="GrouppreferredDealer"
                                TextAlign="Right" Text=" Yes" onclick="ChangePreferDealer()" />
                        </div>
                        <div class="formText" style="width: 300px; margin-top: 12px;">
                            <asp:RadioButton ID="rdnpreferredDealerNo" runat="server" TabIndex="1" GroupName="GrouppreferredDealer"
                                TextAlign="Right" Text=" No" onclick="ChangePreferDealer()" /></div>
                        <div class="row" style="margin-top: 10px;">
                            <div class="formText">
                                <label for="<%=txtpreferredDealerName.ClientID%>">
                                    <b>If yes:</b> Dealer Name</label>
                                <asp:TextBox ID="txtpreferredDealerName" runat="server" MaxLength="30" TabIndex="1"
                                    class="textFieldMediumTxt"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 30px;">
                        <div class="boldTitle" style="width: 100%;">
                            <label for="<%=rdnPurchasing.ClientID%>">
                                I am planning on:<span class="required">*</span></label></div>
                        <div class="formText" style="width: 300px; margin-top: 12px;">
                            <asp:RadioButton ID="rdnPurchasing" runat="server" TabIndex="1" GroupName="GroupPlanning"
                                TextAlign="Right" Text=" Purchasing" />
                        </div>
                        <div class="formText" style="width: 300px; margin-top: 12px;">
                            <asp:RadioButton ID="rdnLeasing" runat="server" TabIndex="1" GroupName="GroupPlanning"
                                TextAlign="Right" Text=" Leasing" />
                        </div>
                    </div>
                    <div class="row" style="margin-top: 30px;">
                        <div class="boldTitle" style="width: 100%;">
                            <label for="<%=rdnWithin01.ClientID%>">
                                Within:<span class="required">*</span></label></div>
                        <div class="row">
                            <div class="formText" style="width: 300px; margin-top: 12px;">
                                <asp:RadioButton ID="rdnWithin01" runat="server" TabIndex="1" GroupName="GroupWithin"
                                    TextAlign="Right" Text=" 1 month or less" />
                            </div>
                            <div class="formText" style="width: 300px; margin-top: 12px;">
                                <asp:RadioButton ID="rdnWithin02" runat="server" TabIndex="1" GroupName="GroupWithin"
                                    TextAlign="Right" Text=" 1-3 Months" />
                            </div>
                            <div class="formText" style="width: 300px; margin-top: 12px;">
                                <asp:RadioButton ID="rdnWithin03" runat="server" TabIndex="1" GroupName="GroupWithin"
                                    TextAlign="Right" Text=" 4-6 Months" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="formText" style="width: 300px; margin-top: 12px;">
                                <asp:RadioButton ID="rdnWithin04" runat="server" TabIndex="1" GroupName="GroupWithin"
                                    TextAlign="Right" Text=" 7-12 Months" />
                            </div>
                            <div class="formText" style="width: 300px; margin-top: 12px;">
                                <asp:RadioButton ID="rdnWithin05" runat="server" TabIndex="1" GroupName="GroupWithin"
                                    TextAlign="Right" Text=" More than 1 year" />
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 30px;">
                        <div class="boldTitle" style="width: 100%;">
                            <label for="<%=rdnPersonalUse.ClientID%>">
                                I'm interested in a vehicle for:<span class="required">*</span></label></div>
                        <div class="formText" style="width: 300px; margin-top: 12px;">
                            <asp:RadioButton ID="rdnPersonalUse" runat="server" TabIndex="1" GroupName="GroupInterestedVehicle"
                                TextAlign="Right" Text=" Personal use" />
                        </div>
                        <div class="formText" style="width: 300px; margin-top: 12px;">
                            <asp:RadioButton ID="rdnBusinessUse" runat="server" TabIndex="1" GroupName="GroupInterestedVehicle"
                                TextAlign="Right" Text=" Business use" />
                        </div>
                    </div>
                    <div class="row" style="margin-top: 20px;">
                        <div id="housevechiles" runat="server" style="display: block;">
                            <div class="boldTitle" style="width: 100%;">
                                <label for="<%=ddlMake01.ClientID%>">
                                    What vehicles are currently in your household?</label></div>
                            <div class="row" style="margin-top: 12px;">
                                <div class="formField">
                                    <label for="<%=ddlMake01.ClientID%>">
                                        Make<br />
                                        <asp:DropDownList ID="ddlMake01" runat="server" class="selectFieldDark" TabIndex="1"
                                            onChange="ChangeReplaceModel01();" AutoPostBack="True" OnSelectedIndexChanged="ddlMake01_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </label>
                                </div>
                                <div class="formField" id="divReplaceModel01" runat="server">
                                    <label for="<%=ddlModel01.ClientID%>">
                                        Model<br />
                                        <asp:DropDownList ID="ddlModel01" runat="server" class="selectFieldDark" TabIndex="1">
                                        </asp:DropDownList>
                                    </label>
                                </div>
                                <div class="formField">
                                    <label for="<%=ddlYear01.ClientID%>">
                                        Year<br />
                                        <asp:DropDownList ID="ddlYear01" runat="server" class="selectFieldDark" TabIndex="1">
                                        </asp:DropDownList>
                                    </label>
                                </div>
                            </div>
                            <div class="row" id="divReplaceModelOther01" runat="server" style="display: none;">
                                <div class="formField">
                                    <label for="<%=txtOtherMake01.ClientID%>">
                                        Make<br />
                                        <asp:TextBox ID="txtOtherMake01" runat="server" TabIndex="1" MaxLength="30" class="textFieldMedium"></asp:TextBox>
                                    </label>
                                </div>
                                <div class="formField">
                                    <label for="<%=txtOtherModel01.ClientID%>">
                                        Model<br />
                                        <asp:TextBox ID="txtOtherModel01" runat="server" TabIndex="1" MaxLength="50" class="textFieldMedium"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="formField">
                                    <label for="<%=ddlMake02.ClientID%>">
                                        Make<br />
                                        <asp:DropDownList ID="ddlMake02" runat="server" class="selectFieldDark" TabIndex="1"
                                            onChange=" ChangeReplaceModel02();" AutoPostBack="True" OnSelectedIndexChanged="ddlMake02_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </label>
                                </div>
                                <div class="formField" id="divReplaceModel02" runat="server">
                                    <label for="<%=ddlModel02.ClientID%>">
                                        Model<br />
                                        <asp:DropDownList ID="ddlModel02" runat="server" class="selectFieldDark" TabIndex="1">
                                        </asp:DropDownList>
                                    </label>
                                </div>
                                <div class="formField">
                                    <label for="<%=ddlYear02.ClientID%>">
                                        Year<br />
                                        <asp:DropDownList ID="ddlYear02" runat="server" class="selectFieldDark" TabIndex="1">
                                        </asp:DropDownList>
                                    </label>
                                </div>
                            </div>
                            <div class="row" id="divReplaceOtherModel02" runat="server" style="display: none;">
                                <div class="formField">
                                    <label for="<%=txtOtherMake02.ClientID%>">
                                        Make<br />
                                        <asp:TextBox ID="txtOtherMake02" runat="server" TabIndex="1" MaxLength="30" class="textFieldMedium"></asp:TextBox>
                                    </label>
                                </div>
                                <div class="formField">
                                    <label for="<%=txtOtherModel02.ClientID%>">
                                        Model<br />
                                        <asp:TextBox ID="txtOtherModel02" runat="server" TabIndex="1" MaxLength="50" class="textFieldMedium"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 40px; margin-bottom: 40px;">
                                <div style="border-bottom: 1px solid #655c4f; width: 850px;">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="redText">
                                <label for="<%=chkiConfirm.ClientID%>">
                                    <asp:CheckBox ID="chkiConfirm" TabIndex="1" runat="server" TextAlign="Right" Text=" I have verified all the test drive information entered above is authentic and correct." />
                                </label>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 12px;">
                            <div class="formField">
                                <label for="<%=txtDealerName.ClientID%>">
                                    Dealership Name<span class="required">*</span><br />
                                    <asp:TextBox ID="txtDealerName" runat="server" TabIndex="1" MaxLength="50" class="textFieldMediumTxt"></asp:TextBox>
                                </label>
                            </div>
                            <div class="formField" id="dealerEmail" style="display: none;">
                                <label for="<%=txtDealerEmail.ClientID%>">
                                    Dealer Email Address<span class="required">*</span><br />
                                    <asp:TextBox ID="txtDealerEmail" runat="server" TabIndex="1" MaxLength="150" class="textFieldMediumTxt"></asp:TextBox>
                                </label>
                            </div>
                            <div class="formField">
                                <label for="<%=txtTestDriveDate.ClientID%>">
                                    Date of Test Drive<span class="required">*</span><br />
                                    <asp:TextBox ID="txtTestDriveDate" runat="server" TabIndex="1" MaxLength="13" class="textFieldMediumTxt"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTestDriveDate"
                                        PopupButtonID="txtTestDriveDate" Format="MM/dd/yyyy" Animated="false" CssClass="MyCalendar2">
                                    </cc1:CalendarExtender>
                                </label>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 12px;">
                            <div class="formField">
                                <label for="<%=txtSalespersonName.ClientID%>">
                                    Salesperson Name<span class="required">*</span><br />
                                    <asp:TextBox ID="txtSalespersonName" runat="server" TabIndex="1" MaxLength="50" class="textFieldMediumTxt"></asp:TextBox>
                                </label>
                            </div>
                            <div class="formField">
                                <label for="<%=txtSalesEmailAddress.ClientID%>">
                                    Salesperson Email Address<span class="required">*</span><br />
                                    <asp:TextBox ID="txtSalesEmailAddress" runat="server" TabIndex="1" MaxLength="50"
                                        class="textFieldMediumTxt"></asp:TextBox>
                                </label>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 20px; margin-bottom: 40px; margin-left: 260px;">
                            <asp:ImageButton ID="imgSubmit" runat="server" ImageUrl="images/enterButton2.JPG"
                                OnClientClick="return chkval();" TabIndex="1" OnClick="imgSubmit_Click" />
                        </div>
                        <div class="formField" style="margin-top: 20px; margin-bottom: 40px; margin-left: 100px;">
                            <center>
                                (1) one $75 Callaway card per household &amp; golfer.<br>
                                If you have any questions or problems, please call 800.501.2257.<br>
                                <a href="http://www.gm.com/privacy/" target="_blank" style="color: WHITE;">GM Privacy</a></center>
                        </div>
                    </div>
                </div>
            </div>
            </div>
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