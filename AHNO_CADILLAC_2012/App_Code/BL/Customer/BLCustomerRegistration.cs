using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Summary description for BLCustomerRegistration
/// </summary>
public class BLCustomerRegistration
{
    static string strResult = string.Empty;

    public BLCustomerRegistration()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region /********************************* Customer Registration Starts Here  ********************************/

    public static string CustomerRegistration(string strFname,
                                              string strLName,
                                              string strAddress,
                                              string strCity,
                                              string strState,
                                              string strZipCode,
                                              string strMailId,
                                              string strPhoneNumber,
                                              char cPhoneType,
                                              int iprgmId,
                                              string strCardNumber,
                                              int iTourId,
                                              DateTime strTourDate,
                                              string strContractId,
                                              char plan,
                                              string strModelInfo,
                                              char strLocalDealer,
                                              char strContactdealer,
                                              string strContactDealerName,
                                              string strTimeFrame,
                                              char strInterested,
                                              string strReplaceMakeCode1,
                                              string strReplaceOtherMakeCode1,
                                              string strReplaceModelCode1,
                                              string strReplaceOtherModelCode1,
                                              string strReplaeYear1,
                                              string strReplaceMakeCode2,
                                              string strReplaceOtherMakeCode2,
                                              string strReplaceModelCode2,
                                              string strReplaceOtherModelCode2,
                                              string strReplaeYear2,
                                              string strBacCode,
                                              int iDealerId,
                                              string strDealerCode,
                                              string strDealershipName,
                                              string strDealerEmail,
                                              string strSalesPerson,
                                              string strSalesPersonEmail,
                                              DateTime strTestDriveDt,
                                              string strTestDriveMake,
                                              string strTestDriveModel,
                                              string strTestDrive,
                                              string strSecondaryTestDriveMake,
                                              string strSecondaryTestDriveModel,
                                              string strSecondaryTestDrive,
                                              string strSourceCode,
                                              string strIPAdress,
                                              char iAuth,
                                              string StrQuestioncode,
                                              string StrAnswercode,
                                              ref string strCouponId
                                           )
    {
        try
        {
            DA.AHNODataContext context = new DA.AHNODataContext();
            string strCouponCode = string.Empty, strCouponPin = string.Empty;
            int iCoupon = 0;
            try
            {
                #region Reservation Table

                DA.TBL_REGISTRATION list = new DA.TBL_REGISTRATION();
                list.R_FIRST_NAME = strFname.Trim();
                list.R_LAST_NAME = strLName.Trim();
                list.R_ADDRESS = strAddress.Trim();
                list.R_CITY = strCity.Trim();
                list.R_STATE = strState.Trim();
                list.R_ZIPCODE = strZipCode.Trim();
                list.R_EMAIL = strMailId.Trim();
                list.R_PHONE = strPhoneNumber.Trim();
                list.R_PH_TYPE = cPhoneType;
                list.R_PROGRAM_ID = iprgmId;
                list.R_CARD_NUMBER = strCardNumber.Trim();
                list.R_TOUR_ID = iTourId;
                list.R_TOUR_DT = strTourDate;
                list.R_CONTRACT_ID = strContractId.Trim();
                list.R_PLANNING = plan;
                list.R_MODEL_INFORMATION = strModelInfo.Trim();
                list.R_LOCAL_DEALER = strLocalDealer;
                list.R_CONTACT_DEALER = strContactdealer;
                list.R_CONTACT_DEALER_NAME = strContactDealerName;
                list.R_TIME_FRAME = strTimeFrame.Trim();
                list.R_INTEREST_VECHILE = strInterested;
                list.R_CURR_HH_MAKE = strReplaceMakeCode1;
                list.R_CURR_HH_MAKE2 = strReplaceMakeCode2;
                list.R_CURR_HH_MODEL = strReplaceModelCode1;
                list.R_CURR_HH_MODEL2 = strReplaceModelCode2;
                list.R_CURR_HH_MAKE_OTHER = strReplaceOtherMakeCode1;
                list.R_CURR_HH_MAKE_OTHER2 = strReplaceOtherMakeCode2;
                list.R_CURR_HH_MODEL_OTHER = strReplaceOtherModelCode1;
                list.R_CURR_HH_MODEL_OTHER2 = strReplaceOtherModelCode2;
                list.R_CURR_HH_YEAR = strReplaeYear1;
                list.RR_CURR_HH_YEAR2 = strReplaeYear2;
                list.R_BAC_CODE = strBacCode.Trim();
                list.R_DEALER_ID = iDealerId;
                list.R_DEALER_CODE = strDealerCode.Trim();
                list.R_DEALER_NAME = strDealershipName.Trim();
                list.R_DEALER_EMAIL = strDealerEmail.Trim();
                list.R_SALESPERSON_NAME = strSalesPerson.Trim();
                list.R_SALESPERSON_EMAIL = strSalesPersonEmail.Trim();
                list.R_TEST_DRIVE_DT = strTestDriveDt;
                list.R_TEST_DRIVE_MAKE = strTestDriveMake.Trim();
                list.R_TEST_DRIVE_MODEL = strTestDriveModel.Trim();
                list.R_TEST_DRIVE = strTestDrive.Trim();
                list.R_SECONDARY_TEST_DRIVE_MAKE = strSecondaryTestDriveMake;
                list.R_SECONDARY_TEST_DRIVE_MODEL = strSecondaryTestDriveModel;
                list.R_SECONDARY_TEST_DRIVE = strSecondaryTestDrive;
                list.R_SOURCE_CODE = strSourceCode;
                list.R_IPADDRESS = strIPAdress;
                list.R_AUTHENTICATION = iAuth;
                list.R_STATUS = 'Y';
                list.R_CREATED_TS = System.DateTime.Now;
                context.TBL_REGISTRATIONs.InsertOnSubmit(list);
                context.SubmitChanges();

                #endregion Reservation Table

                if (list.R_ID > 0)
                {
                    #region Question Answers

                    // This is for Adding Question Code And Answer Code With Registered User Id
                    context.usp_Registration_Customer_QA(list.R_ID, iprgmId, StrQuestioncode, StrAnswercode);

                    #endregion Question Answers

                    #region Coupon Codes

                    // This is for Assigning Coupon Code an Coupon Pin Coupon Card Code Table.
                    AssignCouponCode(iprgmId, ref iCoupon, ref strCouponCode, ref strCouponPin);
                    strCouponId = strCouponCode; // This is for Assigning Coupon Code

                    #endregion Coupon Codes

                    #region Tournament Card Codes

                    // This is for Updating Card code Status To 'Assign' as 'A' for Tournament Card Code Table.
                    UpdatedCardCode(strCardNumber.Trim(), iTourId, iprgmId);

                    #endregion Tournament Card Codes

                    #region MailSending

                    strResult = "OK"; // Assigning Default Status Message.

                    // This is for Updating Mail Status and Coupon Id Assigned
                    UpdateMailStatus(Convert.ToInt32(list.R_ID.ToString()), 'P', iCoupon);

                    // This is for inserting mail sending Date.
                    context.usp_RegMalling(list.R_ID);

                    // Commented by Ravindra 0n 04/23/2012
                    // This is for Sending Mail from Exact Target Web Service
                    //strResult = Triggersend.CustomerCodeTriggeredEmail("info@emails.gmholeinone.com", strDealershipName.Trim(), strMailId.Trim(),
                    //                                     strFname.Trim() + " " + strLName.Trim(), list.R_ID.ToString(), strCouponCode, strCouponPin, strTestDrive, strSalesPerson.Trim());

                    #endregion MailSending

                    //if (strResult == "OK" || strResult == "ok")
                    //{
                    //    UpdateMailStatus(Convert.ToInt32(list.R_ID.ToString()), 'S', iCoupon);
                    //}

                    //else
                    //{
                    //    UpdateMailStatus(Convert.ToInt32(list.R_ID.ToString()), 'F', iCoupon);
                    //}
                }
            }
            catch (Exception ex)
            {
                strResult = "Error";
            }
        }
        catch (Exception ex)
        {
            strResult = "Error";
        }

        return strResult;
    }

