using System;
using System.Data;
using System.Data.SqlTypes;
using WorkerFinder.DAL;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for CustomerBALBase
/// </summary>
namespace WorkerFinder.BAL
{
    public abstract class CustomerBALBase
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
            CustomerDAL dalCustomer = new CustomerDAL();
            if (dalCustomer.Insert(entCustomer))
            {
                return true;
            }
            else
            {
                this.Message = dalCustomer.Message;
                return false;
            }
        }
        #endregion Insert operation

        #region update operation

        public Boolean Update(CustomerENT entCustomer)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            if (dalCustomer.Update(entCustomer))
            {
                return true;
            }
            else
            {
                this.Message = dalCustomer.Message;
                return false;
            }
        }
        #endregion update operation

        #region Delete operation

        public Boolean Delete(SqlInt32 CustomerID)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            if (dalCustomer.Delete(CustomerID))
            {
                return true;
            }
            else
            {
                this.Message = dalCustomer.Message;
                return false;
            }
        }
        #endregion Delete operation

        #region select operation

        public DataTable SelectAll()
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.SelectAll();
        }

        public CustomerENT SelectByPK(SqlInt32 CustomerID)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.SelectByPK(CustomerID);
        }

        public DataTable SelectDropDownList()
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.SelectDropDownList();
        }

        #endregion select operation
    }
}