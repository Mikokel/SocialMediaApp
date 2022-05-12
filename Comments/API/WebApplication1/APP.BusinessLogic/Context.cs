using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.BusinessLogic
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public virtual DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.ID).HasColumnName("id");

                entity.Property(e => e.TimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("TimeStamp")
                   .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Body)
                      .HasColumnName("body")
                      .HasMaxLength(255);

            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