    // This is for Updating and Assigning Coupon Code / Coupon Pin and Updating Redeem Date
    public static void AssignCouponCode(int iPrgmId, ref int iCouponId, ref string strCouponCode, ref string strCodePin)
    {
        try
        {
            DA.AHNODataContext context = new DA.AHNODataContext();
            List<DA.TBL_COUPON_CODE> CCResult = (from coupun in context.TBL_COUPON_CODEs.Where(l => l.CP_REDEEM_TS == null && l.CP_STATUS == 'Y' && l.CP_PROGRAM_ID == iPrgmId)
                                                 select coupun).OfType<DA.TBL_COUPON_CODE>().ToList<DA.TBL_COUPON_CODE>();
            if (CCResult.Count > 0)
            {
                var ccCode = CCResult.First();
                strCouponCode = ccCode.CP_CODE.ToString();
                strCodePin = ccCode.CP_PIN.ToString();
                iCouponId = ccCode.CP_ID;
                ccCode.CP_STATUS = 'A';
                ccCode.CP_REDEEM_TS = System.DateTime.Now;
                context.SubmitChanges();
            }
        }
        catch (Exception ex)
        {
        }
    }

    // This is for Updating Card code Status as Assigned
    public static void UpdatedCardCode(string strCardCode, int iTourId, int iPrgmId)
    {
        try
        {
            DA.AHNODataContext context = new DA.AHNODataContext();

            List<DA.TBL_TOURNAMENT_CARD_CODE> TournamentCardInfo
                   = (from cardInfo in context.TBL_TOURNAMENT_CARD_CODEs.Where(l => l.CT_CARD_CODE == strCardCode && l.CT_CARD_STATUS == 'Y' && l.CT_PROGRAM_ID == iPrgmId)
                      join tourInfo in context.TBL_TOURNAMENTs.Where(w => w.T_ID == iTourId) on cardInfo.CT_TOURNAMENT_ID equals tourInfo.T_ID
                      select cardInfo).OfType<DA.TBL_TOURNAMENT_CARD_CODE>().ToList<DA.TBL_TOURNAMENT_CARD_CODE>();

            if (TournamentCardInfo.Count > 0)
            {
                var cardInformation = TournamentCardInfo.First();
                cardInformation.CT_CARD_STATUS = 'A';
                context.SubmitChanges();
            }
        }
        catch (Exception ex)
        {
        }
    }

    // This is for Updating Mail Status as Assigned
    public static void UpdateMailStatus(int custRegId, char strStatus, int iCouponId)
    {
        try
        {
            DA.AHNODataContext context = new DA.AHNODataContext();
            List<DA.TBL_REGISTRATION> CustRegistedInfo
                   = (from RegInfo in context.TBL_REGISTRATIONs.Where(l => l.R_ID == custRegId)
                      select RegInfo).OfType<DA.TBL_REGISTRATION>().ToList<DA.TBL_REGISTRATION>();

            if (CustRegistedInfo.Count > 0)
            {
                var RegInformation = CustRegistedInfo.First();
                RegInformation.R_MAIL_STATUS = strStatus;
                RegInformation.R_COUPON_ID = iCouponId;
                context.SubmitChanges();
            }
        }
        catch (Exception ex)
        {
            strResult = "Error";
        }
    }

    #endregion /********************************* Customer Registration Starts Here  ********************************/
}