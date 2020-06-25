using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using WorkerFinder.DAL;

/// <summary>
/// Summary description for JobTypeBAL
/// </summary>
namespace WorkerFinder.BAL
{
    public class JobTypeBAL : JobTypeBALBase
    {
        public List<String> SelectByText(SqlString JobTypeName)
        {
            JobTypeDAL dalJobType = new JobTypeDAL();
            return dalJobType.SelectByText(JobTypeName);
        }
    }
}