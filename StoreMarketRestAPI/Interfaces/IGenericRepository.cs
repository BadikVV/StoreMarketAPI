using System.Linq.Expressions;

namespace StoreMarketRestAPI.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    public List<TEntity> GetList(int pageSize, int pageNumber, string? orderDirection = "asc", 
        Expression<Func<TEntity, object>>? orderExpression = null, Expression<Func<TEntity, bool>> ? expression = null);
    public TEntity GetById(object id);
    public void Add(TEntity obj);
    public void Update(TEntity obj);
    public void Delete(object id);

}