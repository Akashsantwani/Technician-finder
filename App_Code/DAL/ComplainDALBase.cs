using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for ComplainDALBase
/// </summary>
namespace WorkerFinder.DAL
{
    public abstract class ComplainDALBase : DatabaseConfig
    {
        #region local variable

        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion local variable

        #region Insert operation

        public Boolean Insert(ComplainENT entComplain)
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
                        objCmd.CommandText = "PR_Complain_Insert";
                        objCmd.Parameters.AddWithValue("@CustomerID", entComplain.CustomerID);
                        objCmd.Parameters.AddWithValue("@ClientID", entComplain.ClientID);
                        objCmd.Parameters.AddWithValue("@ComplainMessage", entComplain.ComplainMessage);
                        objCmd.Parameters.AddWithValue("@ComplainDate", entComplain.ComplainDate);
                        #endregion prepare command

                        objCmd.ExecuteNonQuery();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception Ex)
                    {
                        Message = Ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objconn.State == ConnectionState.Open)
                            objconn.Close();
                    }
                }
            }
        }

        #endregion Insert operation

        #region update operation

        public Boolean Update(ComplainENT entComplain)
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
                        objCmd.CommandText = "PR_Complain_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@ComplainID", entComplain.ComplainID);
                        objCmd.Parameters.AddWithValue("@CustomerID", entComplain.CustomerID);
                        objCmd.Parameters.AddWithValue("@ClientID", entComplain.ClientID);
                        objCmd.Parameters.AddWithValue("@ComplainMessage", entComplain.ComplainMessage);
                        objCmd.Parameters.AddWithValue("@ComplainDate", entComplain.ComplainDate);
                        #endregion prepare command

                        objCmd.ExecuteNonQuery();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception Ex)
                    {
                        Message = Ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objconn.State == ConnectionState.Open)
                            objconn.Close();
                    }
                }
            }
        }

        #endregion update operation

        #region Delete operation

        public Boolean Delete(SqlInt32 ComplainID)
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
                        objCmd.CommandText = "PR_Complain_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@ComplainID", ComplainID);
                        #endregion prepare command

                        objCmd.ExecuteNonQuery();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception Ex)
                    {
                        Message = Ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objconn.State == ConnectionState.Open)
                            objconn.Close();
                    }
                }
            }
        }

        #endregion Delete operation

        #region select operation

        public DataTable SelectAll()
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
                        objCmd.CommandText = "PR_Complain_SelectAll";
                        #endregion prepare command

                        #region read data and set control
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

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
        #region SelectByPK
        //public ComplainENT SelectByPK(SqlInt32 ComplainID)
        //{
        //    using (SqlConnection objconn = new SqlConnection(ConnectionString))
        //    {
        //        objconn.Open();
        //        using (SqlCommand objCmd = objconn.CreateCommand())
        //        {
        //            try
        //            {
        //                #region prepare command
        //                objCmd.CommandType = CommandType.StoredProcedure;
        //                objCmd.CommandText = "PR_Complain_SelectByPK";
        //                objCmd.Parameters.AddWithValue("@ComplainID", ComplainID);
        //                #endregion prepare command

        //                #region read data and set control
        //                ComplainENT entComplain = new ComplainENT();

        //                using (SqlDataReader objSDR = objCmd.ExecuteReader())
        //                {
        //                    while (objSDR.Read())
        //                    {
        //                        if (!objSDR["ComplainID"].Equals(DBNull.Value))
        //                        {
        //                            entComplain.ComplainID = Convert.ToInt32(objSDR["ComplainID"]);
        //                        }
        //                        if (!objSDR["ComplainName"].Equals(DBNull.Value))
        //                        {
        //                            entComplain.ComplainName = Convert.ToString(objSDR["ComplainName"]);
        //                        }
        //                        if (!objSDR["Address"].Equals(DBNull.Value))
        //                        {
        //                            entComplain.Address = Convert.ToString(objSDR["Address"]);
        //                        }
        //                        if (!objSDR["PhoneNo"].Equals(DBNull.Value))
        //                        {
        //                            entComplain.PhoneNo = Convert.ToString(objSDR["PhoneNo"]);
        //                        }
        //                        if (!objSDR["Email"].Equals(DBNull.Value))
        //                        {
        //                            entComplain.Email = Convert.ToString(objSDR["Email"]);
        //                        }
        //                        if (!objSDR["userName"].Equals(DBNull.Value))
        //                        {
        //                            entComplain.UserName = Convert.ToString(objSDR["UserName"]); // n small in database
        //                        }
        //                        if (!objSDR["Password"].Equals(DBNull.Value))
        //                        {
        //                            entComplain.Password = Convert.ToString(objSDR["Password"]);
        //                        }
        //                    }
        //                }

        //                return entComplain;

        //                #endregion read data and set control
        //            }
        //            catch (SqlException sqlex)
        //            {
        //                Message = sqlex.InnerException.Message.ToString();
        //                return null;
        //            }
        //            catch (Exception Ex)
        //            {
        //                Message = Ex.InnerException.Message.ToString();
        //                return null;
        //            }
        //            finally
        //            {
        //                if (objconn.State == ConnectionState.Open)
        //                    objconn.Close();
        //            }
        //        }
        //    }
        //}
        #endregion SelectByPK

        #region Selectddl
        //public DataTable SelectDropDownList()
        //{
        //    using (SqlConnection objconn = new SqlConnection(ConnectionString))
        //    {
        //        objconn.Open();
        //        using (SqlCommand objCmd = objconn.CreateCommand())
        //        {
        //            try
        //            {
        //                #region prepare command
        //                objCmd.CommandType = CommandType.StoredProcedure;
        //                objCmd.CommandText = "PR_Complain_SelectDropDownList";
        //                #endregion prepare command

        //                #region read data and set control
        //                DataTable dt = new DataTable();
        //                using (SqlDataReader objSDR = objCmd.ExecuteReader())
        //                {
        //                    dt.Load(objSDR);
        //                }
        //                return dt;

        //                #endregion read data and set control
        //            }
        //            catch (SqlException sqlex)
        //            {
        //                Message = sqlex.InnerException.Message.ToString();
        //                return null;
        //            }
        //            catch (Exception Ex)
        //            {
        //                Message = Ex.InnerException.Message.ToString();
        //                return null;
        //            }
        //            finally
        //            {
        //                if (objconn.State == ConnectionState.Open)
        //                    objconn.Close();
        //            }
        //        }
        //    }
        //}
        #endregion Selectddl

        #endregion select operation
    }
}