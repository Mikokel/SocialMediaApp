using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RevConnectAPI.Database.DataAccess;
using RevConnectAPI.DataClass;
using RevConnectAPI.Logic;
using RevConnectAPI.Database.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RevConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class PostFeedController : ControllerBase
    {
        private readonly RevConnectAPIContext _context;
        private readonly IRepository _repository;
        //private readonly ILogger<PostFeedController> _logger;
        //private readonly HttpClient httpClientInstance = new HttpClient();

        public PostFeedController(RevConnectAPIContext context, IRepository repository/*, ILogger<PostFeedController> logger*/)
        {
            _context = context;
            _repository = repository;
            //_logger = logger;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<Post>> GetListOfPosts()
        //public IEnumerable<PostData> Get()
        {

           
            return (_context.Post.ToList());


            //IEnumerable<PostData> posts;
            //try
            //{
            //    posts = await _repository.ListOfPosts();
            //}
            //catch (SqlException ex)
            //{
            //    //_logger.LogError(ex, "SQL error while getting list of posts");
            //    return StatusCode(500);
            //}
            //return posts.ToList();

            //return new string[] { "value1", "value2" };

        }

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ValuesController>
        [HttpPost]
        //public void Post([FromBody] string value)
        public async Task<ActionResult<Post>> createPost(Post postname)
        {
            _context.Post.Add(postname);
            await _context.SaveChangesAsync();
            return Ok(postname);
        }

        //    // PUT api/<ValuesController>/5
        //    [HttpPut("{id}")]
        //    public void Put(int id, [FromBody] string value)
        //    {
        //    }

        //    // DELETE api/<ValuesController>/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id)
        //    {
        //    }
    }
}

