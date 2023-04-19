namespace DotNetExamplesAndNotes.WebApiDAL.Repositories;

public interface IPostsRepository : IBaseRepository<Post> { }

public class PostsRepository : BaseRepository<Post>, IPostsRepository
{
    public PostsRepository(WebApiContext context) : base(context)
    {
    }
}
