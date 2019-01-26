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
    public class ArtistStorage
    {
        private string ConnectionString;

        public ArtistStorage(IConfiguration config)
        {
            ConnectionString = config.GetSection("ConnectionString").Value;
        }

        public List<Artist> GetAll()
        {
            using(var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.Query<Artist>(@"Select * FROM Artist");

                return result.ToList();
            }
        }
    }
}
