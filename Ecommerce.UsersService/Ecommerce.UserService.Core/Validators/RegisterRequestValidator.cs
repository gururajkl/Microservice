using Ecommerce.UserService.Core.DTOs;
using FluentValidation;

namespace Ecommerce.UserService.Core.Validators;

/// <summary>
/// Provides validation rules for <see cref="RegisterRequestDto"/>, ensuring that the email and password fields meet required criteria.
/// </summary>
public class RegisterRequestValidator : AbstractValidator<RegisterRequestDto>
{
    public RegisterRequestValidator()
    {
        // Rule for email.
        RuleFor(r => r.Email).NotEmpty().WithMessage("We need email, please share with us")
            .EmailAddress().WithMessage("Email provided by you isn't valid, please let us know your email");

        // Rule for password.
        RuleFor(r => r.Password).NotEmpty().WithMessage("Ooopss! invalid password, please recall it!");

        // Rule for person name.
        RuleFor(r => r.PersonName).NotEmpty().WithMessage("We need your name!")
            .NotNull().WithMessage("We need your name!").MaximumLength(50);

        // Rule for gender.
        RuleFor(r => r.Gender).IsInEnum().WithMessage("Invalid gender option");
    }
}
