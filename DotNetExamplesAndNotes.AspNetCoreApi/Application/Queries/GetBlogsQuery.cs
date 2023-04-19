using DotNetExamplesAndNotes.WebApiDAL;
using DotNetExamplesAndNotes.WebApiDAL.Repositories;
using MediatR;

namespace DotNetExamplesAndNotes.AspNetCoreApi.Application.Queries;

public record GetBlogsQuery : IRequest<Blog[]>;

public class GetBlogsQueryCommandHandler : IRequestHandler<GetBlogsQuery, Blog[]>
{
    private readonly IBlogsRepository _blogRepository;

    public GetBlogsQueryCommandHandler(IBlogsRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<Blog[]> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        return await _blogRepository.GetAsync(cancellationToken);
    }
}
