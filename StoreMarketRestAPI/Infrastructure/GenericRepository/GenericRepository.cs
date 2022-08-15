using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StoreMarketRestAPI.Interfaces;

namespace StoreMarketRestAPI.Infrastructure.GenericRepository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public List<TEntity> GetList(int pageSize, int pageNumber, string? orderDirection = "asc", 
        Expression<Func<TEntity, object>>? orderExpression = null, Expression<Func<TEntity, bool>> ? expression = null)
    {
        IQueryable<TEntity>? query = null;
        
        if (orderExpression == null)
        {
            query = _dbSet.OrderBy(b => b);
        }
        else
        {
            if (orderDirection != "asc" && orderDirection != "desc")
                orderDirection = "asc";
            query = orderDirection == "asc" ? _dbSet.OrderBy(orderExpression) : _dbSet.OrderByDescending(orderExpression);
        }
        if (expression != null)
            query = query.Where(expression);
        
        return query.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public TEntity GetById(object id)
    {
        return _dbSet.Find(id)!;
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        // var newEntity = GetById(id);
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        
    }

    public void Delete(object id)
    {
        var entity = _dbSet.Find(id);
        Delete(entity!);
        _context.SaveChanges();
    }

    private void Delete(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
        _dbSet.Remove(entity);
    }
}