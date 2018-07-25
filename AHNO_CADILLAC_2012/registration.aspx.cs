using System;
using System.Web;
using System.Web.UI.WebControls;
using Cust_Reg;

public partial class registration : System.Web.UI.Page
{
    string strDealerCode = string.Empty, strDealerName = string.Empty, strRegion = string.Empty, strBacCode = string.Empty, strTournamentName = string.Empty, strTournamentDt = string.Empty, strContractId = string.Empty;
    int iTourId = 0, iDealerId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = " Cadillac Dealer Registration";
        rdnCtsSportsWagon.Focus();
        imgSubmit.Attributes.Add("onkeydown", "if(event.which || event.keyCode)" + "{if ((event.which == 9) || (event.keyCode == 9)) " + "{document.getElementById('" + txtFirstName.ClientID + "').focus();return false;}} else {return true}; ");

        /* This is checking Activation Code or Dealer Code Exits */
        if (Session["SessionCadillacCardInfo"] == null) Response.Redirect("index.aspx");
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
            try
            {
                if (Session["SessionCadillacCardInfo"] != null)
                {
                    CardInfo CustCardInfo = (CardInfo)Session["SessionCadillacCardInfo"];
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
                    CommonLogic.SelectTextBox(ref this.txtTourDate, string.Format("{0}", strTournamentDt).Trim()); // Tournament Date
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("index.aspx");
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

        Customer_Registration custReg_info = new Cust_Reg.Customer_Registration();

        #region IP Address

        custReg_info.IPAddress = CommonLogic.GetIP(); // Getting IP Address Information

        #endregion IP Address

        #region Vehicle Make Code

        custReg_info.VehicleMakeCode = "04"; // Vehicle Make Code for Cadillac

        #endregion Vehicle Make Code

        #region Program ID for Cadillac

        custReg_info.ProgramID = 2;

        #endregion Program ID for Cadillac

        #region phone type radio buttons W for work and H for home

        if (rdnWorkPhone.Checked == true) { custReg_info.PhoneType = "W"; }
        else if (rdnHomePhone.Checked == true) { custReg_info.PhoneType = "H"; }
        else { custReg_info.PhoneType = "N"; }

        #endregion phone type radio buttons W for work and H for home

        #region Scource Code

        if (hdnRegion.Value != "")
        {
            if (hdnRegion.Value == "NE")
            {
                custReg_info.SourceCode = "4KC1I8EQE";//North East Region
            }
            else if (hdnRegion.Value == "SE")
            {
                custReg_info.SourceCode = "3KC1I8EQG"; // South East Region
            }
            else if (hdnRegion.Value == "SC")
            {
                custReg_info.SourceCode = "2KC1I8EQF"; //South Central Region
            }
            else if (hdnRegion.Value == "NC")
            {
                custReg_info.SourceCode = "5KC1I8EQD";//North Central Region
            }
            else if (hdnRegion.Value == "W")
            {
                custReg_info.SourceCode = "1KC1I8EQH"; // Western Region
            }
            else
            {
                custReg_info.SourceCode = "CA11I8BUJ"; // Default Source Code
            }
        }
        else
        {
            custReg_info.SourceCode = "CA11I8BUJ"; // Default Source Code
        }

        #endregion Scource Code

        #region This is for information on the following Cadillac  Model(s)

        // Cadillac Models
        // if (chkELR.Checked == true) { custReg_info.QuestionCode += "00950,"; custReg_info.AnswerCode += "04" + "ELR,"; custReg_info.IntrestedModelInformation += " Cadillac - All New 2014 ELR,"; }
        if (chkCtsSportsWagon.Checked == true) { custReg_info.QuestionCode += "00950,"; custReg_info.AnswerCode += "04" + "CSW,"; custReg_info.IntrestedModelInformation += " Cadillac - CTS Sports Wagon,"; }
        if (chkSRX.Checked == true) { custReg_info.QuestionCode += "00950,"; custReg_info.AnswerCode += "04" + "SRX,"; custReg_info.IntrestedModelInformation += " Cadillac - SRX Crossover,"; }
        if (chkATS.Checked == true) { custReg_info.QuestionCode += "00950,"; custReg_info.AnswerCode += "04" + "ATS,"; custReg_info.IntrestedModelInformation += " Cadillac - All-New ATS,"; }
        if (chkCtsSedan.Checked == true) { custReg_info.QuestionCode += "00950,"; custReg_info.AnswerCode += "04" + "198,"; custReg_info.IntrestedModelInformation += " Cadillac - CTS,"; }
        if (chkEscalade.Checked == true) { custReg_info.QuestionCode += "00950,"; custReg_info.AnswerCode += "04" + "7ES,"; custReg_info.IntrestedModelInformation += " Cadillac - Escalade,"; }
        if (chkEscaladeHybrid.Checked == true) { custReg_info.QuestionCode += "00950,"; custReg_info.AnswerCode += "04" + "EHY,"; custReg_info.IntrestedModelInformation += " Cadillac - Escalade Hybrid,"; }
        if (chkEscaladeESV.Checked == true) { custReg_info.QuestionCode += "00950,"; custReg_info.AnswerCode += "04" + "ESV,"; custReg_info.IntrestedModelInformation += " Cadillac - Escalade ESV,"; }
        if (chkEscaladeEXT.Checked == true) { custReg_info.QuestionCode += "00950,"; custReg_info.AnswerCode += "04" + "810,"; custReg_info.IntrestedModelInformation += " Cadillac - Escalade EXT,"; }
        if (chkXLRRoadster.Checked == true) { custReg_info.QuestionCode += "00950,"; custReg_info.AnswerCode += "04" + "190,"; custReg_info.IntrestedModelInformation += " Cadillac - XLR Roadster,"; }
        if (chkXTS.Checked == true) { custReg_info.QuestionCode += "00950,"; custReg_info.AnswerCode += "04" + "XTS,"; custReg_info.IntrestedModelInformation += " Cadillac - All-New XTS,"; }
        if (chkSportsWagon.Checked == true) { custReg_info.QuestionCode += "00950,"; custReg_info.AnswerCode += "04" + "CWV,"; custReg_info.IntrestedModelInformation += " Cadillac - CTS-V Sports Wagon,"; }

        if (custReg_info.IntrestedModelInformation != "" && custReg_info.IntrestedModelInformation.IndexOf(",") > 0) { custReg_info.IntrestedModelInformation = custReg_info.IntrestedModelInformation.Substring(0, custReg_info.IntrestedModelInformation.Length - 1); }

        #endregion This is for information on the following Cadillac  Model(s)

        #region This is for Test Drive Information

        // Compulsory Test Drive Cadillac Models
        // if (rdnELR.Checked) { custReg_info.TestDriveVehicle = "Cadillac - All New 2014 ELR"; custReg_info.TestDriveVehicleMake = "04"; custReg_info.TestDriveVehicleModel = "ELR"; }
        if (rdnCtsSportsWagon.Checked) { custReg_info.TestDriveVehicle = "Cadillac - CTS Sports Wagon"; custReg_info.TestDriveVehicleMake = "04"; custReg_info.TestDriveVehicleModel = "CSW"; }
        if (rdnSRX.Checked) { custReg_info.TestDriveVehicle = "Cadillac - SRX Crossover"; custReg_info.TestDriveVehicleMake = "04"; custReg_info.TestDriveVehicleModel = "SRX"; }
        // if (rdnATS.Checked) { custReg_info.TestDriveVehicle = "Cadillac - ATS"; custReg_info.TestDriveVehicleMake = "04"; custReg_info.TestDriveVehicleModel = "ATS"; }
        if (rdnCtsSedan.Checked) { custReg_info.TestDriveVehicle = "Cadillac - CTS"; custReg_info.TestDriveVehicleMake = "04"; custReg_info.TestDriveVehicleModel = "198"; }
        if (rdnEscalade.Checked) { custReg_info.TestDriveVehicle = "Cadillac - Escalade"; custReg_info.TestDriveVehicleMake = "04"; custReg_info.TestDriveVehicleModel = "7ES"; }
        if (rdnEscaladeHybrid.Checked) { custReg_info.TestDriveVehicle = "Cadillac - Escalade Hybrid"; custReg_info.TestDriveVehicleMake = "04"; custReg_info.TestDriveVehicleModel = "EHY"; }
        if (rdnEscaladeESV.Checked) { custReg_info.TestDriveVehicle = "Cadillac - Escalade ESV"; custReg_info.TestDriveVehicleMake = "04"; custReg_info.TestDriveVehicleModel = "ESV"; }
        if (rdnEscaladeEXT.Checked) { custReg_info.TestDriveVehicle = "Cadillac - Escalade EXT"; custReg_info.TestDriveVehicleMake = "04"; custReg_info.TestDriveVehicleModel = "810"; }
        if (rdnXLRRoadster.Checked) { custReg_info.TestDriveVehicle = "Cadillac - XLR Roadster"; custReg_info.TestDriveVehicleMake = "04"; custReg_info.TestDriveVehicleModel = "190"; }
        if (rdnXTS.Checked) { custReg_info.TestDriveVehicle = "Cadillac - XTS"; custReg_info.TestDriveVehicleMake = "04"; custReg_info.TestDriveVehicleModel = "XTS"; }
        if (rdnSportsWagon.Checked) { custReg_info.TestDriveVehicle = "Cadillac - CTS-V Sports Wagon"; custReg_info.TestDriveVehicleMake = "04"; custReg_info.TestDriveVehicleModel = "CWV"; }

        #endregion This is for Test Drive Information

        #region Radio Button Information

        // Radio Buttons For Local Dealer Ship
        if (rdnContactYes.Checked == true) { custReg_info.ContactLocalDealer = "Y"; custReg_info.QuestionCode += "02764,"; custReg_info.AnswerCode += "SA00001020,"; }
        else if (rdnContactNo.Checked == true) { custReg_info.ContactLocalDealer = "N"; custReg_info.QuestionCode += "02764,"; custReg_info.AnswerCode += "SA00001019,"; }

        // Radio Button for Preferred Dealer
        // radio buttons for preferred dealer/retailer Y for yes and N for no
        if (rdnpreferredDealerYes.Checked == true)
        {
            custReg_info.PreferredDealer = "Y";
            custReg_info.QuestionCode += "CQ00000860,";
            custReg_info.AnswerCode += "CA00021656,";
        }
        else if (rdnpreferredDealerNo.Checked == true)
        {
            custReg_info.PreferredDealer = "N";
            custReg_info.QuestionCode += "CQ00000860,";
            custReg_info.AnswerCode += "CA00021657,";
        }
        else
        {
            custReg_info.PreferredDealer = "X";
        }

        // This is for Dealer Name
        if (txtpreferredDealerName.Text.Replace("'", "''").Trim() != "")
        {
            custReg_info.PreferredDealerName = txtpreferredDealerName.Text.Trim();
            //   StrQuestioncode += "01101,";
            //   StrAnswercode += txtDealerName.Text.Replace("'", "''").Trim() + ",";
        }

        // Radio Buttons For Interested Vehicle For
        if (rdnPersonalUse.Checked == true) { custReg_info.PurposeVehicleInterested = "P"; }
        else { custReg_info.PurposeVehicleInterested = "B"; }

        // Radio buttons for purchasing/leasing vehicle P for purchase or L for lease and U for Undecided
        if (rdnPurchasing.Checked == true) { custReg_info.PlanningInformation = "P"; custReg_info.QuestionCode += "01614,"; custReg_info.AnswerCode += "P,"; }
        else if (rdnLeasing.Checked == true) { custReg_info.PlanningInformation = "L"; custReg_info.QuestionCode += "01614,"; custReg_info.AnswerCode += "L,"; }
        else { custReg_info.PlanningInformation = "N"; }

        // Radio buttons for time period within
        if (rdnWithin01.Checked == true) { custReg_info.TimeFrame = "1 month or less"; custReg_info.QuestionCode += "01615,"; custReg_info.AnswerCode += "1,"; }
        else if (rdnWithin02.Checked == true) { custReg_info.TimeFrame = "1-3 Months"; custReg_info.QuestionCode += "01615,"; custReg_info.AnswerCode += "2,"; }
        else if (rdnWithin03.Checked == true) { custReg_info.TimeFrame = "4-6 Months"; custReg_info.QuestionCode += "01615,"; custReg_info.AnswerCode += "3,"; }
        else if (rdnWithin04.Checked == true) { custReg_info.TimeFrame = "7-12 months"; custReg_info.QuestionCode += "01615,"; custReg_info.AnswerCode += "4,"; }
        else if (rdnWithin05.Checked == true) { custReg_info.TimeFrame = " More than a year"; custReg_info.QuestionCode += "01615,"; custReg_info.AnswerCode += "5,"; }
        else { custReg_info.TimeFrame = ""; }

        #endregion Radio Button Information

        #region Customer Information

        custReg_info.FirstName = txtFirstName.Text.Trim();
        custReg_info.LastName = txtLastName.Text.Trim();
        custReg_info.Phone = txtPhoneNumber.Text.Trim();
        custReg_info.Address = txtAddress.Text.Trim();
        custReg_info.City = txtCity.Text.Trim();
        custReg_info.State = ddlState.SelectedValue.Trim();
        custReg_info.ZipCode = txtZipCode.Text.Trim();
        custReg_info.EmailAddress = txtEmail.Text.Trim();

        #endregion Customer Information

        #region Current House Hold Vechile Information

        //Current House Hold Vehicle 01
        if (ddlMake01.SelectedValue.Trim() != "0")
        {
            custReg_info.CurrentHouseHoldVehicleMake01 = ddlMake01.SelectedValue.Trim();

            if (txtOtherMake01.Text != "")
            {
                custReg_info.CurrentHouseHoldVehicleOtherMake01 = txtOtherMake01.Text;
            }

            if (txtOtherModel01.Text != "")
            {
                custReg_info.CurrentHouseHoldVehicleOtherModel01 = txtOtherModel01.Text;
            }
        }

        if (ddlModel01.SelectedValue.Trim() != "0")
        {
            custReg_info.CurrentHouseHoldVehicleModel01 = ddlModel01.SelectedValue.Trim();
        }

        if (ddlYear01.SelectedValue.Trim() != "0")
        {
            custReg_info.CurrentHouseHoldVehicleYear01 = ddlYear01.SelectedValue.Trim();
        }

        //Current House Hold Vehicle 02
        if (ddlMake02.SelectedValue.Trim() != "0")
        {
            custReg_info.CurrentHouseHoldVehicleMake02 = ddlMake02.SelectedValue.Trim();

            if (txtOtherMake02.Text != "")
            {
                custReg_info.CurrentHouseHoldVehicleOtherMake02 = txtOtherMake02.Text;
            }

            if (txtOtherModel02.Text != "")
            {
                custReg_info.CurrentHouseHoldVehicleOtherModel02 = txtOtherModel02.Text;
            }
        }

        if (ddlModel02.SelectedValue.Trim() != "0")
        {
            custReg_info.CurrentHouseHoldVehicleModel02 = ddlModel02.SelectedValue.Trim();
        }

        if (ddlYear02.SelectedValue.Trim() != "0")
        {
            custReg_info.CurrentHouseHoldVehicleYear02 = ddlYear02.SelectedValue.Trim();
        }

        #endregion Current House Hold Vechile Information

        #region Test Drive Dealer Information, Salesperson Information and Test Drive Information

        //Dealer Information
        custReg_info.DealerID = Convert.ToInt32(hdnDealerId.Value.Trim());
        custReg_info.DealerName = txtDealerName.Text.Trim();
        custReg_info.DealerEmail = txtDealerEmail.Text.Trim();
        // Salesperson Information
        custReg_info.SalespersonEmail = txtSalesEmailAddress.Text.Trim();
        custReg_info.SalespersonName = txtSalespersonName.Text.Trim();

        // Test Drive Information
        custReg_info.TestDriveDate = Convert.ToDateTime(txtTestDriveDate.Text.Trim());

        #endregion Test Drive Dealer Information, Salesperson Information and Test Drive Information

        #region Tournament Information

        custReg_info.TournamentID = Convert.ToInt32(hdnTournamentId.Value.Trim());
        custReg_info.TournamentDate = Convert.ToDateTime(txtTourDate.Text.Trim());
        custReg_info.CardNumber = hdnActivateId.Value.Trim();
        custReg_info.ContractID = hdnContractID.Value.Trim();
        custReg_info.DealerCode = hdnDealerCode.Value.Trim();
        custReg_info.BACCode = hdnBACode.Value.Trim();

        #endregion Tournament Information

        #region Question & Answer Code

        // This is for Eliminating Last "," from the Question Code and Answer Code
        if (custReg_info.QuestionCode != "" && custReg_info.QuestionCode.IndexOf(",") > 0) { custReg_info.QuestionCode = custReg_info.QuestionCode.Substring(0, custReg_info.QuestionCode.Length - 1); }
        if (custReg_info.AnswerCode != "" && custReg_info.AnswerCode.IndexOf(",") > 0) { custReg_info.AnswerCode = custReg_info.AnswerCode.Substring(0, custReg_info.AnswerCode.Length - 1); }

        #endregion Question & Answer Code

        #region Authentication

        if (chkiConfirm.Checked) { custReg_info.Autorized = "Y"; }

        #endregion Authentication

        Session["SessionCadillacCustomerInfo"] = custReg_info;

        Response.Redirect("Confirmation.aspx");
    }
}