using System.Data.SqlTypes;

/// <summary>
/// Summary description for WorkENTBase
/// </summary>
namespace WorkerFinder.ENT
{
    public abstract class WorkENTBase
    {
        protected SqlInt32 _WorkID;
        public SqlInt32 WorkID
        {
            get
            {
                return _WorkID;
            }
            set
            {
                _WorkID = value;
            }
        }

        protected SqlInt32 _ClientID;
        public SqlInt32 ClientID
        {
            get
            {
                return _ClientID;
            }
            set
            {
                _ClientID = value;
            }
        }

        protected SqlInt32 _CustomerID;
        public SqlInt32 CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }

        protected SqlDateTime _Workdate;
        public SqlDateTime Workdate
        {
            get
            {
                return _Workdate;
            }
            set
            {
                _Workdate = value;
            }
        }

    }
}