using AutoMapper;
using Ecommerce.ProductService.Core.DTOs;
using Ecommerce.ProductService.Core.ServiceContracts;
using Ecommerce.ProductService.Infrastructure.Entities;
using Ecommerce.ProductService.Infrastructure.RepositoryContracts;
using FluentValidation;
using FluentValidation.Results;
using System.Linq.Expressions;

namespace Ecommerce.ProductService.Core.Services;

internal class ProductsService(IProductsRepository repository, IMapper mapper,
    IValidator<ProductAddRequestDto> productAddRequestValidator, IValidator<ProductUpdateRequestDto> productUpdateRequestValidator)
    : IProductsService
{
    public async Task<ProductResponseDto?> AddProductAsync(ProductAddRequestDto productAddRequestDto)
    {
        ArgumentNullException.ThrowIfNull(productAddRequestDto);

        ValidationResult validationResult = await productAddRequestValidator.ValidateAsync(productAddRequestDto);

        if (!validationResult.IsValid)
        {
            string errors = string.Join(", ", validationResult.Errors.Select(v => v.ErrorMessage));
            throw new Exception(errors);
        }

        Product product = mapper.Map<Product>(productAddRequestDto);

        Product? newProduct = await repository.AddProduct(product);

        if (newProduct is null) return null;

        return mapper.Map<ProductResponseDto>(newProduct);
    }

    public Task<bool> DeleteProductAsync(Guid productId)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponseDto?> GetProductByConditionAsync(Expression<Func<Product, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponseDto?> GetProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductResponseDto?>> GetProductsByConditionAsync(Expression<Func<Product, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponseDto?> UpdateProductAsync(ProductUpdateRequestDto productUpdateRequestDto)
    {
        throw new NotImplementedException();
    }
}
