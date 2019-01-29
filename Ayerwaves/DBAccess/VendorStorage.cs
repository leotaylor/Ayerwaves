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

        public Vendor GetById(int Id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.QueryFirst<Vendor>(@"SELECT
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
                                                            ON vt.id = v.[Type]
                                                            WHERE v.id = @Id", new { Id });
                return result;
            }
        }

        public bool Add(Vendor vendor)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.Execute(@"INSERT into dbo.Vendor ([Name], [Type], [Description], Requirements, ContactName, ContactEmail, ContactPhone )
                                                    Values (@Name, @Type, @Description, @Requirements, '@ContactName', @ContactEmail, @ContactPhone )", vendor);

                return result == 1;
            }
        }

        public bool UpdateVendor(int id, Vendor vendor)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                vendor.id = id;

                var result = connection.Execute(@"UPDATE Vendor
                                                    SET [Name] = @Name
                                                        ,[Type] = @Type
                                                        ,[Description] = @Description
                                                        ,Requirements = @Requirements
                                                        ,ContactName = @ContactName
                                                        ,ContactEmail = @ContactEmail
                                                        ,ContactPhone = @ContactPhone
                                                    WHERE id = @id", vendor);
                return result == 1;
            }
        }

        public bool DeleteVendor(int Id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.Execute(@"DELETE FROM Vendor
                                                    WHERE id = @id", new { id = Id });

                return result == 1;
            }
        }
    }
}
