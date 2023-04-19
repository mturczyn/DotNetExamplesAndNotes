using DotNetExamplesAndNotes.WebApiDAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetExamplesAndNotes.WebApiDAL;

public static class DependencyInkection
{
    public static IServiceCollection AddDal(this IServiceCollection services)
    {
        return services
            .AddDbContext<WebApiContext>()
            .AddTransient<IPostsRepository, PostsRepository>()
            .AddTransient<IBlogsRepository, BlogsRepository>();
    }
}
