using BBDNRESTDemoCSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDB
{
    public class BBTermList
    {
        SqlConnection CN = new SqlConnection(ConfigurationManager.ConnectionStrings["DSISLMS"].ToString());
        public DataTable GetTermList()
        {
            DataTable _gridData = new DataTable();
            SqlCommand CMD = new SqlCommand();
            try
            {
                DataSet _dataSet = new DataSet();
                {
                    CN.Open();
                    CMD.Connection = CN;
                    CMD.CommandType = System.Data.CommandType.StoredProcedure;
                    CMD.CommandText = "spBBTermsGet";
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
        public int InsetTerm(Term term, string Action)
        {
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
                        CMD.CommandType = CommandType.StoredProcedure;
                        CMD.CommandText = "spBBTermsInsertLog";
                        CMD.Parameters.AddWithValue("@BBID", term.id);
                        CMD.Parameters.AddWithValue("@BBUniqueId", term.externalId);
                        CMD.Parameters.AddWithValue("@Termname", term.name);
                        CMD.Parameters.AddWithValue("@Action", Action);
                        result = CMD.ExecuteNonQuery();
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
