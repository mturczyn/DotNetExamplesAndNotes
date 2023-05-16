namespace DotNetExamplesAndNotes.WebApiDAL.Repositories;

public interface IBlogsRepository : IBaseRepository<Blog>
{
}

public class BlogsRepository : BaseRepository<Blog>, IBlogsRepository
{
    public BlogsRepository(WebApiContext context) : base(context)
    {
    }
}
