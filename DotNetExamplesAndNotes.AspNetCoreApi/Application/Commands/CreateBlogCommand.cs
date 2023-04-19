using DotNetExamplesAndNotes.WebApiDAL.Repositories;
using MediatR;

namespace DotNetExamplesAndNotes.AspNetCoreApi.Application.Commands;

public record CreateBlogCommand() : IRequest;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
{
    private readonly IBlogsRepository _blogsRepository;

    public CreateBlogCommandHandler(IBlogsRepository blogsRepository)
    {
        _blogsRepository = blogsRepository;
    }

    public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        await _blogsRepository.AddAsync(
            new()
            {
                Title = "Sample title",
                Description = "Description",
            }, 
            cancellationToken);
    }
}
