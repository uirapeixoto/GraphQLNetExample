using GraphQLNetExample.Notes;
using Microsoft.EntityFrameworkCore;

namespace GraphQLNetExample.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }
    }
}