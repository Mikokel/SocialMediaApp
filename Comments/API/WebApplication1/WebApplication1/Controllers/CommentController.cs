using Microsoft.AspNetCore.Mvc;
using APP.BusinessLogic;
using APP.DataLogic;

namespace APP.API.Controllers
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


        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public ActionResult<Comment?> GetCommentById(int id)
        {
            try
            {
                return _repository.GetCommentById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error in getting comment with id: {id}");
                return StatusCode(500);
            }
        }

        // POST api/<MessageController>
        [HttpPost]
        public StatusCodeResult Post([FromBody] Comment comment)
        {
            try
            {
                if (_repository.InsertComment(comment))
                {
                    return StatusCode(200);
                }
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in creating message");
                return StatusCode(500);
            }
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                if (_repository.DeleteCommentById(id))
                {
                    return StatusCode(200);
                }
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in deleteing comment with id: {id}");
                return StatusCode(500);
            }

        }
    }
}
