using Microsoft.EntityFrameworkCore;

namespace Recordboxed.Data
{
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Record> Records { get; set;}
    }
}