using ASPTryParsing.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPTryParsing.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<News> NewsData { get; set; }

    }
}
