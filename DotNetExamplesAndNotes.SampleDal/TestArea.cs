using Microsoft.EntityFrameworkCore;

namespace DotNetExamplesAndNotes.SampleDal;

public class DalTestArea
{
    public async Task ExecuteAsync()
    {
        using var context = new SampleDbContext();

        // Prepare data
        await PrepareDataAsync(context);

        var normalJoined = await JoinAsync(context);

        var leftJoined = await LeftJoinAsync(context);
    }

    private static async Task<(Blog, Post)[]> JoinAsync(SampleDbContext context)
    {
        var joined = await context.Blogs
            .Join(context.Posts, x => x.Id, x => x.BlogId, (b, p) => new { b, p })
            .ToArrayAsync();

        return joined
            .Select(x => (x.b, x.p))
            .ToArray();
    }

    private static async Task<(Blog, Post)[]> LeftJoinAsync(SampleDbContext context)
    {
        var query =
            from blog in context.Blogs
            join post in context.Posts on blog.Id equals post.BlogId into gj
            from subpost in gj.DefaultIfEmpty()
            select new
            {
                blog,
                subpost,
            };

        return (await query.ToArrayAsync())
            .Select(x => (x.blog, x.subpost))
            .ToArray();
    }

    private static async Task PrepareDataAsync(SampleDbContext context)
    {
        context.Blogs.Add(
            new Blog
            {
                Id = Guid.NewGuid(),
                Name = "blog with posts",
                Posts = new List<Post>
                {
            new Post
            {
                Id = Guid.NewGuid(),
                Name = "some post",
            }
                }
            });

        context.Blogs.Add(
            new Blog
            {
                Id = Guid.NewGuid(),
                Name = "blog without posts",
            });

        await context.SaveChangesAsync();
    }
}
