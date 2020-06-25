using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for CustomerDALBase
/// </summary>
namespace WorkerFinder.DAL
{
    public abstract class CustomerDALBase : DatabaseConfig
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

        public Boolean Insert(CustomerENT entCustomer)
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
                        objCmd.CommandText = "PR_Customer_Insert";
                        objCmd.Parameters.AddWithValue("@CustomerName", entCustomer.CustomerName);
                        objCmd.Parameters.AddWithValue("@Address", entCustomer.Address);
                        objCmd.Parameters.AddWithValue("@phoneNo", entCustomer.PhoneNo);
                        objCmd.Parameters.AddWithValue("@Email", entCustomer.Email);
                        objCmd.Parameters.AddWithValue("@CityID", entCustomer.CityID);
                        objCmd.Parameters.AddWithValue("@PhotoPath", entCustomer.PhotoPath);
                        objCmd.Parameters.AddWithValue("@UserName", entCustomer.UserName);
                        objCmd.Parameters.AddWithValue("@Password", entCustomer.Password);
                        objCmd.Parameters.AddWithValue("@RegistrationDate", entCustomer.RegistrationDate);
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

        public Boolean Update(CustomerENT entCustomer)
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
                        objCmd.CommandText = "PR_Customer_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@CustomerID", entCustomer.CustomerID);
                        objCmd.Parameters.AddWithValue("@CustomerName", entCustomer.CustomerName);
                        objCmd.Parameters.AddWithValue("@Address", entCustomer.Address);
                        objCmd.Parameters.AddWithValue("@CityID", entCustomer.CityID);
                        objCmd.Parameters.AddWithValue("@phoneNo", entCustomer.PhoneNo);
                        objCmd.Parameters.AddWithValue("@Email", entCustomer.Email);
                        objCmd.Parameters.AddWithValue("@PhotoPath", entCustomer.PhotoPath);
                        objCmd.Parameters.AddWithValue("@UserName", entCustomer.UserName);
                        objCmd.Parameters.AddWithValue("@Password", entCustomer.Password);
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

        public Boolean Delete(SqlInt32 CustomerID)
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
                        objCmd.CommandText = "PR_Customer_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@CustomerID", CustomerID);
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
                        objCmd.CommandText = "PR_Customer_SelectAll";
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

        public CustomerENT SelectByPK(SqlInt32 CustomerID)
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
                        objCmd.CommandText = "PR_Customer_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                        #endregion prepare command

                        #region read data and set control
                        CustomerENT entCustomer = new CustomerENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CustomerID"].Equals(DBNull.Value))
                                {
                                    entCustomer.CustomerID = Convert.ToInt32(objSDR["CustomerID"]);
                                }
                                if (!objSDR["CustomerName"].Equals(DBNull.Value))
                                {
                                    entCustomer.CustomerName = Convert.ToString(objSDR["CustomerName"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    entCustomer.Address = Convert.ToString(objSDR["Address"]);
                                }
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    entCustomer.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                {
                                    entCustomer.CityID = Convert.ToInt32(objSDR["CityID"]);
                                }
                                if (!objSDR["PhoneNo"].Equals(DBNull.Value))
                                {
                                    entCustomer.PhoneNo = Convert.ToString(objSDR["PhoneNo"]);
                                }
                                if (!objSDR["PhotoPath"].Equals(DBNull.Value))
                                {
                                    entCustomer.PhotoPath = Convert.ToString(objSDR["PhotoPath"]);
                                }
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                {
                                    entCustomer.Email = Convert.ToString(objSDR["Email"]);
                                }
                                if (!objSDR["userName"].Equals(DBNull.Value))
                                {
                                    entCustomer.UserName = Convert.ToString(objSDR["UserName"]); // n small in database
                                }
                                if (!objSDR["Password"].Equals(DBNull.Value))
                                {
                                    entCustomer.Password = Convert.ToString(objSDR["Password"]);
                                }
                            }
                        }

                        return entCustomer;

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
                        objCmd.CommandText = "PR_Customer_SelectDropDownList";
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