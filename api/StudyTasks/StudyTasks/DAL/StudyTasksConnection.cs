using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace StudyTasks.DAL
{
    public class StudyTasksConnection
    {
        private readonly IConfiguration _config;
        private readonly IDbConnection connection;
        public StudyTasksConnection(IConfiguration config)
        {
            _config = config;
            
        }

    }
}
