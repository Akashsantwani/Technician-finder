using System.Data.SqlTypes;

/// <summary>
/// Summary description for CustomerENT
/// </summary>
namespace WorkerFinder.ENT
{
    public class CustomerENT : CustomerENTBase
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
    }
}