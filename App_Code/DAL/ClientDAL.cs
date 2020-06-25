using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Net;
using System.Net.Mail;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for ClientDAL
/// </summary>
namespace WorkerFinder.DAL
{
    public class ClientDAL : ClientDALBase
    {
        #region SelectByPhonePassword

        public DataTable SelectByPhonePassword(SqlString PhoneNo, SqlString Password)  //login client
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
                        objCmd.CommandText = "PR_Client_SelectByPhonePassword";
                        objCmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                        objCmd.Parameters.AddWithValue("@PassWord", Password);
                        #endregion prepare command

                        DataTable dtUser = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dtUser.Load(objSDR);
                        }
                        return dtUser;
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

        #endregion SelectByPhonePassword

        #region SelectByJobType&CityID
        public DataTable SelectByJobTypeID(SqlInt32 JobTypeID, SqlInt32 CityID)  //home page to worker list
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
                        objCmd.CommandText = "PR_Client_SelectByJobType";
                        objCmd.Parameters.AddWithValue("@JobTypeID", JobTypeID);
                        objCmd.Parameters.AddWithValue("@CityID", CityID);
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
        #endregion SelectByJobType&CityID

        #region SelectPasswordByPK
        public String SelectPasswordByPK(SqlInt32 ClientID)  // check client's password is true or false
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
                        objCmd.CommandText = "PR_Client_SelectPasswordByPK";
                        objCmd.Parameters.AddWithValue("@ClientID", ClientID);
                        #endregion prepare command

