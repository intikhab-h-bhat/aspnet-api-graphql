using Microsoft.EntityFrameworkCore;
using WebApi.Graphql.Model;

namespace WebApi.Graphql.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Books> Books { get; set; }

    }
}
