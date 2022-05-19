using Microsoft.AspNetCore.Mvc;
using RevConnectAPI.Database;

namespace RevConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<LikeController> _logger;

        public LikeController(ILogger<LikeController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }


        // GET: api/<LikeController>
        [HttpGet("{postID}")]
        public ActionResult<List<Like>> GetAllLikesFromPost(int postID)
        {
            try
            {
                return _repository.GetAllLikesForPost(postID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error in retriving all likes of post with id: {postID}");
                return StatusCode(500);
            }
        }

        // POST api/<CommentController>
        [HttpPost]
        public StatusCodeResult PostLikeToPost(Like like)
        {
            try
            {
                if(_repository.PostALikeForPost(like))
                {
                    return StatusCode(200);
                }
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in posting like to post with id and user with id respectively: {like.postID} , {like.userID}");
                return StatusCode(500);
            }
        }
  
        // DELETE api/<LikeController>/5
        [HttpDelete]
        public StatusCodeResult DeleteLikeFromPost(Like like)
        {
            try
            {
                if (_repository.DeleteALikeForPost(like))
                {
                    return StatusCode(200);
                }
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in deleting like from post with id and user with id respectively: {like.postID} , {like.userID}");
                return StatusCode(500);
            }
        }
    }
}