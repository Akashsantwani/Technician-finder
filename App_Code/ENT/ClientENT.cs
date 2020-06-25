using System.Data.SqlTypes;

/// <summary>
/// Summary description for ClientENT
/// </summary>
namespace WorkerFinder.ENT
{
    public class ClientENT : ClientENTBase
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