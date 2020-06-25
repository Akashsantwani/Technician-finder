using System;
using System.Data;
using System.Data.SqlTypes;
using WorkerFinder.DAL;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for JobTypeBALBase
/// </summary>
namespace WorkerFinder.BAL
{
    public abstract class JobTypeBALBase
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

        public Boolean Insert(JobTypeENT entJobType)
        {
            JobTypeDAL dalJobType = new JobTypeDAL();
            if (dalJobType.Insert(entJobType))
            {
                return true;
            }
            else
            {
                this.Message = dalJobType.Message;
                return false;
            }
        }
        #endregion Insert operation

        #region update operation

        public Boolean Update(JobTypeENT entJobType)
        {
            JobTypeDAL dalJobType = new JobTypeDAL();
            if (dalJobType.Update(entJobType))
            {
                return true;
            }
            else
            {
                this.Message = dalJobType.Message;
                return false;
            }
        }
        #endregion update operation

        #region Delete operation

        public Boolean Delete(SqlInt32 JobTypeID)
        {
            JobTypeDAL dalJobType = new JobTypeDAL();
            if (dalJobType.Delete(JobTypeID))
            {
                return true;
            }
            else
            {
                this.Message = dalJobType.Message;
                return false;
            }
        }
        #endregion Delete operation

        #region select operation

        public DataTable SelectAll()
        {
            JobTypeDAL dalJobType = new JobTypeDAL();
            return dalJobType.SelectAll();
        }

        public JobTypeENT SelectByPK(SqlInt32 JobTypeID)
        {
            JobTypeDAL dalJobType = new JobTypeDAL();
            return dalJobType.SelectByPK(JobTypeID);
        }

        public DataTable SelectDropDownList()
        {
            JobTypeDAL dalJobType = new JobTypeDAL();
            return dalJobType.SelectDropDownList();
        }

        #endregion select operation
    }
}