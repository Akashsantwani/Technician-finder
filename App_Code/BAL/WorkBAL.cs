using System.Data;
using System.Data.SqlTypes;
using WorkerFinder.DAL;

/// <summary>
/// Summary description for WorkBAL
/// </summary>
namespace WorkerFinder.BAL
{
    public class WorkBAL : WorkBALBase
    {
        public DataTable SelectByClientID(SqlInt32 ClientID)
        {
            WorkDAL dalWork = new WorkDAL();
            return dalWork.SelectByClientID(ClientID);
        }

        public DataTable SelectByCustomerID(SqlInt32 CustomerID)
        {
            WorkDAL dalWork = new WorkDAL();
            return dalWork.SelectByCustomerID(CustomerID);
        }
    }
}