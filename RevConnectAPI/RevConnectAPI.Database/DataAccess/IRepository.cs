using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevConnectAPI.Database
{
    public interface IRepository
    {
        #region Comment Methods
        /* 
            <summary>

        Queries database for ALL records of comments in database into list.
        
            </summary>
        */
        List<Comment> GetAllComments();
        /* 
            <summary>

        Queries database for ALL records of comments under a POST in database into list.
        
            </summary>
        */
        List<Comment> GetAllCommentsForPost(int PostID);
        /* 
            <summary>

        Queries database for one record of a comment in database dependent on id. 
        
            </summary>
        */
        Comment? GetCommentById(int id);
        /* 
            <summary>

        Queries database for one record of a comment in database dependent on userID
        
            </summary>
        */
        Comment? GetCommentByUserID(int userID);

        /* 
            <summary>

        Allows to put in a Comment object to update.
        
            </summary>
        */
        void UpdateOneComment(Comment changes);

        /* 
            <summary>

        Allows an insertion of a comment object.
        
            </summary>
         */
        void InsertOneComment(Comment comment);
        /* 
            <summary>

        Delete a comment by given id. Returns true if comment was found and could be deleted.
        Returns false, if comment with id is not in database.
        
            </summary>
         */
        bool DeleteComment(int id);
        #endregion
        #region Like Methods
        /* 
            <summary>

        Queries database for ALL records of likes under a POST in the database into a list.
        
            </summary>
        */
        List<Like> GetAllLikes();
        /* 
            <summary>

        Queries database to post for a record of a like under a POST in the database into a list.
        
            </summary>
        */
        bool PostALikeForPost(Like like);
        bool DeleteALikeForPost(Like like);
        #endregion
        #region Post Methods
        /* 
            <summary>

        Queries database for 5 most recent posts in database into a list.
        
            </summary>
        */
        List<Post>? GetFivePosts();
        /* 
            <summary>

        Queries database for ALL records of posts in database into a list.
        
            </summary>
        */
        List<Post> GetAllPosts();
        /* 
            <summary>

        Queries database for one record of a post from the database by postId.
        
            </summary>
        */
        Post? GetPostById(int id);
        /* 
            <summary>

        Queries database for ALL records of posts from the database by UserId.
        
            </summary>
        */
        List<Post>? GetPostsByUserId(int userId);
        /* 
            <summary>

        Queries database to insert a post into the database with no return.
        
            </summary>
        */
        void InsertPost(Post post);
        /* 
            <summary>

        Queries database to delete a post by the postId. If post is not in database, return false. Else, return true.
        
            </summary>
        */
        bool DeletePostById(int id);
        /* 
            <summary>

        Queries database to update a post by the postId. If post is not in database, return false. Else, return true.
        
            </summary>
        */
        bool UpdatePost(Post post);
        #endregion
    }
}