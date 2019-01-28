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

                var result = connection.Query<Artist>(@"Select 
                                                        A.id,
	                                                    A.[Name],
	                                                    G.GenreName,
	                                                    A.Description,
	                                                    S.StageName,
	                                                    A.[Day],
	                                                    A.imageLink
                                                    from Artist A
                                                    JOIN Genre G
                                                    ON A.Genre = G.id
                                                    JOIN Stage S
                                                    on A.Stage = S.id");

                return result.ToList();
            }
        }

        public Artist GetById(int Id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.QueryFirst<Artist>(@"SELECT
                                                                A.id,
	                                                            A.[Name],
	                                                            G.GenreName,
	                                                            A.Description,
	                                                            S.StageName,
	                                                            A.[Day],
	                                                            A.imageLink
                                                            from Artist A
                                                            JOIN Genre G
                                                            ON A.Genre = G.id
                                                            JOIN Stage S
                                                            on A.Stage = S.id
                                                            WHERE A.id = @Id", new { Id });
                return result;
            }
        }

        public bool Add(Artist artist)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.Execute(@"INSERT into dbo.Artist ([Name], Genre, [Description], Stage, [Day], imageLink )
                                                    Values (@Name, @GenreName, @Description, @StageName, '@Day', @imageLink )", artist);

                return result == 1;
            }
        }

        public bool UpdateArtist(int id, Artist artist)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                artist.id = id;

                var result = connection.Execute(@"UPDATE Artist
                                                    SET [Name] = @Name
                                                        ,Genre = @GenreName
                                                        ,[Description] = @Description
                                                        ,Stage = @StageName
                                                        ,[Day] = @Day
                                                        ,imageLink = @imageLink
                                                    WHERE id = @id", artist);
                return result == 1;
            }
        }

        public bool DeleteArtist(int Id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result = connection.Execute(@"DELETE FROM Artist
                                                    WHERE id = @id", new { id = Id });

                return result == 1;
            }
        }
    }
}
