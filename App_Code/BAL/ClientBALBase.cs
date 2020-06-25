using System;
using System.Data;
using System.Data.SqlTypes;
using WorkerFinder.DAL;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for ClientBALBase
/// </summary>
namespace WorkerFinder.BAL
{
    public abstract class ClientBALBase
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
            ClientDAL dalClient = new ClientDAL();
            if (dalClient.Insert(entClient))
            {
                return true;
            }
            else
            {
                this.Message = dalClient.Message;
                return false;
            }
        }
        #endregion Insert operation

        #region update operation

        public Boolean Update(ClientENT entClient)
        {
            ClientDAL dalClient = new ClientDAL();
            if (dalClient.Update(entClient))
            {
                return true;
            }
            else
            {
                this.Message = dalClient.Message;
                return false;
            }
        }
        #endregion update operation

        #region Delete operation

        public Boolean Delete(SqlInt32 ClientID)
        {
            ClientDAL dalClient = new ClientDAL();
            if (dalClient.Delete(ClientID))
            {
                return true;
            }
            else
            {
                this.Message = dalClient.Message;
                return false;
            }
        }
        #endregion Delete operation

        #region select operation

        public DataTable SelectAll()
        {
            ClientDAL dalClient = new ClientDAL();
            return dalClient.SelectAll();
        }

        public ClientENT SelectByPK(SqlInt32 ClientID)
        {
            ClientDAL dalClient = new ClientDAL();
            return dalClient.SelectByPK(ClientID);
        }

        public DataTable SelectDropDownList()
        {
            ClientDAL dalClient = new ClientDAL();
            return dalClient.SelectDropDownList();
        }

        #endregion select operation
    }
}