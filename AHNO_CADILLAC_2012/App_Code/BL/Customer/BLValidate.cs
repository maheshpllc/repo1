using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

/// <summary>
/// Summary description for BLValidatingCustomer
/// </summary>

public class BLValidate
{
    public BLValidate()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /********************** This is for Checking Card Code and Dealer Information Exits or not *****************************/

    public static string ValidateCustomerInfo(string strCardCode, int iPrgmId, string strDealerCode)
    {
        int err_No = 0;
        string strErrMsg = "";
        DataTable dtReport = new DataTable();
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        try
        {
            con = DABasics.ConnectionString();
            string sp_name = "";
            SqlParameter Param1, Param2, Param3, Param4;
            sp_name = "usp_GetCustomer_Info";
            con.Open();
            cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            //||--------Parameter 1 is Card Core---------||
            Param1 = new SqlParameter("@c_card_Code", SqlDbType.VarChar, 50);
            Param1.Value = strCardCode;
            cmd.Parameters.Add(Param1);

            //||--------Parameter 2 is Program Code ---------||
            Param2 = new SqlParameter("@c_program_id", SqlDbType.Int);
            Param2.Value = iPrgmId;
            cmd.Parameters.Add(Param2);

            //||--------Parameter 3 is Dealer Code ---------||
            Param3 = new SqlParameter("@c_d_code", SqlDbType.VarChar, 50);
            Param3.Value = strDealerCode;
            cmd.Parameters.Add(Param3);

            //||--------Parameter4 is out paramater to get return Error Message---------||
            Param4 = new SqlParameter("@errorno", SqlDbType.Int);
            cmd.Parameters.Add(Param4);
            Param4.Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            err_No = Convert.ToInt32(Param4.Value);
        }
        catch
        {
        }
        finally
        {
            cmd.Dispose();
            con.Close();
            con = null;
        }
        return strErrMsg = DisplayErrorMessage(err_No.ToString());
    }

    /************************                                                                   ****************************/

    // This is for Checking 8 - DIGIT CARD CODE And Dealer Code Exits in Register User Table
    public static bool CheckingCardCodeDealerCode(string strActivationCode, string strDealerCode, string strBacCode)
    {
        try
        {
            DA.AHNODataContext context = new DA.AHNODataContext();
            List<DA.TBL_REGISTRATION> custInfo = (from custRegInfo in context.TBL_REGISTRATIONs.Where(l => l.R_CARD_NUMBER == strActivationCode && (l.R_BAC_CODE == strBacCode || l.R_DEALER_CODE == strDealerCode))
                                                  select custRegInfo).OfType<DA.TBL_REGISTRATION>().ToList<DA.TBL_REGISTRATION>();
            if (custInfo.Count > 0)
            {
                var Information = custInfo.First();
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

    // This Block is for Displaying Error Messages Based on Error Message
    public static string DisplayErrorMessage(string strErrno)
    {
        string strErr = "";
        if (strErrno == "-1")
        {
            strErr = " No Coupon Codes Available for $50 Test Drive. Please call 877-382-8265. <br /> ";
        }
        else if (strErrno == "-2")
        {
            strErr = " 8 DIGIT ACTIVATION CODE and DEALER CODE have been already used. Please call 877-382-8265.<br />";
        }
        else if (strErrno == "-3" || strErrno == "-4" || strErrno == "-5")
        {
            strErr = "Please Enter Valid 8 DIGIT ACTIVATION CODE or DEALER CODE. If a valid code is not working please call 877-382-8265.<br /> ";
        }
        else
        {
            strErr = "Valid";
        }
        return strErr;
    }

    // This is for Validating Customer Registration Information.
    public static string ValidateCustomerInfo(string strFirstName, string strLastName, int iPrgmId, string strEmail, string strAddress, string strCity, string strState, string strZipCode, string strContractId)
    {
        int err_No = 0;
        string strErrMsg = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        try
        {
            con = DABasics.ConnectionString();
            string sp_name = "";
            SqlParameter Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8, Param9, Param10;
            sp_name = "usp_Validate_Customer_Info";
            con.Open();
            cmd = new SqlCommand(sp_name, con);
            cmd.CommandType = CommandType.StoredProcedure;

            //||--------Parameter 1 is First Name---------||
            Param1 = new SqlParameter("@first_name", SqlDbType.VarChar, 50);
            Param1.Value = strFirstName;
            cmd.Parameters.Add(Param1);

            //||--------Parameter 2 is Last Name ---------||
            Param2 = new SqlParameter("@last_name", SqlDbType.VarChar, 50);
            Param2.Value = strLastName;
            cmd.Parameters.Add(Param2);

            //||--------Parameter 10 is Program Id ---------||
            Param10 = new SqlParameter("@prgm_id", SqlDbType.Int);
            Param10.Value = iPrgmId;
            cmd.Parameters.Add(Param10);

            //||--------Parameter 3 is Email ---------||
            Param3 = new SqlParameter("@email", SqlDbType.VarChar, 250);
            Param3.Value = strEmail;
            cmd.Parameters.Add(Param3);

            //||--------Parameter 4 is Contract Id ---------||
            Param4 = new SqlParameter("@contractId", SqlDbType.VarChar, 50);
            Param4.Value = strContractId;
            cmd.Parameters.Add(Param4);

            //||--------Parameter 5 is Address ---------||
            Param5 = new SqlParameter("@address", SqlDbType.VarChar, 150);
            Param5.Value = strAddress;
            cmd.Parameters.Add(Param5);

            //||--------Parameter 6 is City ---------||
            Param6 = new SqlParameter("@city", SqlDbType.VarChar, 50);
            Param6.Value = strCity;
            cmd.Parameters.Add(Param6);

            //||--------Parameter 7 is State ---------||
            Param7 = new SqlParameter("@state", SqlDbType.VarChar, 10);
            Param7.Value = strState;
            cmd.Parameters.Add(Param7);

            //||--------Parameter 8 is Zip Code ---------||
            Param8 = new SqlParameter("@zip", SqlDbType.VarChar, 10);
            Param8.Value = strZipCode;
            cmd.Parameters.Add(Param8);

            //||--------Parameter9 is out parameter to get return Error Message---------||
            Param9 = new SqlParameter("@errorno", SqlDbType.Int);
            cmd.Parameters.Add(Param9);
            Param9.Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            err_No = Convert.ToInt32(Param9.Value);
        }
        catch
        {
        }
        finally
        {
            cmd.Dispose();
            con.Close();
            con = null;
        }
        return strErrMsg = DisplayErrorMessage(err_No.ToString());
    }
}