using Microsoft.AspNetCore.Mvc;
using RevConnectAPI.Database;

namespace RevConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<CommentController> _logger;

        public CommentController(ILogger<CommentController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }


        // GET: api/<CommentController>
        [HttpGet]
        public ActionResult<List<Comment>> GetAllComments()
        {
            try
            {
                return _repository.GetAllComments();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error in retriving all comments");
                return StatusCode(500);
            }
        }
        // GET: api/<CommentController/3>
        [HttpGet("{postID}")]
        public ActionResult<List<Comment>> GetAllCommentsForPost(int postID)
        {
            try
            {
                return _repository.GetAllCommentsForPost(postID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error in retriving all comments for post");
                return StatusCode(500);
            }
        }

        // POST api/<CommentController>
        [HttpPost]
        public void Post([FromBody] Comment comment)
        {
            try
            {
                _repository.InsertOneComment(comment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in creating message");
            }
        }

        // PUT api/<CommentController>/
        [HttpPut]
        public void Put([FromBody] Comment changes)
        {
            try
            {
                _repository.UpdateOneComment(changes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in updated comment with id: {changes.commentID}");
            }

        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                if (_repository.DeleteComment(id)) 
                {
                    return StatusCode(200);
                }
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in deleting comment with id: {id}");
                return StatusCode(500);
            }
        }
    }
}