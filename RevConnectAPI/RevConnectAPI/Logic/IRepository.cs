using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Mvc;
using RevConnectAPI.DataClass;

namespace RevConnectAPI.Logic
{
    public interface IRepository
    {
        Task<IEnumerable<PostData>> ListOfPosts();

        Task<ContentResult> CreateNewPost(int? postID, string body, string date, string? image, int? userID);



    }
}
