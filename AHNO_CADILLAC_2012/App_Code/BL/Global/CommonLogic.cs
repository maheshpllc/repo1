using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

/// <summary>
/// Description:This class contains all common using in this project
/// Created : Ravindra
/// Date : 09/28/2009
/// Modification:
///
///
/// </summary>
public class CommonLogic
{
    public static string XMLFilePath = ConfigurationManager.AppSettings["XmlPath"];
    public static string strErr = "";

    public CommonLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // This is for checking Integer or Not
    public static bool IsInteger(string str)
    {
        try
        {
            Convert.ToInt32(str);
        }
        catch
        {
            return false;
        }

        return true;
    }

    // This is for Assigning Text Box Value
    public static void SelectTextBox(ref TextBox txt, string value)
    {
        if (value != null) txt.Text = value.Trim();
    }

    // This is for Assigning Dropdown list Value
    public static void SelectDropDown(ref DropDownList ddl, string value)
    {
        if (value != null)
            if (ddl.Items.FindByValue(value.Trim()) != null)
                ddl.SelectedValue = value.Trim();
    }

    // This is for Assigning Radio Button Value
    public static void SelectRadioBox(ref RadioButtonList rbt, string value)
    {
        if (value != null)
            if (rbt.Items.FindByValue(value.Trim()) != null)
                rbt.SelectedValue = value.Trim();
    }

    // This is for Assigning Check Box Value
    public static void SelectCheckBox(ref CheckBoxList chk, string value)
    {
        if (value != null)
        {
            foreach (string str in value.Trim().Split(new char[] { ',' }))
            {
                ListItem liItem = chk.Items.FindByValue(str);
                if (liItem != null) liItem.Selected = true;
            }
        }
    }

    public static string CreateDataRow(string[] arrvalues)
    {
        string strRow = "";

        if (arrvalues != null)
        {
            for (int i = 0; i < arrvalues.Length; i++)
            {
                strRow += ((strRow != "") ? "," : "") + arrvalues[i];
            }
        }

        // return strRow.Split(new char[] { ',' });
        return strRow;
    }

    public static string GetCheckBoxSelectedList(CheckBoxList chk)
    {
        StringBuilder sbValues = new StringBuilder("");
        foreach (ListItem li in chk.Items)
        {
            if (li.Selected == true)
            {
                if (sbValues.Length != 0) sbValues = sbValues.Append(",");
                sbValues = sbValues.Append(li.Value);
            }
        }
        return sbValues.ToString();
    }

    public static string CheckBoxListItems(CheckBoxList chk, bool selectedOnly)
    {
        string Returnstring = "";
        foreach (ListItem item in chk.Items)
        {
            if (!selectedOnly)
            {
                if (item.Selected)
                {
                    Returnstring += (Returnstring != "") ? "," : "";
                    Returnstring += item.Value;
                }
            }
            else
            {
                Returnstring += (Returnstring != "") ? "," : "";
                Returnstring += item.Value;
            }
        }

        return Returnstring;
    }

    public static DataTable ConvertToDataTable<T>(IEnumerable<T> queryResult)
    {
        DataTable dtReturn = new DataTable("Result");

        PropertyInfo[] oProps = null;

        if (queryResult == null)
        {
            return dtReturn;
        }

        foreach (T rec in queryResult)
        {
            if (oProps == null)
            {
                oProps = ((Type)rec.GetType()).GetProperties();

                foreach (PropertyInfo pi in oProps)
                {
                    Type colType = pi.PropertyType;

                    if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
                        colType = colType.GetGenericArguments()[0];
                    }

                    dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                }
            }

            DataRow dr = dtReturn.NewRow();

            foreach (PropertyInfo pi in oProps)
            {
                dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
            }

            dtReturn.Rows.Add(dr);
        }

