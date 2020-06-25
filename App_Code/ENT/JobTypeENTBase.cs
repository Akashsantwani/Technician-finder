using System.Data.SqlTypes;

/// <summary>
/// Summary description for JobTypeENTBase
/// </summary>
namespace WorkerFinder.ENT
{
    public abstract class JobTypeENTBase
    {
        protected SqlInt32 _JobTypeID;
        public SqlInt32 JobTypeID
        {
            get
            {
                return _JobTypeID;
            }
            set
            {
                _JobTypeID = value;
            }
        }

        protected SqlString _JobTypeName;
        public SqlString JobTypeName
        {
            get
            {
                return _JobTypeName;
            }
            set
            {
                _JobTypeName = value;
            }
        }
    }
}