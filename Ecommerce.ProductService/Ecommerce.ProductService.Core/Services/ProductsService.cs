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

        Product? newProduct = await repository.AddProductAsync(product);

        if (newProduct is null) return null;

        return mapper.Map<ProductResponseDto>(newProduct);
    }

    public async Task<bool> DeleteProductAsync(Guid productId)
    {
        Product? product = await repository.GetProductByConditionAsync(p => p.ProductId == productId);
        return product is not null && await repository.DeleteProductAsync(productId);
    }

    public async Task<ProductResponseDto?> GetProductByConditionAsync(Expression<Func<Product, bool>> expression)
    {
        Product? product = await repository.GetProductByConditionAsync(expression);

        if (product is null) return null;

        return mapper.Map<ProductResponseDto>(product);
    }

    public async Task<List<ProductResponseDto?>> GetProductsAsync()
    {
        IEnumerable<Product> products = await repository.GetProductsAsync();

        IEnumerable<ProductResponseDto> productResponseDtos = mapper.Map<IEnumerable<ProductResponseDto>>(products);

        return [.. productResponseDtos];
    }

    public async Task<List<ProductResponseDto?>> GetProductsByConditionAsync(Expression<Func<Product, bool>> expression)
    {
        IEnumerable<Product>? products = await repository.GetProductsByConditionAsync(expression);

        IEnumerable<ProductResponseDto> productResponseDtos = mapper.Map<IEnumerable<ProductResponseDto>>(products);

        return [.. productResponseDtos];
    }

    public async Task<ProductResponseDto?> UpdateProductAsync(ProductUpdateRequestDto productUpdateRequestDto)
    {
        Product? exisitingProduct = await repository.GetProductByConditionAsync(p => p.ProductId == productUpdateRequestDto.ProductId);

        if (exisitingProduct is null) ArgumentException.ThrowIfNullOrEmpty(nameof(productUpdateRequestDto));

        ValidationResult validationResult = await productUpdateRequestValidator.ValidateAsync(productUpdateRequestDto);

        if (!validationResult.IsValid)
        {
            string error = string.Join(", ", validationResult.Errors.Select(v => v.ErrorMessage));
            throw new Exception(error);
        }

        Product product = mapper.Map<Product>(productUpdateRequestDto);

        Product? updatedProduct = await repository.UpdateProductAsync(product);

        if (updatedProduct is null) return null;

        return mapper.Map<ProductResponseDto>(updatedProduct);
    }
}
