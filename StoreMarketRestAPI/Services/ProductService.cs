using StoreMarketRestAPI.DTOs;
using StoreMarketRestAPI.Entities;
using StoreMarketRestAPI.Interfaces;

namespace StoreMarketRestAPI.Services;

public class ProductService
{
    private readonly IGenericRepository<Product> _repository;
    public ProductService (IGenericRepository<Product> repository)
    {
        _repository = repository;
    }

    public ProductDto GetById(Guid id)
    {
        var product = _repository.GetById(id);
        return product == null ? null : CreateDto(product);
    }

    public ProductDto Update(Guid id, ProductUpdateDto productUpdateDto)
    {
        var product = _repository.GetById(id);
        if (product == null) return null;

        product.Title = productUpdateDto.Title;
        product.ArticleNumber = product.ArticleNumber;
        product.Category = product.Category;
        product.Price = product.Price;
        product.MeasureUnit = product.MeasureUnit;
        product.Manufacturer = product.Manufacturer;
        product.Quantity = product.Quantity;
        _repository.Update(product);

        return CreateDto(product);
    }

    private static ProductDto CreateDto(Product product)
    {
        var productDto = new ProductDto()
        {
            Title = product.Title,
            ArticleNumber = product.ArticleNumber,
            Category = product.Category,
            Price = product.Price,
            MeasureUnit = product.MeasureUnit,
            Manufacturer = product.Manufacturer,
            Quantity = product.Quantity,
            Id = product.Id
        };
        return productDto;
    }

    public void Delete(Guid id)
    {
        _repository.Delete(id);
    }
}