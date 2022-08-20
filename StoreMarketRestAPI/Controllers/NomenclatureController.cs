using Microsoft.AspNetCore.Identity;
using StoreMarketRestAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using StoreMarketRestAPI.DTOs;
using StoreMarketRestAPI.Infrastructure.Generics;
using StoreMarketRestAPI.Interfaces;

namespace StoreMarketRestAPI.Controllers;

[Route("api/[controller]/")]
[ApiController]
public class NomenclatureController : ControllerBase
{
    private readonly GenericService _service;
    public NomenclatureController(GenericService service)
    {
        _service = service;
    }

    [HttpPost]
    public NomenclatureDTO Add(NomenclatureCreateDTO nomenclatureDto)
    {
        return _service.Create<NomenclatureDTO, Nomenclature, NomenclatureCreateDTO>(nomenclatureDto);
    }

    [HttpGet("{id}")]
    public APIResponse<NomenclatureDTO> GetById(Guid id)
    {
        var response = new APIResponse<NomenclatureDTO>();
        var nomenclature = _service.GetById<NomenclatureDTO, Nomenclature>(id);
        response.Data = nomenclature;
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
        _service.Delete<Nomenclature>(id);
    }

    [HttpPut("{id}")]
    public NomenclatureDTO Update(NomenclatureUpdateDTO nomenclature, Guid id)
    {
       return _service.Update<NomenclatureDTO, Nomenclature, NomenclatureUpdateDTO>(nomenclature, id);
    }
}