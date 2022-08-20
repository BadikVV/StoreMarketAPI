using System.Linq.Expressions;
using StoreMarketRestAPI.Base;

namespace StoreMarketRestAPI.Interfaces;

public interface IGenericRepository
{
    public List<TEntity> GetList<TEntity>(int pageSize, int pageNumber, string? orderDirection = "asc", 
        Expression<Func<TEntity, object>>? orderExpression = null, Expression<Func<TEntity, bool>> ? expression = null)
        where TEntity : BaseEntity;
    public TEntity GetById<TEntity>(Guid id) where TEntity : BaseEntity;
    public TEntity Add<TEntity>(TEntity entity) where TEntity : BaseEntity;
    public void Update<TEntity>(TEntity obj) where TEntity : BaseEntity;
    public void Delete<TEntity>(Guid id) where TEntity : BaseEntity;
    public int Count<TEntity>(Expression<Func<TEntity, bool>>? expression = null) where TEntity : BaseEntity;

}