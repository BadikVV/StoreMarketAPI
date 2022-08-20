using AutoMapper;
using StoreMarketRestAPI.Entities;
using StoreMarketRestAPI.DTOs;

namespace StoreMarketRestAPI.Mappings;

public class NomenclatureMapping : Profile
{
    public NomenclatureMapping()
    {
        CreateMap<NomenclatureCreateDTO, Nomenclature>().ReverseMap();
        CreateMap<NomenclatureUpdateDTO, Nomenclature>().ReverseMap();
        CreateMap<Nomenclature, NomenclatureDTO>().ReverseMap();
    }
}