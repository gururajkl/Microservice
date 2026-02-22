using Ecommerce.ProductService.Core.DTOs;
using FluentValidation;

namespace Ecommerce.ProductService.Core.Validators;

public class ProductUpdateRequestValidator : AbstractValidator<ProductUpdateRequestDto>
{
    public ProductUpdateRequestValidator()
    {
        RuleFor(p => p.ProductId).NotEmpty().WithMessage("Product id cannot be empty");
        RuleFor(p => p.ProductName).NotEmpty().WithMessage("Product name cannot be empty");
        RuleFor(p => p.Category).IsInEnum().WithMessage("Invalid category");
        RuleFor(p => p.UnitPrice).InclusiveBetween(0, double.MaxValue)
            .WithMessage($"Unit price should be between 0 and {double.MaxValue}");
        RuleFor(p => p.QuantityInStock).InclusiveBetween(0, int.MaxValue)
            .WithMessage($"Unit price should be between 0 and {int.MaxValue}");
    }
}
