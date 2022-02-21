using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using StudyTasks.Models;

namespace StudyTasks.DAL
{
    public class StudyTasksProvider : IProvideStudyTasks
    {
        //private readonly IConfiguration _configuration;
        private IDbConnection connection;
        private readonly string _connString = "Data Source=DESKTOP-TC5URPS;Initial Catalog=StudyTasks;Integrated Security=SSPI;";

        public void InsertVocabulary(List<Vocabulary> words)
        {
            string query = @"INSERT INTO [StudyTasks].[dbo].[Vocabulary]
                               (
                                [Id]
                                ,[Word]
                                ,[GradeLevel])
                                VALUES (
                                @Id
                                ,@Word
                                ,@GradeLevel)";

            connection = new SqlConnection(_connString);
            using (connection)
            {
                connection.Open();
                foreach (var w in words)
                {
                    connection.Execute(query, w);
                }
                
                connection.Close();
            }
        }

        public List<string> GetVocabulary()
        {

            string query = @"SELECT Word FROM [StudyTasks].[dbo].[Vocabulary]";
            connection = new SqlConnection(_connString);
            using (connection)
            {
                connection.Open();

                var vocabulary = connection.Query<string>(query).ToList();
                connection.Close();
                return vocabulary;
            }
        }
    }
}
