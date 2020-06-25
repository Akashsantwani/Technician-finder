using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for JobTypeDAL
/// </summary>
namespace WorkerFinder.DAL
{
    public class JobTypeDAL : JobTypeDALBase
    {
        public JobTypeDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public List<String> SelectByText(SqlString JobTypeName)
        {
            using (SqlConnection objconn = new SqlConnection(ConnectionString))
            {
                objconn.Open();
                using (SqlCommand objCmd = objconn.CreateCommand())
                {
                    try
                    {
                        #region prepare command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_JobType_SelectByText";
                        objCmd.Parameters.AddWithValue("@JobTypeName", JobTypeName);
                        #endregion prepare command

                        #region read data and set control
                        JobTypeENT entJobType = new JobTypeENT();
                        List<string> empResult = new List<string>();
                        SqlDataReader objSDR1 = objCmd.ExecuteReader();
                        while (objSDR1.Read())
                        {
                            empResult.Add(Convert.ToString(objSDR1["JobTypeName"]));
                        }
                        //using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        //{
                        //    while (objSDR.Read())
                        //    {
                        //        if (!objSDR["JobTypeID"].Equals(DBNull.Value))
                        //        {
                        //            entJobType.JobTypeID = Convert.ToInt32(objSDR["JobTypeID"]);
                        //        }
                        //        if (!objSDR["JobTypeName"].Equals(DBNull.Value))
                        //        {
                        //            entJobType.JobTypeName = Convert.ToString(objSDR["JobTypeName"]);
                        //        }
                        //    }
                        //}

                        //return entJobType;
                        return empResult;

                        #endregion read data and set control
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception Ex)
                    {
                        Message = Ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objconn.State == ConnectionState.Open)
                            objconn.Close();
                    }
                }
            }
        }
    }
}