using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_Mail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strResult = string.Empty;
        if (txtCardNumber.Text != "")
        {
            try
            {
                DA.AHNODataContext context = new DA.AHNODataContext();

                List<DA.TBL_REGISTRATION> CustomerRegInfo
                       = (from custInfo in context.TBL_REGISTRATIONs.Where(l => l.R_CARD_NUMBER == txtCardNumber.Text)
                          join couponInfo in context.TBL_COUPON_CODEs on custInfo.R_COUPON_ID equals couponInfo.CP_ID
                          select custInfo).OfType<DA.TBL_REGISTRATION>().ToList<DA.TBL_REGISTRATION>();

                if (CustomerRegInfo.Count > 0)
                {
                    var regInformation = CustomerRegInfo.First();

                    List<DA.TBL_COUPON_CODE> CouponInfo
                      = (from CodeInfo in context.TBL_COUPON_CODEs.Where(l => l.CP_ID == regInformation.R_COUPON_ID)
                         select CodeInfo).OfType<DA.TBL_COUPON_CODE>().ToList<DA.TBL_COUPON_CODE>();

                    if (CouponInfo.Count > 0)
                    {
                        var CodeInformation = CouponInfo.First();

                        #region MailSending

                        // This is for Sending Mail from Exact Target Web Service
                        strResult = Triggersend.CustomerCodeTriggeredEmail("emails@emails.ahno.net", regInformation.R_DEALER_NAME, "ravindrak@pllcsoftwaresolutions.com",
                                                            regInformation.R_FIRST_NAME.Trim() + " " + regInformation.R_LAST_NAME.Trim(), regInformation.R_ID.ToString(), CodeInformation.CP_CODE, CodeInformation.CP_PIN, regInformation.R_TEST_DRIVE, regInformation.R_SALESPERSON_NAME.Trim());

                        #endregion MailSending

                        if (strResult == "OK" || strResult == "ok")
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Mail Sent Successfully";
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Unable to Send Mail";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}