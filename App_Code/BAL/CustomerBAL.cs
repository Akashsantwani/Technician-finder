using System;
using System.Data;
using System.Data.SqlTypes;
using WorkerFinder.DAL;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for CustomerBAL
/// </summary>
namespace WorkerFinder.BAL
{
    public class CustomerBAL : CustomerBALBase
    {
        public DataTable SelectByphonePassword(SqlString PhoneNo, SqlString Password)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.SelectByphonePassword(PhoneNo, Password);
        }

        public String SelectPasswordByPK(SqlInt32 CustomerID)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.SelectPasswordByPK(CustomerID);
        }

        #region update password operation

        public Boolean UpdatePasswordByPK(CustomerENT entCustomer)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            if (dalCustomer.UpdatePasswordByPK(entCustomer))
            {
                return true;
            }
            else
            {
                this.Message = dalCustomer.Message;
                return false;
            }
        }
        #endregion update password operation

        public CustomerENT SelectByPhoneNo(SqlString PhoneNo)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.SelectByPhoneNo(PhoneNo);
        }

        public Boolean SendResetPasswordMail(CustomerENT entcustomer)  //Int32 ClientID,String ClientName , String Email
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            if (dalCustomer.SendResetPasswordMail(entcustomer))  //ClientID,ClientName,Email
            {
                return true;
            }
            else
            {
                this.Message = dalCustomer.Message;
                return false;
            }
        }

        public String RandomPassword()
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.RandomPassword();
        }
    }
}