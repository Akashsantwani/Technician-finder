using System.Data;
using System.Data.SqlTypes;
using WorkerFinder.DAL;

/// <summary>
/// Summary description for ComplainBAL
/// </summary>
namespace WorkerFinder.BAL
{
    public class ComplainBAL : ComplainBALBase
    {
        public DataTable SelectByClientID(SqlInt32 ClientID)
        {
            ComplainDAL dalComplain = new ComplainDAL();
            return dalComplain.SelectByClientID(ClientID);
        }
    }
}