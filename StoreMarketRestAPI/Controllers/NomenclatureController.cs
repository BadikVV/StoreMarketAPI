using StoreMarketRestAPI.Entities;
using StoreMarketRestAPI.Infrastructure.GenericRepository;
using Microsoft.AspNetCore.Mvc;

namespace StoreMarketRestAPI.Controllers;

[Route("api/[controller]/")]
[ApiController]
public class NomenclatureController : ControllerBase
{
    private readonly GenericRepository<Nomenclature> _genericRepository;

    public NomenclatureController(GenericRepository<Nomenclature> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    [HttpPost]
    public void Add(Nomenclature nomenclature)
    {
        _genericRepository.Add(nomenclature);
    }

    [HttpGet("{id}")]
    public APIResponse<Nomenclature> GetById(Guid id)
    {
        var response = new APIResponse<Nomenclature>
        {
            Data = _genericRepository.GetById(id)
        };
        return response;
    }
    
    // [HttpGet("list")]
    // public PaginatedListAPIResponse<Nomenclature> GetList([FromQuery]int pageSize, int pageNumber, string? search, 
    //     string? orderBy, string? orderDirection)
    // {
    //     return _genericRepository.GetList(pageSize,pageNumber,search, orderBy, orderDirection);
    // }
    
    [HttpDelete("{id}")]
    public void Delete(Guid id)
    {
        _genericRepository.Delete(id);
    }

    [HttpPut("{id}")]
    public void Update(Nomenclature nomenclature)
    {
        _genericRepository.Update(nomenclature);
    }
}