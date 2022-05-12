using APP.BusinessLogic;

namespace APP.DataLogic
{
    public class SQLRepository : IRepository
    {
        private readonly Context _context;
        public SQLRepository(Context context)
        {
            _context = context;
        }

        #region // Comment Methods
        public bool InsertComment(Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCommentById(int id)
        {
            Comment? comment = GetCommentById(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public List<Comment> GetAllComments()
        {
            return _context.Comments.ToList();

        }

        public Comment? GetCommentById(int id)
        {
            return _context.Comments.FirstOrDefault(x => x.ID == id);

        }
        #endregion
    }
}