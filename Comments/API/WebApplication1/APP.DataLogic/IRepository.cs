using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP.BusinessLogic;

namespace APP.DataLogic
{
    public interface IRepository
    {
        #region // Comment Methods
        List<Comment> GetAllComments();
        Comment? GetCommentById(int id);
        bool DeleteCommentById(int id);
        bool InsertComment(Comment comment);

        #endregion

    }
}
