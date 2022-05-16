using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RevConnectAPI.Database.Models;


namespace RevConnectAPI.Database.DataAccess
{
    public class RevConnectAPIContext : DbContext
    {
        public RevConnectAPIContext (DbContextOptions<RevConnectAPIContext> options)
            : base(options)
        {
        }

        public DbSet<RevConnectAPI.Database.Models.User>? User { get; set; }

        public DbSet<RevConnectAPI.Database.Models.Post>? Post { get; set; }

        public DbSet<RevConnectAPI.Database.Models.Comment>? Comment { get; set; }

        public DbSet<RevConnectAPI.Database.Models.Like>? Like { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("RevConnect");
        }


    }
}
