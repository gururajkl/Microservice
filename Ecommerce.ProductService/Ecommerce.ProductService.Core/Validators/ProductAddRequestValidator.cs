using Ecommerce.ProductService.Core.DTOs;
using FluentValidation;

namespace Ecommerce.ProductService.Core.Validators;

/// <summary>
/// Create fluent validation for the <see cref="ProductAddRequestDto"/>.
/// </summary>
public class ProductAddRequestValidator : AbstractValidator<ProductAddRequestDto>
{
    public ProductAddRequestValidator()
    {
        RuleFor(p => p.ProductName).NotEmpty().WithMessage("Product name cannot be empty");
        RuleFor(p => p.CategoryOption).IsInEnum().WithMessage("Invalid category");
        RuleFor(p => p.UnitPrice).InclusiveBetween(0, double.MaxValue)
            .WithMessage($"Unit price should be between 0 and {double.MaxValue}");
        RuleFor(p => p.Quantity).InclusiveBetween(0, int.MaxValue)
            .WithMessage($"Unit price should be between 0 and {int.MaxValue}");
    }
}
