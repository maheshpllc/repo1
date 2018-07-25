using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class registration_demo : System.Web.UI.Page
{
    string strDealerCode = string.Empty, strDealerName = string.Empty, strRegion = string.Empty, strBacCode = string.Empty, strTournamentName = string.Empty, strTournamentDt = string.Empty, strContractId = string.Empty;
    int iTourId = 0, iDealerId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = " Cadillac Dealer Registration";
        rdnCtsSportsWagon.Focus();
        imgSubmit.Attributes.Add("onkeydown", "if(event.which || event.keyCode)" + "{if ((event.which == 9) || (event.keyCode == 9)) " + "{document.getElementById('" + txtFirstName.ClientID + "').focus();return false;}} else {return true}; ");

        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        if (!IsPostBack)
        {
            txtTestDriveDate.Text = System.DateTime.Now.ToShortDateString();
            CommonLogic.BindState(ref ddlState);            // This is for Binding State Drop Down
            CommonLogic.BindVMakeReplace(ref ddlMake01);     // This is for Binding Replace Vehicle Make 01
            CommonLogic.BindVMakeReplace(ref ddlMake02);    // This is for Binding Replace Vehicle Make 02

            // This is for Binding Replace Year Drop Down
            for (int i = 1970; i <= DateTime.Now.Year; i++) { ddlYear01.Items.Add(i.ToString()); ddlYear02.Items.Add(i.ToString()); }

            ddlYear01.Items.Insert(0, new ListItem("Select Year", "0"));
            ddlYear02.Items.Insert(0, new ListItem("Select Year", "0"));
            ddlModel01.Items.Insert(0, new ListItem("Select Vehicle Model", "0"));
            ddlModel02.Items.Insert(0, new ListItem("Select Vehicle Model", "0"));

            if (Session["SessionCardInfo"] != null)
            {
                CardInfo CustCardInfo = (CardInfo)Session["SessionCardInfo"];
                // This is for Getting Dealer Information Dealer Code and BAC Code
                CommonLogic.BindDealerInfomation(string.Format(" {0}", CustCardInfo.DealerCode), ref strDealerCode, ref strBacCode, ref strDealerName, ref iDealerId);
                // This is for Getting Tournament Information
                CommonLogic.BindTournamentInformation(string.Format(" {0}", CustCardInfo.CardNumber), ref strTournamentName, ref strTournamentDt, ref iTourId, ref strContractId, ref strRegion);

                hdnDealerId.Value = iDealerId.ToString();                // Assigning Dealer ID
                hdnActivateId.Value = CustCardInfo.CardNumber;          // Assigning Card Number
                hdnBACode.Value = strBacCode;                           // Assigning BAC Code
                hdnContractID.Value = strContractId;                    // Assigning Contract ID
                hdnDealerCode.Value = strDealerCode;                    // Assigning Dealer Code
                hdnTournamentId.Value = iTourId.ToString();             // Assigning Tournament ID
                hdnRegion.Value = strRegion.ToString();                 // Assigning Region

                CommonLogic.SelectTextBox(ref this.txtDealerName, string.Format("{0}", strDealerName).Trim()); // Dealer Name
                CommonLogic.SelectTextBox(ref this.txtTournamentName, string.Format("{0}", strTournamentName).Trim()); // Tournament Name
                this.txtTourDate.Text = Convert.ToDateTime(strTournamentDt).ToShortDateString();
                // CommonLogic.SelectTextBox(ref this.txtTourDate, string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(string.Format("{0}", strTournamentDt).Trim()))); // Tournament Date
            }
        }
    }

    // This Block is for Replace Model 01
    protected void ddlMake01_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMake01.SelectedItem.Value == "OTH")
        {
            divReplaceModelOther01.Style.Add("display", "block");
            divReplaceModel01.Style.Add("display", "none");
            ddlYear01.Focus();
        }
        else
        {
            System.Threading.Thread.Sleep(10);
            ddlModel01.Items.Clear();
            CommonLogic.BindVModelReplace(ddlMake01.SelectedItem.Value, ref ddlModel01);
            ddlModel01.Items.Insert(0, new ListItem("Select Vehicle Model", "0"));
            ddlModel01.Focus();
            divReplaceModelOther01.Style.Add("display", "none");
            divReplaceModel01.Style.Add("display", "block");
        }
    }

    // This Block is for Replace Model 02
    protected void ddlMake02_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMake02.SelectedItem.Value == "OTH")
        {
            divReplaceOtherModel02.Style.Add("display", "block");
            divReplaceModel02.Style.Add("display", "none");
            ddlYear02.Focus();
        }
        else
        {
            System.Threading.Thread.Sleep(10);
            ddlModel02.Items.Clear();
            CommonLogic.BindVModelReplace(ddlMake02.SelectedItem.Value, ref ddlModel02);
            ddlModel02.Items.Insert(0, new ListItem("Select Vehicle Model", "0"));
            ddlModel02.Focus();
            divReplaceOtherModel02.Style.Add("display", "none");
            divReplaceModel02.Style.Add("display", "block");
        }
    }

    protected void imgSubmit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        System.Threading.Thread.Sleep(50); // This is for Sleep Time for Page Loading

        Response.Redirect("Confirmation_demo.aspx");
    }
}