using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DotNetExamplesAndNotes.SampleDal;

public class SampleDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=.;Database=SampleDatabase;Integrated Security=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=True");
    }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Blog> Blogs { get; set; }
}
