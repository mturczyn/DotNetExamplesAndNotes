using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotNetExamplesAndNotes.WebApiDAL.Repositories;

public interface IBaseRepository<T> where T : class
{
    public Task<T[]> GetAsync(CancellationToken cancellationToken);

    public Task AddAsync(T entity, CancellationToken cancellationToken);
}

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected WebApiContext _context;

    protected BaseRepository(WebApiContext context)
    {
        _context = context;
    }

    public async Task<T[]> GetAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToArrayAsync(cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
