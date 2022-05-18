using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using test.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;




namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class test_image : Controller
    {

        CloudStorageAccount cloudstorageaccount = CloudStorageAccount.Parse("connection string");
        private IWebHostEnvironment _environment;
        private readonly dbcontex _context;
        public test_image(IWebHostEnvironment environment, dbcontex context)
        {
            _environment = environment;
            _context = context;
        }



        [HttpPost("images")]
        public async Task<ActionResult<image_ID>> upload([FromQuery] string Auth0_ID, IFormFile postedFile)
        {

            /* var saveimages = Path.Combine(_environment.WebRootPath, "images", postedFile.FileName);

             using (var uploading = new FileStream(saveimages, FileMode.Create))
             {
                 postedFile.CopyTo(uploading);
             }
 */


            var image = new image_ID
            {
                Auth0_ID = Auth0_ID,
                path = $"https://imagesprofile1.blob.core.windows.net/image/{Auth0_ID}"
            };

            var user = _context.images_test.Where(image => image.Auth0_ID == Auth0_ID).FirstOrDefault();

            if (user == null)
            {
                _context.images_test.Add(image);
                await _context.SaveChangesAsync();
            }


            var cloudBlobClient = cloudstorageaccount.CreateCloudBlobClient();
            var container = cloudBlobClient.GetContainerReference("image");

            var CloudBlockBlob = container.GetBlockBlobReference(Auth0_ID);
            CloudBlockBlob.Properties.ContentType = postedFile.ContentType;
            await CloudBlockBlob.UploadFromStreamAsync(postedFile.OpenReadStream());






            return Ok("you got it");
        }


        [HttpGet("pet")]
        public async Task<ActionResult<image_ID>> Getimage(string Auth0_ID)
        {


            var image = _context.images_test.Where(image => image.Auth0_ID == Auth0_ID);




            return Ok(image);
        }

        [HttpPut("edit")]
        public async Task<ActionResult<image_ID>> edit([FromQuery] string Auth0_ID, IFormFile postedFile)
        {



            var user = _context.images_test.Where(image => image.Auth0_ID == Auth0_ID).FirstOrDefault();
            user.path = $"https://imagesprofile1.blob.core.windows.net/image/{postedFile.FileName}";

            await _context.SaveChangesAsync();
            var cloudBlobClient = cloudstorageaccount.CreateCloudBlobClient();
            var container = cloudBlobClient.GetContainerReference("image");

            var CloudBlockBlob = container.GetBlockBlobReference(postedFile.FileName);
            CloudBlockBlob.Properties.ContentType = postedFile.ContentType;
            await CloudBlockBlob.UploadFromStreamAsync(postedFile.OpenReadStream());






            return Ok("you got it");
        }




    }
}
