using System;
using System.Collections.Generic;
using System.Linq;

public partial class Confirmation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SessionCadillacCustomerInfo"] == null) { Response.Redirect("index.aspx"); }

        if (!IsPostBack)
        {
            if (Session["SessionCadillacCustomerInfo"] != null)
            {
                try
                {
                    DA.AHNODataContext context = new DA.AHNODataContext();
                    Cust_Reg.Customer_Registration cust_info = (Cust_Reg.Customer_Registration)Session["SessionCadillacCustomerInfo"];

                    #region Validation Customer while Registration

                    /**1# if same email and Contract Id exists in same year in reservation table.
                             2# if same Contract ID AND First Name and Last Name and different email in reservation table.
                             3# if same Address and city and state and zip code exits in reservation table
                            * */
                    string strErrMsg = BLValidate.ValidateCustomerInfo(cust_info.FirstName.Trim(), cust_info.LastName.Trim(), cust_info.ProgramID, cust_info.EmailAddress.Trim(), cust_info.Address.Trim(), cust_info.City.Trim(), cust_info.State.Trim(), cust_info.ZipCode.Trim(), cust_info.ContractID.Trim());

                    if (strErrMsg != "Valid")
                    {
                        ltrlMessage.Text = "<div align='center'>" +
                        "<p class='shrink-margin' style='padding-top:10px; '><h4 style='font:bold 18px Arial, Helvetica, sans-serif;'><span style='color:Red;'>ATTENTION:</span> The following name, address and email has been previously used. The Test Drive invitation is limited to one card per person.  Please see Test Drive Card for all applicable Rules. Questions?  Please call 877 382 8265.</h4></p></div>";
                        return;
                    }

                    /* if same email and Contract Id exists in reservation table. */
                    List<DA.TBL_REGISTRATION> RegInfo = (from RegInformation in context.TBL_REGISTRATIONs.Where(l => l.R_EMAIL == cust_info.EmailAddress.Trim()
                                            && l.R_CONTRACT_ID == cust_info.ContractID.Trim())
                                                         select RegInformation).OfType<DA.TBL_REGISTRATION>().ToList<DA.TBL_REGISTRATION>();

                    if (RegInfo.Count > 0)
                    {
                        var RegInformation = RegInfo.First();

                        ltrlMessage.Text = "<div align='center'>" +
                        "<p class='shrink-margin' style='padding-top:10px; '><h4 style='font:bold 18px Arial, Helvetica, sans-serif;'>This email was used to activate a card for this tournament on " + Convert.ToDateTime(RegInformation.R_CREATED_TS).ToShortDateString() + " by " + RegInformation.R_SALESPERSON_NAME.ToString() + " –  This card will be also activated, and may be reviewed for multiple activations. </h4></p></div>";
                    }

                    #endregion Validation Customer while Registration

                    #region Resestration Starts Here

                    if (!BLValidate.CheckingCardCodeDealerCode(cust_info.CardNumber.Trim(), cust_info.DealerCode.Trim(), cust_info.BACCode.Trim()))
                    {
                        string strCouponCode = string.Empty;
                        try
                        {
                            string Errmsg = BLCustomerRegistration.CustomerRegistration(
                                             cust_info.FirstName
                                            , cust_info.LastName
                                            , cust_info.Address
                                            , cust_info.City
                                            , cust_info.State
                                            , cust_info.ZipCode
                                            , cust_info.EmailAddress
                                            , cust_info.Phone
                                            , Convert.ToChar(cust_info.PhoneType)
                                            , cust_info.ProgramID
                                            , cust_info.CardNumber
                                            , cust_info.TournamentID
                                            , cust_info.TournamentDate
                                            , cust_info.ContractID
                                            , Convert.ToChar(cust_info.PlanningInformation)
                                            , cust_info.IntrestedModelInformation
                                            , Convert.ToChar(cust_info.ContactLocalDealer)
                                            , Convert.ToChar(cust_info.PreferredDealer)
                                            , cust_info.PreferredDealerName
                                            , cust_info.TimeFrame
                                            , Convert.ToChar(cust_info.PurposeVehicleInterested)
                                            , cust_info.CurrentHouseHoldVehicleMake01
                                            , cust_info.CurrentHouseHoldVehicleOtherMake01
                                            , cust_info.CurrentHouseHoldVehicleModel01
                                            , cust_info.CurrentHouseHoldVehicleOtherModel01
                                            , cust_info.CurrentHouseHoldVehicleYear01
                                            , cust_info.CurrentHouseHoldVehicleMake02
                                            , cust_info.CurrentHouseHoldVehicleOtherMake02
                                            , cust_info.CurrentHouseHoldVehicleModel02
                                            , cust_info.CurrentHouseHoldVehicleOtherModel02
                                            , cust_info.CurrentHouseHoldVehicleYear02
                                            , cust_info.BACCode
                                            , cust_info.DealerID
                                            , cust_info.DealerCode
                                            , cust_info.DealerName
                                            , cust_info.DealerEmail
                                            , cust_info.SalespersonName
                                            , cust_info.SalespersonEmail
                                            , cust_info.TestDriveDate
                                            , cust_info.TestDriveVehicleMake
                                            , cust_info.TestDriveVehicleModel
                                            , cust_info.TestDriveVehicle
                                            , cust_info.SecondaryTestDriveVehicleMake
                                            , cust_info.SecondaryTestDriveVehicleModel
                                            , cust_info.SecondaryTestDriveVehicle
                                            , cust_info.SourceCode
                                            , cust_info.IPAddress
                                            , Convert.ToChar(cust_info.Autorized)
                                            , cust_info.QuestionCode
                                            , cust_info.AnswerCode
                                            , ref strCouponCode
                                            );

                            if (Errmsg == "OK")
                            {
                                // Modified on 04/23/2012 by Ravindra.
                                //    ltrlMessage.Text += "<div align='center'>" +
                                //    "<p class='shrink-margin' style='padding-top:10px;'><h4 style='font:bold 24px Arial, Helvetica, sans-serif;'><a href='javascript:window.print();' style='color:#FFF;'>Please print this confirmation page and provide it to " + cust_info.FirstName.Trim() + " " + cust_info.LastName.Trim() + ".</a></h4><h4 style='font:bold 18px Arial, Helvetica, sans-serif;'>Thank you for completing the test drive information.<br /><br /> An email has been sent with your e-Coupon code to <a href='mailto:" + cust_info.EmailAddress.Trim() + "' style='color:#FFF;'>" + cust_info.EmailAddress.Trim() + "</a><br /> <br />Please check your spam folders if you did not receive the e-Coupon Code today. " +
                                //    "<br /><br />Please email us at <a href='mailto:CadillacGiftCards@ahno.net' style='color:#FFF;'>CadillacGiftCards@ahno.net</a> if you did not receive your e-Coupon Code." +
                                //    "<br /><br />If you have any questions or need further assistance, please contact a Cadillac Customer Service Representative at <br />877-248-4653 and refer to confirmation number " + cust_info.CardNumber.Trim() + ", which is on the back of your gift card.<br /><br />For questions related to shopping please visit <a href='http://CadillacExperience.com' target='_blank' style='color:#FFF;'>Shop.CallawayGolf.com</a>" +
                                //    "</h4>" +
                                //    "</p> <br /><br /> <div align='right'><a href='javascript:window.print();' style='color:#FFF;'><br /><img src='images/portal_icon-print.png' alt='Print' border='0' /></a></div>" +
                                //    "</div>";

                                ltrlMessage.Text += "<div align='center'>" +
                             "<p class='shrink-margin' style='padding-top:10px;'><h4 style='font:bold 24px Arial, Helvetica, sans-serif;'><a href='javascript:window.print();'>Please print this confirmation page and provide it to " + cust_info.FirstName.Trim() + " " + cust_info.LastName.Trim() + ".</a></h4><h4 style='font:bold 18px Arial, Helvetica, sans-serif;'>Thank you for completing the test drive information.<br /><br />An email will be sent with your e-Coupon code to <a href='mailto:" + cust_info.EmailAddress.Trim() + "'>" + cust_info.EmailAddress.Trim() + "</a> within one (1) business day.<br /> <br />Please check your spam folder(s) if you do not receive the e-Coupon code after 24 business hours. " +
                             "<br /><br />If you do not receive your e-Coupon code, please email us at <a href='mailto:CadillacGiftCards@ahno.net'>CadillacGiftCards@ahno.net</a>." +
                             "<br /><br />If you have any questions or need further assistance, please contact a Cadillac Customer Service Representative at <br />877-248-4653 and refer to confirmation number " + cust_info.CardNumber.Trim() + ", which is on the back of your gift card.<br /><br />For questions related to shopping please visit <a href='http://CadillacExperience.com/Cadillac.aspx?cid=" + strCouponCode + "' target='_blank'>Shop.CallawayGolf.com</a>." +
                             "</h4>" +
                             "</p> <br /><br /> <div align='right' id='printicon'><a href='javascript:window.print();'><br /><img src='images/portal_icon-print.png' alt='Print' border='0' /></a></div>" +
                             "</div>";

                                Session["SessionCadillacCustomerInfo"] = null;
                                Session["SessionCadillacCardInfo"] = null;
                                return;
                            }
                            else
                            {
                                ltrlMessage.Text = "We’re sorry we are unable to submit the form. (1) one $75 Callaway Card per household & Golfer. Please call 877-382-8265 with questions.";
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Redirect("Registration.aspx");
                        }
                    }
                    else
                    {
                        ltrlMessage.Text = "We’re sorry we are unable to submit the form. 8 -DIGIT CARD CODE already utilized. (1) one $75 Callaway Card per household & Golfer. Please call 877-382-8265 with questions.";
                    }

                    #endregion Resestration Starts Here
                }
                catch (Exception ex)
                {
                    Response.Redirect("Registration.aspx");
                }
            }
            else
            {
                Response.Redirect("Registration.aspx");
            }
        }
    }
}