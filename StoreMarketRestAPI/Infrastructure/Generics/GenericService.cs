using System.Linq.Expressions;
using AutoMapper;
using StoreMarketRestAPI.Base;
using StoreMarketRestAPI.Entities;
using StoreMarketRestAPI.Interfaces;
using StoreMarketRestAPI.Persistence;

namespace StoreMarketRestAPI.Infrastructure.Generics;

public class GenericService
{
    private readonly IGenericRepository _repository;
    private readonly IMapper _mapper;
    
    public GenericService(IGenericRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public TDto Create<TDto, TEntity, TCreateDto>(TCreateDto createDto) where TEntity : BaseEntity 
    {
        var entityToCreate = _mapper.Map<TEntity>(createDto);
        var entity = _repository.Add(entityToCreate);
        var dto = _mapper.Map<TDto>(entity);
        return dto;
    }

    public void Delete<TEntity>(Guid id) where TEntity : BaseEntity
    {
        _repository.Delete<TEntity>(id);
    }

    public TDto Update<TDto, TEntity, TUpdateDto>(TUpdateDto updateDto, Guid id) where TEntity : BaseEntity
    {
        var entity = _repository.GetById<TEntity>(id);

        _mapper.Map(updateDto, entity);
        _repository.Update(entity);

        var dto = _mapper.Map<TDto>(entity);
        return dto;

    }
    
    public TDto GetById<TDto, TEntity>(Guid id) where TEntity : BaseEntity
    {
        var entity = _repository.GetById<TEntity>(id);
        if (entity == null) return default;
        var dto = _mapper.Map<TDto>(entity);
        return dto;
    }

    // public PaginatedListAPIResponse<TDto> GetList<TDto, TEntity>(int pageSize, int pageNumber, string? search,
    //     string? orderBy = "Title", string? orderDirection = "asc") where TEntity : BaseEntity
    //
    // {
    //     Expression<Func<TEntity, object>>? orderExpression = null;
    //     if (!string.IsNullOrEmpty(orderBy))
    //     {
    //         orderExpression = PredicateBuilder.ToLambda<TEntity>(orderBy);
    //     }
    //
    //     List<TEntity> entityList;
    //     var count = 0;
    //     PaginatedListAPIResponse<TDto> paginatedBooks = new();
    //     if (search == null)
    //     {
    //         entityList = _repository.GetList<TEntity>(pageSize, pageNumber, orderDirection, orderExpression);
    //         count = _repository.Count<TEntity>();
    //     }
    // }
}