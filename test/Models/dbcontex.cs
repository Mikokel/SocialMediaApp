using Microsoft.EntityFrameworkCore;

namespace test.Models
{
    public class dbcontex : DbContext
    {
        public dbcontex(DbContextOptions<dbcontex> options) : base(options) { }
        public DbSet<image_ID> images_test { get; set; }


    }
}