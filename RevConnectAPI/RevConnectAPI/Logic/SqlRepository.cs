using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RevConnectAPI.Database.Models;
using RevConnectAPI.DataClass;
using System.Text;

namespace RevConnectAPI.Logic
{
    public class SqlRepository : IRepository
    {
        // Fields
        public readonly string _connectionString;
        public readonly ILogger<SqlRepository> _logger;

        // Constructors
        public SqlRepository(string connectionString,
            ILogger<SqlRepository> logger)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            this._logger = logger;
        }



        public async Task<IEnumerable<PostData>> ListOfPosts()
        {
            List<PostData> returnList = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string SQLcmd_string = ("SELECT * FROM RevConnect.Post;");

            using SqlCommand SQLcmd = new(SQLcmd_string, connection);

            using SqlDataReader myReader = SQLcmd.ExecuteReader();



            while (myReader.Read())
            {
                var postID = myReader.GetInt32(0);
                var body = myReader.GetString(1);
                var date = myReader.GetString(2);
                var image = myReader.GetString(3);
                var userID = myReader.GetInt32(4);
                
                returnList.Add(new(postID, body, date, image, userID));
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed: ListOfPosts");

            return returnList;
        }


        public async Task<ContentResult> CreateNewPost(int? postID, string body, string date, string? image, int? userID)
        {
            //List<User> returnList = new();
            using SqlConnection connection2 = new(_connectionString);
            //User newUser = new();
            await connection2.OpenAsync();

            string cmdTxt =
              @"INSERT INTO [RevConnect].[Posts] ( [body] , [date], [image] ) 
                VALUES ( @body, @date, @image ); ";

            
            using SqlCommand SQLcmd = new(cmdTxt, connection2);

            SQLcmd.Parameters.AddWithValue("@body", body);
            SQLcmd.Parameters.AddWithValue("@date", date);
            SQLcmd.Parameters.AddWithValue("@image", image);

            SQLcmd.ExecuteNonQuery();

            await connection2.CloseAsync();
            _logger.LogInformation("New account has been created");
            return new ContentResult() { StatusCode = 201 };

        }



    }
}
