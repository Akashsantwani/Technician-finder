using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for WorkDAL
/// </summary>
namespace WorkerFinder.DAL
{
    public class WorkDAL : WorkDALBase
    {
        #region SelectByClient
        public DataTable SelectByClientID(SqlInt32 ClientID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Work_SelectByClient";
                        objCmd.Parameters.AddWithValue("@ClientID", ClientID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        //WorkENT entWork = new WorkENT();

                        //using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        //{
                        //    while (objSDR.Read())
                        //    {
                        //        if (!objSDR["WorkID"].Equals(DBNull.Value))
                        //        {
                        //            entWork.WorkID = Convert.ToInt32(objSDR["WorkID"]);
                        //        }
                        //        if (!objSDR["CustomerID"].Equals(DBNull.Value))
                        //        {
                        //            entWork.CustomerID = Convert.ToInt32(objSDR["CustomerID"]);
                        //        }
                        //        if (!objSDR["Workdate"].Equals(DBNull.Value))
                        //        {
                        //            entWork.Workdate = Convert.ToDateTime(objSDR["Workdate"]);
                        //        }
                        //    }
                        //}

                        //return entWork;
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion SelectByClient

        #region SelectByCustomer

        public DataTable SelectByCustomerID(SqlInt32 CustomerID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Work_SelectByCustomer";
                        objCmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        //WorkENT entWork = new WorkENT();

                        //using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        //{
                        //    while (objSDR.Read())
                        //    {
                        //        if (!objSDR["ClientID"].Equals(DBNull.Value))
                        //        {
                        //            entWork.ClientID = Convert.ToInt32(objSDR["ClientID"]);
                        //        }
                        //        if (!objSDR["WorkID"].Equals(DBNull.Value))
                        //        {
                        //            entWork.WorkID = Convert.ToInt32(objSDR["WorkID"]);
                        //        }
                        //        if (!objSDR["Workdate"].Equals(DBNull.Value))
                        //        {
                        //            entWork.Workdate = Convert.ToDateTime(objSDR["Workdate"]);
                        //        }
                        //    }
                        //}

                        //return entWork;
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion SelectByCustomer
    }
}