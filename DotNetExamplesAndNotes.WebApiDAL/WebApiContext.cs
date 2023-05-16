using Microsoft.EntityFrameworkCore;

namespace DotNetExamplesAndNotes.WebApiDAL;

public class WebApiContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Post> Posts { get; set; }

    public WebApiContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=webapidb.db");
    }
}
