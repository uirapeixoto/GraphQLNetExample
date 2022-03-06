using GraphQLNetExample.Notes;
using Microsoft.EntityFrameworkCore;

namespace GraphQLNetExample.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("Note");

                entity.HasKey("Id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                    entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

            });
        }
    }
}