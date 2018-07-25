using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Confirmation_demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["SessionCustomerInfo"] == null) { Response.Redirect("index.aspx"); }

        if (!IsPostBack)
        {
            ltrlMessage.Text += "<div align='center'>" +
                                                   "<p class='shrink-margin' style='color: white; padding-top:10px;'><h4 style='font:bold 24px Arial, Helvetica, sans-serif;'><a href='javascript:window.print();'>Please print this confirmation page and provide it to  XXXXXXXXX NAME.</a></h4><h4 style='font:bold 18px Arial, Helvetica, sans-serif;'>Thank you for completing the test drive information.<br /><br /> An email has been sent with your e-Coupon code to <a href='#'>XXXX EMAIL ADDRESS</a><br /> <br />Please check your spam folders if you did not receive the e-Coupon Code today. " +
                                                   "<br /><br />Please email us at <a href='mailto:CadillacGiftCards@ahno.net'>CadillacGiftCards@ahno.net</a> if you did not receive your e-Coupon Code." +
                                                   "<br /><br />If you have any questions or need further assistance, please contact a BUICK GMC Customer Service Representative at <br />877-248-4653 and refer to confirmation number XXXXX CONFIRMATION NUMBER, which is on the back of your gift card.<br /><br />For questions related to shopping please visit <a href='http://CadillacExperience.com' target='_blank'>Shop.CallawayGolf.com</a>" +
                                                   "</h4>" +
                                                   "</p> <br /><br /> <div align='right'><a href='javascript:window.print();'><br /><img src='images/portal_icon-print.png' alt='Print' border='0' /></a></div>" +
                                                   "</div>";
        }
    }
}