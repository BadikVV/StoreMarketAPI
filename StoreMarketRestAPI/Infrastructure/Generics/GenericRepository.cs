using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StoreMarketRestAPI.Base;
using StoreMarketRestAPI.Infrastructure.Context;
using StoreMarketRestAPI.Interfaces;

namespace StoreMarketRestAPI.Infrastructure.Generics;

public class GenericRepository : IGenericRepository
{
    private readonly DataDbContext _context;
    //private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(DataDbContext context)
    {
        _context = context;
        //_dbSet = context.Set<TEntity>();
    }

    public List<TEntity> GetList<TEntity>(int pageSize, int pageNumber, string? orderDirection = "asc", 
        Expression<Func<TEntity, object>>? orderExpression = null, Expression<Func<TEntity, bool>> ? expression = null) where TEntity : BaseEntity
    {
        IQueryable<TEntity>? query = _context.Set<TEntity>();;
        
        if (orderExpression == null)
        {
            query = _context.Set<TEntity>().OrderBy(b => b);
        }
        else
        {
            if (orderDirection != "asc" && orderDirection != "desc")
                orderDirection = "asc";
            query = orderDirection == "asc" ? _context.Set<TEntity>().OrderBy(orderExpression) : 
                _context.Set<TEntity>().OrderByDescending(orderExpression);
        }
        if (expression != null)
            query = query.Where(expression);
        
        return query.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public TEntity GetById<TEntity>(Guid id) where TEntity : BaseEntity
    {
        return _context.Set<TEntity>().Find(id)!;
    }

    public TEntity Add<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        _context.Set<TEntity>().Add(entity);
        _context.Entry(entity).State = EntityState.Added;
        _context.SaveChanges();
        return entity;
    }

    public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        // var newEntity = GetById(id);
        _context.Set<TEntity>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        
    }

    public void Delete<TEntity>(Guid id) where TEntity : BaseEntity
    {
        var entity = _context.Set<TEntity>().Find(id);
        if(entity == null) return;
        
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _context.Set<TEntity>().Attach(entity);
        }
        _context.Set<TEntity>().Remove(entity);
        _context.SaveChanges();
    }
    
    public int Count<TEntity>(Expression<Func<TEntity, bool>>? expression = null) where TEntity : BaseEntity
    {
        if (expression != null)
            return _context.Set<TEntity>().Where(expression).Count();
        return _context.Set<TEntity>().Count();
    }
}