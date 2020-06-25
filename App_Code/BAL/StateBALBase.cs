using System;
using System.Data;
using System.Data.SqlTypes;
using WorkerFinder.DAL;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for StateBALBase
/// </summary>
namespace WorkerFinder.BAL
{
    public abstract class StateBALBase
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

        public Boolean Insert(StateENT entState)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.Insert(entState))
            {
                return true;
            }
            else
            {
                this.Message = dalState.Message;
                return false;
            }
        }
        #endregion Insert operation

        #region update operation

        public Boolean Update(StateENT entState)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.Update(entState))
            {
                return true;
            }
            else
            {
                this.Message = dalState.Message;
                return false;
            }
        }
        #endregion update operation

        #region Delete operation

        public Boolean Delete(SqlInt32 StateID)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.Delete(StateID))
            {
                return true;
            }
            else
            {
                this.Message = dalState.Message;
                return false;
            }
        }
        #endregion Delete operation

        #region select operation

        public DataTable SelectAll()
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectAll();
        }

        public StateENT SelectByPK(SqlInt32 StateID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectByPK(StateID);
        }

        public DataTable SelectDropDownList()
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectDropDownList();
        }

        #endregion select operation
    }
}