using System.Configuration;

/// <summary>
/// Summary description for DatabaseConfig
/// </summary>
namespace WorkerFinder.DAL
{
    public class DatabaseConfig
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["WorkerFinderConnectionString"].ConnectionString.ToString();
    }
}