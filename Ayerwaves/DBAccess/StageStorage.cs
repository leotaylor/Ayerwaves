using Ayerwaves.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ayerwaves.DBAccess
{
    public class StageStorage
    {
        private string ConnectionString;

        public StageStorage(IConfiguration config)
        {
            ConnectionString = config.GetSection("ConnectionString").Value;
        }

        public List<Stage> GetAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.Query<Stage>(@"Select * from Stage");

                return result.ToList();
            }
        }

        public Stage GetById(int Id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.QueryFirst<Stage>(@"select *
                                                            from Stage
                                                            where id = @Id", new { Id });
                return result;
            }
        }

        public bool Add(Stage stage)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.Execute(@"INSERT into dbo.Stage (StageName)
                                                    Values (@StageName )", stage);

                return result == 1;
            }
        }

        public bool UpdateStage(int id, Stage stage)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                stage.id = id;

                var result = connection.Execute(@"UPDATE Stage
                                                    SET [StageName] = @StageName
                                                    WHERE id = @id", stage);
                return result == 1;
            }
        }

        public bool DeleteStage(int Id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.Execute(@"DELETE FROM Stage
                                                    WHERE id = @id", new { id = Id });

                return result == 1;
            }
        }
    }
}
