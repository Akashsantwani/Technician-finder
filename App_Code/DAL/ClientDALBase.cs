using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for ClientDALBase
/// </summary>
namespace WorkerFinder.DAL
{
    public abstract class ClientDALBase : DatabaseConfig
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

        public Boolean Insert(ClientENT entClient)
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
                        objCmd.CommandText = "PR_Client_Insert";
                        objCmd.Parameters.AddWithValue("@ClientName", entClient.ClientName);
                        objCmd.Parameters.AddWithValue("@Address", entClient.Address);
                        objCmd.Parameters.AddWithValue("@phoneNo", entClient.PhoneNo);
                        objCmd.Parameters.AddWithValue("@Email", entClient.Email);
                        objCmd.Parameters.AddWithValue("@UserName", entClient.UserName);
                        objCmd.Parameters.AddWithValue("@Password", entClient.Password);
                        objCmd.Parameters.AddWithValue("@CityID", entClient.CityID);
                        objCmd.Parameters.AddWithValue("@IsActive", entClient.IsActive);
                        objCmd.Parameters.AddWithValue("@JobTypeID", entClient.JobTypeID);
                        objCmd.Parameters.AddWithValue("@PhotoPath", entClient.PhotoPath);
                        objCmd.Parameters.AddWithValue("@BirthDate", entClient.BirthDate);
                        objCmd.Parameters.AddWithValue("@Gender", entClient.Gender);
                        objCmd.Parameters.AddWithValue("@RegistrationDate", entClient.RegistrationDate);
                        objCmd.Parameters.AddWithValue("@Skills", entClient.Skills);
                        objCmd.Parameters.AddWithValue("@Experience", entClient.Experience);
                        #endregion prepare command

                        objCmd.ExecuteNonQuery();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        //Message = sqlex.InnerException.Message.ToString();
                        Message = sqlex.Message.ToString();
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

        public Boolean Update(ClientENT entClient)
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
                        objCmd.CommandText = "PR_Client_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@ClientID", entClient.ClientID);
                        objCmd.Parameters.AddWithValue("@ClientName", entClient.ClientName);
                        objCmd.Parameters.AddWithValue("@Address", entClient.Address);
                        objCmd.Parameters.AddWithValue("@Email", entClient.Email);
                        objCmd.Parameters.AddWithValue("@UserName", entClient.UserName);
                        objCmd.Parameters.AddWithValue("@CityID", entClient.CityID);
                        objCmd.Parameters.AddWithValue("@IsActive", entClient.IsActive);
                        objCmd.Parameters.AddWithValue("@JobTypeID", entClient.JobTypeID);
                        objCmd.Parameters.AddWithValue("@PhotoPath", entClient.PhotoPath);
                        objCmd.Parameters.AddWithValue("@BirthDate", entClient.BirthDate);
                        objCmd.Parameters.AddWithValue("@Gender", entClient.Gender);
                        objCmd.Parameters.AddWithValue("@Skills", entClient.Skills);
                        objCmd.Parameters.AddWithValue("@Experience", entClient.Experience);
                        #endregion prepare command

                        objCmd.ExecuteNonQuery();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
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

        public Boolean Delete(SqlInt32 ClientID)
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
                        objCmd.CommandText = "PR_Client_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@ClientID", ClientID);
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
                        objCmd.CommandText = "PR_Client_SelectAll";
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
                        Message = sqlex.Message.ToString();
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

        public ClientENT SelectByPK(SqlInt32 ClientID)
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
                        objCmd.CommandText = "PR_Client_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ClientID", ClientID);
                        #endregion prepare command

                        #region read data and set control
                        ClientENT entClient = new ClientENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ClientID"].Equals(DBNull.Value))
                                {
                                    entClient.ClientID = Convert.ToInt32(objSDR["ClientID"]);
                                }
                                if (!objSDR["ClientName"].Equals(DBNull.Value))
                                {
                                    entClient.ClientName = Convert.ToString(objSDR["ClientName"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    entClient.Address = Convert.ToString(objSDR["Address"]);
                                }
                                if (!objSDR["PhoneNo"].Equals(DBNull.Value))
                                {
                                    entClient.PhoneNo = Convert.ToString(objSDR["PhoneNo"]);
                                }
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                {
                                    entClient.Email = Convert.ToString(objSDR["Email"]);
                                }
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    entClient.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                {
                                    entClient.CityID = Convert.ToInt32(objSDR["CityID"]);
                                }
                                if (!objSDR["userName"].Equals(DBNull.Value))
                                {
                                    entClient.UserName = Convert.ToString(objSDR["UserName"]);
                                }
                                if (!objSDR["Password"].Equals(DBNull.Value))
                                {
                                    entClient.Password = Convert.ToString(objSDR["Password"]);
                                }
                                if (!objSDR["JobTypeID"].Equals(DBNull.Value))
                                {
                                    entClient.JobTypeID = Convert.ToInt32(objSDR["JobTypeID"]);
                                }
                                if (!objSDR["IsActive"].Equals(DBNull.Value))
                                {
                                    entClient.IsActive = Convert.ToBoolean(objSDR["IsActive"]);
                                }
                                if (!objSDR["PhotoPath"].Equals(DBNull.Value))
                                {
                                    entClient.PhotoPath = Convert.ToString(objSDR["PhotoPath"]);
                                }
                                if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                {
                                    entClient.BirthDate = Convert.ToDateTime(objSDR["BirthDate"]);
                                    //String BirthDate = objSDR["BirthDate"].ToString();
                                    //entClient.BirthDate = DateTime.Parse(objSDR["BirthDate"].ToString()).ToString("yyyy/MM/dd");
                                }
                                if (!objSDR["Gender"].Equals(DBNull.Value))
                                {
                                    entClient.Gender = Convert.ToString(objSDR["Gender"]);
                                }
                                if (!objSDR["RegistrationDate"].Equals(DBNull.Value))
                                {
                                    entClient.RegistrationDate = Convert.ToDateTime(objSDR["RegistrationDate"]);
                                }
                                if (!objSDR["Skills"].Equals(DBNull.Value))
                                {
                                    entClient.Skills = Convert.ToString(objSDR["Skills"]);
                                }
                                if (!objSDR["Experience"].Equals(DBNull.Value))
                                {
                                    entClient.Experience = Convert.ToInt32(objSDR["Experience"]);
                                }
                            }
                        }

                        return entClient;

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

        public DataTable SelectDropDownList()
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
                        objCmd.CommandText = "PR_Client_SelectDropDownList";
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
        #endregion select operation
    }
}