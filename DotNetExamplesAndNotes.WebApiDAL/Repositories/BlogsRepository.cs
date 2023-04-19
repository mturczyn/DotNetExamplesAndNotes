using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
