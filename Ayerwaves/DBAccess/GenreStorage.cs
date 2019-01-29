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
    public class GenreStorage
    {
        private string ConnectionString;

        public GenreStorage(IConfiguration config)
        {
            ConnectionString = config.GetSection("ConnectionString").Value;
        }

        public List<Genre> GetAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.Query<Genre>(@"Select * from Genre");

                return result.ToList();
            }
        }

        public Genre GetById(int Id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.QueryFirst<Genre>(@"select G.GenreName
                                                            from Genre G
                                                            where id = @Id", new { Id });
                return result;
            }
        }

        public bool Add(Genre genre)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.Execute(@"INSERT into dbo.Genre (GenreName)
                                                    Values (@GenreName )", genre);

                return result == 1;
            }
        }


    }
}
