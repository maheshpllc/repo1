using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index_demoaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtActivationCode.Focus();
            Page.Title = "Confirm Callaway Card | Cadillac Dealer Registration";
        }
    }

    protected void imgSumbit_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("registration_demo.aspx");
    }

    protected void CreateCardSession(string strCardId, string strDealerCode)
    {
        CardInfo cardInformation = new CardInfo(strCardId, strDealerCode, 3);
        Session["SessionCardInfo"] = cardInformation;
    }
}