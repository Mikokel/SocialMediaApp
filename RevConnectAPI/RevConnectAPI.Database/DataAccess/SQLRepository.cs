using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevConnectAPI.Database
{
    public class SQLRepository : IRepository
    {
        private readonly RevConnectContext _context;
        public SQLRepository(RevConnectContext context)
        {
            _context = context;
        }
        #region Comment Methods
        public List<Comment> GetAllComments()
        {
            return _context.Comments.ToList();
        }
        public List<Comment> GetAllCommentsForPost(int PostID)
        {
            return _context.Comments.Where(x => x.postID == PostID).ToList();
        }
        public Comment? GetCommentById(int id)
        {
            return _context.Comments.Find(id);
        }
        public Comment? GetCommentByUserID(int userID)
        {
            return _context.Comments.FirstOrDefault(x => x.userID == userID);
        }
        public void UpdateOneComment(Comment changes)
        {
            Comment? RetrivedComment = GetCommentById(changes.commentID);
            if (RetrivedComment != null)
            {
                RetrivedComment.body = changes.body;
                RetrivedComment.date = DateTime.Now.ToShortDateString();
                _context.SaveChanges();
            }

            
        }
        public void InsertOneComment(Comment comment)
        {
            _context.Add(comment);
            _context.SaveChanges();
        }
        public bool DeleteComment(int id)
        {
            Comment? comment = _context.Comments.Find(id);
            if (comment != null)
            {
                _context.Remove(comment);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion
        #region Like Methods
        public List<Like> GetAllLikes()
        {
            return _context.Likes.ToList();
        }

        public bool PostALikeForPost(Like like)
        {
            like.commentID = null;
            like.likeID = null;
            if(_context.Likes.Where(x => x.postID == like.postID && x.userID == like.userID) == null)
            {
                _context.Likes.Add(like);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteALikeForPost(Like like)
        {
            like.commentID = null;
            if (_context.Likes.Where(x => x.postID == like.postID && x.userID == like.userID) != null)
            {
                _context.Likes.Remove(like);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion
        #region Post Methods
        public bool DeletePostById(int id)
        {
            Post? post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Remove(post);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        public Post? GetPostById(int id)
        {
            return _context.Posts.Find(id);
        }
        public List<Post>? GetFivePosts()
        {
            List<Post>? AllPosts = _context.Posts.ToList();
            List<Post> Post5 = new List<Post>(5);
            if (AllPosts != null)
            {
                if(AllPosts.Count < 5)
                {
                    return AllPosts;
                }
                for (int i = 0; i < 5; i++)
                {
                    Post5.Add(AllPosts[i]);
                }
            }
            return Post5;
        }

        public List<Post>? GetPostsByUserId(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.userID == userId).userPosts;
        }

        public void InsertPost(Post post)
        {
            _context.Add(post);
            _context.SaveChanges();
        }

        public bool UpdatePost(Post changes)
        {
            Post? RetrivedPost = GetPostById(changes.postID);
            if (RetrivedPost != null)
            {
                RetrivedPost = changes;
                RetrivedPost.date = DateTime.Now.ToShortDateString();
                return true;
            }
            return false;
        }
        #endregion
    }
}