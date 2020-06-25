using System.Data;
using System.Data.SqlTypes;
using WorkerFinder.DAL;

/// <summary>
/// Summary description for CityBAL
/// </summary>
namespace WorkerFinder.BAL
{
    public class CityBAL : CityBALBase
    {
        public DataTable SelectDropDownListByStateID(SqlInt32 StateID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectDropDownListByStateID(StateID);
        }
    }
}