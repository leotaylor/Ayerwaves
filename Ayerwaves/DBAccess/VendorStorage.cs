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
    public class VendorStorage
    {
        private string ConnectionString;

        public VendorStorage(IConfiguration config)
        {
            ConnectionString = config.GetSection("ConnectionString").Value;
        }

        public List<Vendor> GetAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.Query<Vendor>(@"select 
	                                                        v.id,
	                                                        v.[Name],
	                                                        vt.VendorType as [Type],
	                                                        v.[Description],
	                                                        v.Requirements,
	                                                        v.ContactName,
	                                                        v.ContactEmail,
	                                                        v.ContactPhone
                                                        from Vendor v
                                                        Join VendorType vt
                                                        ON vt.id = v.[Type]");

                return result.ToList();
            }
        }
    }
}
