using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.txtActivationCode.Focus();
            Page.Title = "Confirm Callaway Card | Cadillac Dealer Registration";
            div01.Style.Add("display", "block");
            div02.Style.Add("display", "block");
            div03.Style.Add("display", "block");
            div04.Style.Add("display", "block");
            div05.Style.Add("display", "block");
            div06.Style.Add("display", "block");
            div07.Style.Add("display", "none");
        }
    }

    protected void imgSumbit_Click(object sender, ImageClickEventArgs e)
    {
        if (!string.IsNullOrEmpty(txtActivationCode.Text.Trim()) && !string.IsNullOrEmpty(txtDealerCode.Text.Trim()) && txtActivationCode.Text.Trim() != "" && txtDealerCode.Text.Trim() != "")
        {
            if (CheckingContractId(txtActivationCode.Text.Trim()))
            {
                string strErrMsg = BLValidate.ValidateCustomerInfo(this.txtActivationCode.Text.Trim(), 2, this.txtDealerCode.Text.Trim());
                if (strErrMsg != "Valid")
                {
                    ltrlerror.Visible = true;
                    ltrlerror.Text = strErrMsg;
                    this.txtActivationCode.Focus();
                }
                else
                {
                    if (txtActivationCode.Text != string.Empty && txtDealerCode.Text != string.Empty && !string.IsNullOrEmpty(txtActivationCode.Text) && !string.IsNullOrEmpty(txtDealerCode.Text))
                    {
                        CreateCardSession(this.txtActivationCode.Text.Trim(), this.txtDealerCode.Text.Trim());
                        Response.Redirect("registration.aspx");
                    }
                    else
                    {
                        this.txtActivationCode.Focus();
                        Response.Redirect("index.aspx");
                    }
                }
            }
            else
            {
                div01.Style.Add("display", "none");
                div02.Style.Add("display", "none");
                div03.Style.Add("display", "none");
                div04.Style.Add("display", "none");
                div05.Style.Add("display", "none");
                div06.Style.Add("display", "none");
                div07.Style.Add("display", "block");
            }
        }
        else
        {
            this.txtActivationCode.Focus();
            Response.Redirect("index.aspx");
        }
    }

    protected void CreateCardSession(string strCardId, string strDealerCode)
    {
        CardInfo cardInformation = new CardInfo(strCardId, strDealerCode, 2);
        Session["SessionCadillacCardInfo"] = cardInformation;
    }

    public static bool CheckingContractId(string strActivationCode)
    {
        try
        {
            string[] ContractId = { "513508G", "513980G" };
            DA.AHNODataContext context = new DA.AHNODataContext();
            List<DA.TBL_TOURNAMENT> TourInfo = (from TInfo in context.TBL_TOURNAMENTs
                                                where ContractId.Contains(TInfo.T_CONTRACT_ID)
                                                join CInfo in context.TBL_TOURNAMENT_CARD_CODEs.Where(w => w.CT_CARD_CODE == strActivationCode) on TInfo.T_ID equals CInfo.CT_TOURNAMENT_ID
                                                select TInfo).OfType<DA.TBL_TOURNAMENT>().ToList<DA.TBL_TOURNAMENT>();
            if (TourInfo.Count > 0)
            {
                var Information = TourInfo.First();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
        }

        return true;
    }
}