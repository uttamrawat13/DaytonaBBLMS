using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

using System.Threading.Tasks;
using BBDNRESTDemoCSharp;

namespace CoreDB
{
   public class BBStudentList
    {
    
       public  DataTable GetStudentList()
        {
            SqlConnection CN = new SqlConnection(ConfigurationManager.ConnectionStrings["DSISLMS"].ToString());
   
            DataTable _gridData = new DataTable();
            SqlCommand CMD = new SqlCommand();
            try
            {
                DataSet _dataSet = new DataSet();
                {
                    CN.Open();
                    CMD.Connection = CN;
                    CMD.CommandType = System.Data.CommandType.StoredProcedure;
                    CMD.CommandText = "spBBUserGet";
                    CMD.CommandTimeout = 1000;                   
                    CMD.Prepare();
                    SqlDataAdapter DataAdapter = new SqlDataAdapter(CMD);
                    DataAdapter.Fill(_dataSet);
                }
                _gridData = _dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                return _gridData;
            }

            finally
            {
                CMD.Dispose();
                CN.Close();
                CN.Dispose();
            }
            return _gridData;
        }

       public DataTable GetALLStudentListInsertBD()
       {
           SqlConnection CN = new SqlConnection(ConfigurationManager.ConnectionStrings["DSISLMS"].ToString());

           DataTable _gridData = new DataTable();
           SqlCommand CMD = new SqlCommand();
           try
           {
               DataSet _dataSet = new DataSet();
               {
                   CN.Open();
                   CMD.Connection = CN;
                   CMD.CommandType = System.Data.CommandType.StoredProcedure;
                   CMD.CommandText = "spBBUserBulkInsert";
                   CMD.CommandTimeout = 1000;
                   CMD.Prepare();
                   SqlDataAdapter DataAdapter = new SqlDataAdapter(CMD);
                   DataAdapter.Fill(_dataSet);
               }
               _gridData = _dataSet.Tables[0];
           }
           catch (Exception ex)
           {
               return _gridData;
           }

           finally
           {
               CMD.Dispose();
               CN.Close();
               CN.Dispose();
           }
           return _gridData;
       }


       public int InsetUser(User user, string Action)
       {
           SqlConnection CN = new SqlConnection(ConfigurationManager.ConnectionStrings["DSISLMS"].ToString());
   
           int result = 0;
           try
           {
             
               Boolean status;
               try
               {
                   using (SqlCommand CMD = new SqlCommand())
                   {
                       CN.Open();
                       CMD.Connection = CN;
                       CMD.CommandType =CommandType.StoredProcedure;
                       CMD.CommandText = "spBBUserInsertLog";
                       CMD.Parameters.AddWithValue("@BBID", user.id);
                       CMD.Parameters.AddWithValue("@StudentNo", user.externalId);
                       CMD.Parameters.AddWithValue("@Username", user.userName);
                       CMD.Parameters.AddWithValue("@BBuuid", user.uuid);
                       CMD.Parameters.AddWithValue("@BBUniqueId", user.externalId);
                       CMD.Parameters.AddWithValue("@Action", Action);
                       result= CMD.ExecuteNonQuery();
                      CN.Close();
                   }

               }
               catch (Exception ex)
               {
                   result = 0;
               }
               return result;
           }
           catch (Exception ex)
           {
               return result;
           }

       }
      
       
    }
}
