using System;
using System.Data;
using System.Data.SqlTypes;
using WorkerFinder.DAL;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for ClientBAL
/// </summary>
namespace WorkerFinder.BAL
{
    public class ClientBAL : ClientBALBase
    {
        public DataTable SelectByPhonePassword(SqlString PhoneNo, SqlString Password) // login
        {
            ClientDAL dalClient = new ClientDAL();
            return dalClient.SelectByPhonePassword(PhoneNo, Password);
        }

        public String SelectPasswordByPK(SqlInt32 ClientID)
        {
            ClientDAL dalClient = new ClientDAL();
            return dalClient.SelectPasswordByPK(ClientID);
        }

        public DataTable SelectByJobTypeID(SqlInt32 JobTypeID, SqlInt32 CityID)
        {
            ClientDAL dalClient = new ClientDAL();
            return dalClient.SelectByJobTypeID(JobTypeID, CityID);
        }

        #region update password operation

        public Boolean UpdatePasswordByPK(ClientENT entClient)
        {
            ClientDAL dalClient = new ClientDAL();
            if (dalClient.UpdatePasswordByPK(entClient))
            {
                return true;
            }
            else
            {
                this.Message = dalClient.Message;
                return false;
            }
        }
        #endregion update PhoneNo operation

        #region update PhoneNo operation

        public Boolean UpdatePhoneNoByPK(ClientENT entClient)
        {
            ClientDAL dalClient = new ClientDAL();
            if (dalClient.UpdatePhoneNoByPK(entClient))
            {
                return true;
            }
            else
            {
                this.Message = dalClient.Message;
                return false;
            }
        }
        #endregion update PhoneNo operation

        public ClientENT SelectByPhoneNo(SqlString PhoneNo)
        {
            ClientDAL dalClient = new ClientDAL();
            return dalClient.SelectByPhoneNo(PhoneNo);
        }

        public Boolean SendResetPasswordMail(ClientENT entclient)  //Int32 ClientID,String ClientName , String Email
        {
            ClientDAL dalClient = new ClientDAL();
            if (dalClient.SendResetPasswordMail(entclient))  //ClientID,ClientName,Email
            {
                return true;
            }
            else
            {
                this.Message = dalClient.Message;
                return false;
            }
        }

        public Boolean SendNewJobMail(ClientENT entclient, CustomerENT entcustomer)  //Int32 ClientID,String ClientName , String Email
        {
            ClientDAL dalClient = new ClientDAL();
            if (dalClient.SendNewJobMail(entclient, entcustomer))  //ClientID,ClientName,Email
            {
                return true;
            }
            else
            {
                this.Message = dalClient.Message;
                return false;
            }
        }

        public String RandomPassword()
        {
            ClientDAL dalClient = new ClientDAL();
            return dalClient.RandomPassword();
        }
    }
}