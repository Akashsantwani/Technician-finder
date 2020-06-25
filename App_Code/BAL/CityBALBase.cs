using System;
using System.Data;
using System.Data.SqlTypes;
using WorkerFinder.DAL;
using WorkerFinder.ENT;

/// <summary>
/// Summary description for CityBALBase
/// </summary>
namespace WorkerFinder.BAL
{
    public abstract class CityBALBase
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

        public Boolean Insert(CityENT entCity)
        {
            CityDAL cityDAL = new CityDAL();
            if (cityDAL.Insert(entCity))
            {
                return true;
            }
            else
            {
                this.Message = cityDAL.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region Update Operation

        public Boolean Update(CityENT entCity)
        {
            CityDAL cityDAL = new CityDAL();
            if (cityDAL.Update(entCity))
            {
                return true;
            }
            else
            {
                this.Message = cityDAL.Message;
                return false;
            }
        }

        #endregion Update Operation

        #region Delete Operation

        public Boolean Delete(SqlInt32 CityID)
        {
            CityDAL cityDAL = new CityDAL();
            if (cityDAL.Delete(CityID))
            {
                return true;
            }
            else
            {
                this.Message = cityDAL.Message;
                return false;
            }
        }

        #endregion Delete Operation


        #region Select Operations

        public DataTable SelectAll()
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectAll();
        }

        public CityENT SelectByPK(SqlInt32 CityID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectByPK(CityID);
        }

        public DataTable SelectDropDownList()
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectDropDownList();
        }

        #endregion Select Operations
    }
}