        return dtReturn;
    }

    // This is for throwing exception for Data Table
    public static DataTable CreateExceptionDataTable(string exceptionValue)
    {
        DataTable excp_dt = new DataTable("EXCEPTIONS");
        excp_dt.Columns.Add(new DataColumn("EXCEPTION REASON"));
        excp_dt.Rows.Add(exceptionValue);
        return excp_dt;
    }

    // This is for Loading Xml Data
    public static XDocument LoadXMLFile(string _XMLFilePath)
    {
        return XDocument.Load(_XMLFilePath);
    }

    // This is for Binding Xml Details Based on Path
    public static DataTable XmlDetails(string strPath)
    {
        strPath = XMLFilePath + strPath;
        DataTable dtXml = new DataTable();
        try
        {
            DataSet myDs = new DataSet();
            myDs.ReadXml(strPath);
            dtXml = myDs.Tables[0];
        }
        catch (Exception ex)
        {
            return CreateExceptionDataTable(ex.ToString());
        }
        return dtXml;
    }

    //To get Data Table Bases on Query
    public static DataTable ToDataTable(System.Data.Linq.DataContext ctx, object query)
    {
        if (query == null)
        {
            throw new ArgumentNullException("query");
        }
        IDbCommand cmd = ctx.GetCommand(query as IQueryable);
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = (SqlCommand)cmd;
        DataTable dt = new DataTable();

        try
        {
            cmd.Connection.Open();
            adapter.FillSchema(dt, SchemaType.Source);
            adapter.Fill(dt);
        }
        finally
        {
            cmd.Connection.Close();
        }
        return dt;
    }

    //To show hour number as 01..09
    private static string DualMode(int number)
    {
        return (number < 10) ? "0" + number.ToString() : number.ToString();
    }

    //To show Time Duration
    public static void BindTimeDuration(DropDownList ddlTimeDuration)
    {
        ddlTimeDuration.Items.Add(new ListItem("Select", "0"));
        ddlTimeDuration.SelectedValue = "0";

        int[] arrIntervals = { 15, 30, 45, 0 };

        for (int Hour = 0; Hour < 24; Hour++)
        {
            string Hourin12Format = (Hour >= 12) ? "pm" : "am";

            for (int Index = 0; Index < arrIntervals.Length; Index++)
            {
                string ToPart = "", FromPart = "";

                string ItemValue = Hour.ToString();
                ToPart = DualMode((Hour > 12) ? Hour - 12 : Hour);

                //  FromPart = ((arrIntervals[Index] == 0) ? DualMode((Hour + 1 ==24 ) ? 0: Hour+1 ) : DualMode(Hour)) + ":" + DualMode(arrIntervals[Index]);

                if (Index != 0)
                {
                    ToPart += ":" + DualMode(arrIntervals[Index - 1]);
                    ItemValue += ":" + DualMode(arrIntervals[Index - 1]);
                }
                else
                {
                    ItemValue += ":00";
                    ToPart += ":00";
                }

                // string ItemText =  ToPart + "-" + FromPart + " " + Hourin12Format;
                string ItemText = ToPart + " " + Hourin12Format;

                ListItem liItem = new ListItem(ItemText, ItemValue);
                ddlTimeDuration.Items.Add(liItem);
            }
        }
    }

    // To show based on the Range Values
    public static void BindRange(DropDownList ddl, int min, int max)
    {
        ddl.SelectedValue = "0";
        while ((min <= max))
        {
            ListItem litem = new ListItem();
            litem.Value = Convert.ToString(min);
            litem.Text = Convert.ToString(min);
            ddl.Items.Add(litem);
            min += 1;
        }
    }

    // To show Months
    public static void BindMonths(DropDownList ddlMonths)
    {
        ddlMonths.Items.Add(new ListItem("Month", "0"));
        ddlMonths.Items.Add(new ListItem("January", "1"));
        ddlMonths.Items.Add(new ListItem("February", "2"));
        ddlMonths.Items.Add(new ListItem("March", "3"));
        ddlMonths.Items.Add(new ListItem("April", "4"));
        ddlMonths.Items.Add(new ListItem("May", "5"));
        ddlMonths.Items.Add(new ListItem("June", "6"));
        ddlMonths.Items.Add(new ListItem("July", "7"));
        ddlMonths.Items.Add(new ListItem("August", "8"));
        ddlMonths.Items.Add(new ListItem("September", "9"));
        ddlMonths.Items.Add(new ListItem("October", "10"));
        ddlMonths.Items.Add(new ListItem("November", "11"));
        ddlMonths.Items.Add(new ListItem("December", "12"));
        ddlMonths.SelectedValue = "0";
    }

    //To show Time Duration on 15 minutes Interval
    public static void BindDuration(DropDownList ddlDuration)
    {
        int i;
        int j = 1;
        ddlDuration.Items.Add(new ListItem("Select", "0"));
        ddlDuration.SelectedValue = "0";

        for (i = 0; i <= 9; i++)
        {
            ListItem item1 = new ListItem();
            ListItem item2 = new ListItem();
            item1.Text = i.ToString() + " hr" + " : 30 min";
            item1.Value = i.ToString() + " hr" + " : 30 min";
            ddlDuration.Items.Add(item1);

            if (j <= 9)
            {
                item2.Text = j.ToString() + " hr" + " : 00 min";
                item2.Value = j.ToString() + " hr" + " : 00 min";
                ddlDuration.Items.Add(item2);
                j++;
            }
        }
    }

    // This Block is for Displaying Error Messages Based on Error Message
    public static string DisplayMessage(string strTitle, string strErrMsg, char action)
    {
        string strAction = "";
        if (strErrMsg == "1")
        {
            if (action == 'A') { strAction = " Added"; } else if (action == 'U') { strAction = " Updated"; } else { strAction = " Deleted"; }
            strErr = strTitle + strAction + " Successfully";
        }
        else if (strErrMsg == "0")
        {
            if (action == 'A') { strAction = " Add"; } else if (action == 'U') { strAction = " Update"; } else { strAction = " Delete"; }
            strErr = "Unable to " + strAction + strTitle;
        }
        else
        {
            strErr = strTitle + "Already Exits or Unable to process your request";
        }
        return strErr;
    }

    // This is for Retrieve Data Table from Store Procedure with string Parameter
    public static DataTable RetriveSpData(string strProcedurerName, int identifier, string identiferName, string strSearchString)
    {
        DataTable dtReport = new DataTable();
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        try
        {
            con = ConnectionString();
            string sp_name = "";
            SqlParameter Param1, Param2;
            sp_name = strProcedurerName;

            cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            Param1 = new SqlParameter(identiferName, SqlDbType.Int);
            Param1.Value = identifier;
            cmd.Parameters.Add(Param1);

            Param2 = new SqlParameter("@expression", SqlDbType.VarChar, 2000);
            Param2.Value = strSearchString;
            cmd.Parameters.Add(Param2);

            da = new SqlDataAdapter(cmd);
            da.Fill(dtReport);
        }
        catch
        {
        }
        finally
        {
            da.Dispose();
            cmd.Dispose();
            con.Close();
            con = null;
        }
        return dtReport;
    }

    public static SqlConnection ConnectionString()
    {
        return new SqlConnection(ConfigurationManager.ConnectionStrings["AHNO_BGC_2012ConnectionString"].ConnectionString);
    }

    public static string uploadImage(string sourcePath, string destinationPath, string Imagefilename, int Destwidth)
    {
        //String Imagefilename = null;
        System.Drawing.Image FullSizeImg;
        int Imagewidth, ImageHeight;
        System.Drawing.Image SourceImage = System.Drawing.Image.FromFile(sourcePath + Imagefilename);

        //--- Add on the appropriate directory ---
        string imageUrl = sourcePath + Imagefilename;

        FullSizeImg = System.Drawing.Image.FromFile(imageUrl);

        //--- Do we need to create a thumbnail? ---|
        //Response.ContentType = "image/gif";
        System.Drawing.Image.GetThumbnailImageAbort dummyCallBack;
        System.Drawing.Image thumbNailImg;

        dummyCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
        //----For Image Height----

        double Percent;

        if (FullSizeImg.Width > Destwidth)
        {
            Percent = Destwidth / (double)FullSizeImg.Width;
            Imagewidth = Convert.ToInt32(FullSizeImg.Width * Percent);
            ImageHeight = Convert.ToInt32(FullSizeImg.Height * Percent);
        }
        else
        {
            Imagewidth = FullSizeImg.Width;
            ImageHeight = FullSizeImg.Height;
        }

        Graphics thumbNailImg1;

        //----Saving the Image with High Quality-------
        thumbNailImg = FullSizeImg.GetThumbnailImage(Imagewidth, ImageHeight, dummyCallBack, IntPtr.Zero);
        thumbNailImg1 = Graphics.FromImage(thumbNailImg);
        thumbNailImg1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        thumbNailImg1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        thumbNailImg1.DrawImage(SourceImage, 0, 0, thumbNailImg.Width, thumbNailImg.Height);
        thumbNailImg.Save(destinationPath + Imagefilename, System.Drawing.Imaging.ImageFormat.Jpeg);

        //--- Clean up / Dispose ---|
        thumbNailImg.Dispose();
        FullSizeImg.Dispose();
        SourceImage.Dispose();
        File.Delete(sourcePath + Imagefilename);
        return Imagefilename;
    }

    public static bool ThumbnailCallback()
    {
        return false;
    }

    public static string GetIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }

    // This Block is for Binding State Drop Down List
    public static void BindState(ref DropDownList ddlState)
    {
        DA.AHNODataContext Context = new DA.AHNODataContext();

        var Query = Context.States.OrderBy(o => o.StateDescription)
                   .Select(s => new { s.StateDescription, s.StateCode }).Distinct();

        ddlState.DataTextField = "StateDescription";
        ddlState.DataValueField = "StateCode";
        ddlState.DataSource = Query;
        ddlState.DataBind();
        ddlState.Items.Insert(0, new System.Web.UI.WebControls.ListItem(" Select State ", "0"));
    }

    // This Block is for Binding Vehicle Make Drop Down List
    public static void BindVMakeReplace(ref DropDownList ddl)
    {
        ddl.Items.Clear();
        DA.AHNODataContext Context = new DA.AHNODataContext();

        char[] GType = { 'F', 'C', 'T' };
        var result = (from make in Context.VehicleMakes
                      where make.Status == 'Y'
                      select new { make.MakeCode, make.MakeDescription }).Distinct().OrderBy(o => o.MakeDescription);
        ddl.DataSource = result;
        ddl.DataTextField = "MakeDescription";
        ddl.DataValueField = "MakeCode";
        ddl.DataBind();
        ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem(" Select Vehicle Make ", "0"));
        ddl.Items.Add(new ListItem("Other", "OTH"));
    }

    // This Block is for Binding Vehicle Model Drop Down List Based on Make Code
    public static void BindVModelReplace(string makeCode, ref DropDownList ddl)
    {
        ddl.Items.Clear();
        DA.AHNODataContext Context = new DA.AHNODataContext();
        var result = (from model in Context.VehicleModels
                      orderby model.ModelDescription
                      where model.MakeCode == makeCode && model.Status == 'Y'
                         && model.ModelCode != null
                         && model.ModelType != 'G' && model.ModelType != null
                      select new { model.ModelDescription, model.ModelCode }).Distinct().OrderBy(o => o.ModelDescription); ;
        ddl.DataSource = result;
        ddl.DataTextField = "ModelDescription";
        ddl.DataValueField = "ModelCode";
        ddl.DataBind();
    }

    // This is for Binding Dealer Information Based on Dealer Code.
    public static void BindDealerInfomation(string strDealerCode, ref string strDCode, ref string strBacCode, ref string strDealerName, ref int iDealerID)
    {
        try
        {
            DA.AHNODataContext context = new DA.AHNODataContext();
            List<DA.TBL_DEALER_INFORMATION> DealerInformation =
                   (from Dealer in context.TBL_DEALER_INFORMATIONs.Where(l => (l.D_CODE == strDealerCode.Trim() || l.D_BAC == strDealerCode.Trim()) && l.D_STATUS == 'Y')
                    select Dealer).OfType<DA.TBL_DEALER_INFORMATION>().ToList<DA.TBL_DEALER_INFORMATION>();

            if (DealerInformation.Count > 0)
            {
                var Information = DealerInformation.First();
                if (!string.IsNullOrEmpty(Information.D_CODE) && (Convert.ToString(Information.D_CODE).Trim() != ""))
                {
                    strDCode = string.Format("{0}", Information.D_CODE).Trim();
                }
                if (!string.IsNullOrEmpty(Information.D_BAC) && (Convert.ToString(Information.D_BAC).Trim() != ""))
                {
                    strBacCode = string.Format("{0}", Information.D_BAC).Trim();
                }

                if (!string.IsNullOrEmpty(Information.D_NAME) && (Convert.ToString(Information.D_NAME).Trim() != ""))
                {
                    strDealerName = string.Format("{0}", Information.D_NAME).Trim();
                }

                if (!string.IsNullOrEmpty(Information.D_ID.ToString()) && (Convert.ToString(Information.D_ID).Trim() != ""))
                {
                    iDealerID = Convert.ToInt32(string.Format("{0}", Information.D_ID).Trim());
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    // This is for Binding Tournament Information Based on Tournament 8 Activation Card Code.
    public static void BindTournamentInformation(string strCardNumber, ref string strTournamentName, ref string strTournamentDate, ref int iTourID, ref string strContractID, ref string strRegion)
    {
        try
        {
            DA.AHNODataContext context = new DA.AHNODataContext();
            List<DA.TBL_TOURNAMENT> TournamentInformation = (from TourInfo in context.TBL_TOURNAMENTs
                                                             join CardCodeInfo in context.TBL_TOURNAMENT_CARD_CODEs.Where(w => w.CT_CARD_CODE == strCardNumber.Trim() && w.CT_CARD_STATUS == 'Y')
                                                             on TourInfo.T_ID equals CardCodeInfo.CT_TOURNAMENT_ID
                                                             select TourInfo).OfType<DA.TBL_TOURNAMENT>().ToList<DA.TBL_TOURNAMENT>();
            if (TournamentInformation.Count > 0)
            {
                var Information = TournamentInformation.First();
                if (!string.IsNullOrEmpty(Information.T_NAME) && (Convert.ToString(Information.T_NAME).Trim() != ""))
                {
                    strTournamentName = Information.T_NAME;
                }
                if (!string.IsNullOrEmpty(Information.T_DATE.ToString()) && (Convert.ToString(Information.T_DATE).Trim() != ""))
                {
                    try
                    {
                        strTournamentDate = String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(Information.T_DATE));
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (!string.IsNullOrEmpty(Information.T_REGION) && (Convert.ToString(Information.T_REGION).Trim() != ""))
                {
                    strRegion = Convert.ToString(Information.T_REGION).Trim();
                }

                iTourID = Information.T_ID;
                strContractID = Information.T_CONTRACT_ID;
            }
        }
        catch (Exception ex)
        {
        }
    }
}

public class ListTodatatable
{
    public ListTodatatable()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable ToDataTable<T>(List<T> items)
    {
        var tb = new DataTable(typeof(T).Name);

        PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo prop in props)
        {
            Type t = GetCoreType(prop.PropertyType);
            tb.Columns.Add(prop.Name, t);
        }

        foreach (T item in items)
        {
            var values = new object[props.Length];

            for (int i = 0; i < props.Length; i++)
            {
                values[i] = props[i].GetValue(item, null);
            }

            tb.Rows.Add(values);
        }

        return tb;
    }

    public static bool IsNullable(Type t)
    {
        return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
    }

    public static Type GetCoreType(Type t)
    {
        if (t != null && IsNullable(t))
        {
            if (!t.IsValueType)
            {
                return t;
            }
            else
            {
                return Nullable.GetUnderlyingType(t);
            }
        }
        else
        {
            return t;
        }
    }
}