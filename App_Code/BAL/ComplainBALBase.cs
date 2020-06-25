using System;
using System.Data;
using System.Data.SqlTypes;
using WorkerFinder.DAL;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for ComplainBALBase
/// </summary>
namespace WorkerFinder.BAL
{
    public abstract class ComplainBALBase
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
            ComplainDAL dalComplain = new ComplainDAL();
            if (dalComplain.Insert(entComplain))
            {
                return true;
            }
            else
            {
                this.Message = dalComplain.Message;
                return false;
            }
        }
        #endregion Insert operation

        #region update operation

        public Boolean Update(ComplainENT entComplain)
        {
            ComplainDAL dalComplain = new ComplainDAL();
            if (dalComplain.Update(entComplain))
            {
                return true;
            }
            else
            {
                this.Message = dalComplain.Message;
                return false;
            }
        }
        #endregion update operation

        #region Delete operation

        public Boolean Delete(SqlInt32 ComplainID)
        {
            ComplainDAL dalComplain = new ComplainDAL();
            if (dalComplain.Delete(ComplainID))
            {
                return true;
            }
            else
            {
                this.Message = dalComplain.Message;
                return false;
            }
        }
        #endregion Delete operation

        #region select operation

        public DataTable SelectAll()
        {
            ComplainDAL dalComplain = new ComplainDAL();
            return dalComplain.SelectAll();
        }

        //public ComplainENT SelectByPK(SqlInt32 ComplainID)
        //{
        //    ComplainDAL dalComplain = new ComplainDAL();
        //    return dalComplain.SelectByPK(ComplainID);
        //}

        //public DataTable SelectDropDownList()
        //{
        //    ComplainDAL dalComplain = new ComplainDAL();
        //    return dalComplain.SelectDropDownList();
        //}

        #endregion select operation
    }
}