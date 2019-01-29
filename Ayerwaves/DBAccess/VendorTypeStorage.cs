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
    public class VendorTypeStorage
    {
        private string ConnectionString;

        public VendorTypeStorage(IConfiguration config)
        {
            ConnectionString = config.GetSection("ConnectionString").Value;
        }

        public List<VendorType> GetAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.Query<VendorType>(@"Select * from VendorType");

                return result.ToList();
            }
        }

        public VendorType GetById(int Id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.QueryFirst<VendorType>(@"select *
                                                                from VendorType
                                                                where id = @Id", new { Id });
                return result;
            }
        }

        public bool Add(VendorType vendorType)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.Execute(@"INSERT into dbo.VendorType (VendorType)
                                                    Values (@TypeOfVendor )", vendorType);

                return result == 1;
            }
        }

        public bool UpdateVendorType(int id, VendorType vendorType)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                vendorType.id = id;

                var result = connection.Execute(@"UPDATE VendorType
                                                    SET [VendorType] = @TypeOfVendor
                                                    WHERE id = @id", vendorType);
                return result == 1;
            }
        }

        public bool DeleteVendorType(int Id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.Execute(@"DELETE FROM VendorType
                                                    WHERE id = @id", new { id = Id });

                return result == 1;
            }
        }
    }
}
