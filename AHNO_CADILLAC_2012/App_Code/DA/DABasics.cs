using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DABasics
/// </summary>
public class DABasics
{
       public DABasics()
       {
              //
              // TODO: Add constructor logic here
              //
       }

       public static SqlConnection ConnectionString()
       {
              return new SqlConnection(ConfigurationManager.ConnectionStrings["AHNO_BGC_2012ConnectionString"].ConnectionString);
       }

       public static DataSet GetData(CommandType commandType, string commandText)
       {
              SqlCommand cmd = new SqlCommand();
              SqlConnection Connection = null;
              SqlDataAdapter da = null;
              DataSet ds = new DataSet();
              DataTable dt = new DataTable();
              string errmsg = "";
              try
              {
                     Connection = ConnectionString();
                     Connection.Open();
                     cmd.CommandText = commandText;
                     cmd.CommandType = commandType;
                     cmd.Connection = Connection;
                     da = new SqlDataAdapter(cmd);
                     da.Fill(ds);
                     // dt = ds.Tables[0];
                     return ds;
              }
              catch (Exception ex)
              {
                     errmsg = ex.Message;
                     return null;
              }
              finally
              {
                     cmd.Parameters.Clear();
                     if (da != null) da.Dispose();
                     if (Connection != null) Connection.Dispose();
              }
       }

       public static string ExecuteNonQuery(string commandText)
       {
              SqlConnection con = ConnectionString();
              SqlCommand cmd;
              try
              {
                     con.Open();
                     cmd = new SqlCommand(commandText, con);
                     cmd.ExecuteNonQuery();
              }
              catch (Exception ex)
              {
                     return ex.Message;
              }
              finally
              {
                     con.Close();
              }
              cmd = null;
              return "Success";
       }

       // This is for Retrieve Data Table from Store Procedure with string Parameter
       public static DataTable RetriveSpData(string strProcedurerName, string strSearchString)
       {
              DataTable dtReport = new DataTable();
              SqlConnection con = new SqlConnection();
              SqlCommand cmd = new SqlCommand();
              SqlDataAdapter da = new SqlDataAdapter();
              try
              {
                     con = DABasics.ConnectionString();
                     string sp_name = "";
                     SqlParameter Param1;
                     sp_name = strProcedurerName;

                     cmd = new SqlCommand(sp_name, con);
                     cmd.CommandType = CommandType.StoredProcedure;

                     Param1 = new SqlParameter("@expression", SqlDbType.VarChar, 2000);
                     Param1.Value = strSearchString;
                     cmd.Parameters.Add(Param1);

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

       // This is for Retrieve Data Table from Store Procedure
       public static DataTable RetriveSpData(string strProcedurerName)
       {
              SqlConnection con = DABasics.ConnectionString();
              SqlCommand cmd = new SqlCommand();
              string sp_name = "";
              DataTable dtReport = new DataTable();

              sp_name = strProcedurerName;

              cmd = new SqlCommand(sp_name, con);
              cmd.CommandType = CommandType.StoredProcedure;
              SqlDataAdapter objDA = new SqlDataAdapter(cmd);
              objDA.Fill(dtReport);
              return dtReport;
       }

       // This is for Retrieve Data Table from Store Procedure with string Parameter
       public static DataTable RetriveData(string strProcedurerName, int id, string strSearchString)
       {
              DataTable dtReport = new DataTable();
              SqlConnection con = new SqlConnection();
              SqlCommand cmd = new SqlCommand();
              SqlDataAdapter da = new SqlDataAdapter();
              try
              {
                     con = DABasics.ConnectionString();
                     string sp_name = "";
                     SqlParameter Param1, Param2;
                     sp_name = strProcedurerName;

                     cmd = new SqlCommand(sp_name, con);
                     cmd.CommandType = CommandType.StoredProcedure;

                     Param1 = new SqlParameter("@ID", SqlDbType.Int);
                     Param1.Value = id;
                     cmd.Parameters.Add(Param1);

                     Param2 = new SqlParameter("@expression", SqlDbType.VarChar, 5000);
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
}