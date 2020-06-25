using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Net;
using System.Net.Mail;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for CustomerDAL
/// </summary>
namespace WorkerFinder.DAL
{
    public class CustomerDAL : CustomerDALBase
    {
        #region SelectByphonePassword
        public DataTable SelectByphonePassword(SqlString PhoneNo, SqlString Password)
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
                        objCmd.CommandText = "PR_Customer_SelectByPhonePassword";
                        objCmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                        objCmd.Parameters.AddWithValue("@Password", Password);
                        #endregion prepare command
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
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
        #endregion SelectByphonePassword

        #region SelectPasswordByPK
        public String SelectPasswordByPK(SqlInt32 CustomerID)
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
                        objCmd.CommandText = "PR_Customer_SelectPasswordByPK";
                        objCmd.Parameters.AddWithValue("@CustomerID", CustomerID);
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
        public Boolean UpdatePasswordByPK(CustomerENT entCustomer)
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
                        objCmd.CommandText = "PR_Customer_UpdatePasswordByPK";
                        objCmd.Parameters.AddWithValue("@CustomerID", entCustomer.CustomerID);
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

        #endregion UpdatePasswordByPK

        #region selectByPhoneNo
        public CustomerENT SelectByPhoneNo(SqlString PhoneNo)
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
                        objCmd.CommandText = "PR_Customer_SelectByPhoneNo";
                        objCmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                        //objCmd.Parameters.AddWithValue("@CityID", CityID);
                        #endregion prepare command

                        #region read data and set control
                        //DataTable dt = new DataTable();
                        CustomerENT entCustomer = new CustomerENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            //dt.Load(objSDR);
                            while (objSDR.Read())
                            {
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                {
                                    entCustomer.Email = Convert.ToString(objSDR["Email"]);
                                }
                                if (!objSDR["CustomerID"].Equals(DBNull.Value))
                                {
                                    entCustomer.CustomerID = Convert.ToInt32(objSDR["CustomerID"]);
                                }
                                if (!objSDR["CustomerName"].Equals(DBNull.Value))
                                {
                                    entCustomer.CustomerName = Convert.ToString(objSDR["CustomerName"]);
                                }
                            }
                        }
                        return entCustomer;

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

        public Boolean SendResetPasswordMail(CustomerENT entcustomer)  //Int32 ClientID, String ClientName, String Email
        {
            //String password = null;
            //password = RandomPassword();
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                mail.From = new MailAddress("akashsantwani2014@gmail.com");
                mail.To.Add(new MailAddress(entcustomer.Email.ToString()));
                mail.Subject = "Reset Password";
                //mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                //string htmlbody = "code is here";
                mail.Body = "<p><b><h3>hello " + entcustomer.CustomerName.ToString() + ",</h3></b><br>welcome to worker finder support<br>we have received your request for passoword reset and your new password is " + entcustomer.Password.ToString() + "</p>";
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