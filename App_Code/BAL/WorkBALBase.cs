using System;
using System.Data;
using System.Data.SqlTypes;
using WorkerFinder.DAL;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for WorkBALBase
/// </summary>
namespace WorkerFinder.BAL
{
    public abstract class WorkBALBase
    {
        #region Local Variables
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

        #endregion Local Variables

        #region Insert Operation

        public Boolean Insert(WorkENT entWork)
        {
            WorkDAL dalWork = new WorkDAL();
            if (dalWork.Insert(entWork))
            {
                return true;
            }
            else
            {
                this.Message = dalWork.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region Update Operation

        public Boolean Update(WorkENT entWork)
        {
            WorkDAL dalWork = new WorkDAL();
            if (dalWork.Update(entWork))
            {
                return true;
            }
            else
            {
                this.Message = dalWork.Message;
                return false;
            }
        }

        #endregion Update Operation

        #region Delete Operation

        public Boolean Delete(SqlInt32 WorkID)
        {
            WorkDAL dalWork = new WorkDAL();
            if (dalWork.Delete(WorkID))
            {
                return true;
            }
            else
            {
                this.Message = dalWork.Message;
                return false;
            }
        }

        #endregion Delete Operation


        #region Select Operations

        public DataTable SelectAll()
        {
            WorkDAL dalWork = new WorkDAL();
            return dalWork.SelectAll();
        }

        public WorkENT SelectByPK(SqlInt32 WorkID)
        {
            WorkDAL dalWork = new WorkDAL();
            return dalWork.SelectByPK(WorkID);
        }

        #endregion Select Operations
    }
}