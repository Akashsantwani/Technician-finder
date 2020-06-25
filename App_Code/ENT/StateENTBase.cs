using System.Data.SqlTypes;

/// <summary>
/// Summary description for StateENTBase
/// </summary>
namespace WorkerFinder.ENT
{
    public abstract class StateENTBase
    {
        protected SqlInt32 _StateID;
        public SqlInt32 StateID
        {
            get
            {
                return _StateID;
            }
            set
            {
                _StateID = value;
            }
        }

        protected SqlString _StateName;
        public SqlString StateName
        {
            get
            {
                return _StateName;
            }
            set
            {
                _StateName = value;
            }
        }
    }
}