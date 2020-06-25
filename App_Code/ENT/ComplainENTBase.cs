using System.Data.SqlTypes;

/// <summary>
/// Summary description for ComplainENTBase
/// </summary>
namespace WorkerFinder.ENT
{
    public abstract class ComplainENTBase
    {
        protected SqlInt32 _ComplainID;
        public SqlInt32 ComplainID
        {
            get
            {
                return _ComplainID;
            }
            set
            {
                _ComplainID = value;
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

        protected SqlDateTime _ComplainDate;
        public SqlDateTime ComplainDate
        {
            get
            {
                return _ComplainDate;
            }
            set
            {
                _ComplainDate = value;
            }
        }


        protected SqlString _ComplainMessage;
        public SqlString ComplainMessage
        {
            get
            {
                return _ComplainMessage;
            }
            set
            {
                _ComplainMessage = value;
            }
        }

    }
}