                        #region read data and set control
                        String password = null;
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["Password"].Equals(DBNull.Value))
                                {
                                    password = Convert.ToString(objSDR["Password"]);
                                }
                            }
                        }
                        return password;
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
        #endregion SelectPasswordByPK

        #region UpdatePasswordByPK
        public Boolean UpdatePasswordByPK(ClientENT entClient)  //update password popup of master page
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
                        objCmd.CommandText = "PR_Client_UpdatePasswordByPK";
                        objCmd.Parameters.AddWithValue("@ClientID", entClient.ClientID);

                        objCmd.Parameters.AddWithValue("@Password", entClient.Password);

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

        #endregion UpdatePasswordByPK

        #region UpdatePhoneNoByPK
        public Boolean UpdatePhoneNoByPK(ClientENT entClient)  //update phone no popup of master page
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
                        objCmd.CommandText = "PR_Client_UpdatePhoneNoByPK";
                        objCmd.Parameters.AddWithValue("@ClientID", entClient.ClientID);
                        objCmd.Parameters.AddWithValue("@PhoneNo", entClient.PhoneNo);

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

        #endregion UpdatePhoneNoByPK

        #region selectByPhoneNo
        public ClientENT SelectByPhoneNo(SqlString PhoneNo)  //login page forgot password
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
                        objCmd.CommandText = "PR_Client_SelectByPhoneNo";
                        objCmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                        //objCmd.Parameters.AddWithValue("@CityID", CityID);
                        #endregion prepare command

                        #region read data and set control
                        //DataTable dt = new DataTable();
                        ClientENT entClient = new ClientENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            //dt.Load(objSDR);
                            while (objSDR.Read())
                            {
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                {
                                    entClient.Email = Convert.ToString(objSDR["Email"]);
                                }
                                if (!objSDR["ClientID"].Equals(DBNull.Value))
                                {
                                    entClient.ClientID = Convert.ToInt32(objSDR["ClientID"]);
                                }
                                if (!objSDR["ClientName"].Equals(DBNull.Value))
                                {
                                    entClient.ClientName = Convert.ToString(objSDR["ClientName"]);
                                }
                            }
                        }
                        return entClient;

                        //return dt;

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

        #endregion selectByPhoneNo

        #region SendResetPasswordMail

        public Boolean SendResetPasswordMail(ClientENT entclient)  //Int32 ClientID, String ClientName, String Email
        {
            //String password = null;
            //password = RandomPassword();
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                mail.From = new MailAddress("akashsantwani2014@gmail.com");
                mail.To.Add(new MailAddress(entclient.Email.ToString()));
                mail.Subject = "Reset Password";
                //mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                //string htmlbody = "code is here";
                mail.Body = "<p><b><h3>hello " + entclient.ClientName.ToString() + ",</h3></b><br>welcome to worker finder support<br>we have received your request for passoword reset and your new password is " + entclient.Password.ToString() + "</p>";
                //mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.Priority = MailPriority.High;
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                try
                {
                    client.Credentials = new NetworkCredential("akashsantwani2014@gmail.com", ""); //password in second double quotes
                }
                catch (Exception ex)
                {
                    //lblmessage.Text = Convert.ToString(ex);
                    Message = ex.InnerException.Message.ToString();
                    return false;
                }
                //client.Port = 25;
                //client.Host = "smtp.gmail.com";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Congratulations, You Are Successfully Subscribed, We'll keep you updated');", true);
                //ClientENT entClient = new ClientENT();
                //entClient.ClientID = ClientID;
                //entClient.Password = password;
                //Boolean b = UpdatePasswordByPK(entClient);
                return true;
            }
            catch (Exception ex)
            {
                string errorMessage = string.Empty;
                while (ex != null)
                {
                    errorMessage += ex.ToString();
                    ex = ex.InnerException;
                }
                return false;
                //lblmessage.Text = ex.Message.ToString();
                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Sorry, There Was An Error');", true);
            }
        }

        #endregion SendResetPasswordMail

        #region SendJobRequestMail

        public Boolean SendNewJobMail(ClientENT entclient, CustomerENT entcustomer)  //Int32 ClientID, String ClientName, String Email
        {
            //String password = null;
            //password = RandomPassword();
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                mail.From = new MailAddress("akashsantwani2014@gmail.com");
                mail.To.Add(new MailAddress(entclient.Email.ToString()));
                mail.Subject = "New Work Request";
                //mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                //string htmlbody = "code is here";
                mail.Body = "<p><b><h3>Hey " + entclient.ClientName.ToString() + ",</h3></b><br>You have new service request from <b>" + entcustomer.CustomerName.ToString() + "</b> at " +
                    entcustomer.Address.ToString() + ".<br>Please contact the customer at <a href='tel:+91" + entcustomer.PhoneNo.ToString() + "'>+91-" + entcustomer.PhoneNo.ToString() +
                    "</a> and provide the service to them as per requirement.</p>";
                //mail.Body = "<p><b><h3>hello " + entclient.ClientName.ToString() + ",</h3></b><br>welcome to worker finder support<br>we have received your request for passoword reset and your new password is " + entclient.Password.ToString() + "</p>";
                //mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.Priority = MailPriority.High;
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                try
                {
                    client.Credentials = new NetworkCredential("akashsantwani2014@gmail.com", ""); // password in second double quotes
                }
                catch (Exception ex)
                {
                    //lblmessage.Text = Convert.ToString(ex);
                    Message = ex.InnerException.Message.ToString();
                    return false;
                }
                //client.Port = 25;
                //client.Host = "smtp.gmail.com";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Congratulations, You Are Successfully Subscribed, We'll keep you updated');", true);
                return true;
            }
            catch (Exception ex)
            {
                string errorMessage = string.Empty;
                while (ex != null)
                {
                    errorMessage += ex.ToString();
                    ex = ex.InnerException;
                }
                return false;
                //lblmessage.Text = ex.Message.ToString();
                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Sorry, There Was An Error');", true);
            }
        }

        #endregion SendJobRequestMail

        #region RandomPassword
        public string RandomPassword()
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyz";//ABCDEFGHJKLMNOPQRSTUVWXYZ
            Random randNum = new Random();
            char[] chars = new char[7];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < 7; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            String password = chars.ToString();
            return new string(chars);
        }
        #endregion RandomPassword
    }
}