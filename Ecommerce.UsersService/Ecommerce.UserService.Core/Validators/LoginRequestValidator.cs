using Ecommerce.Core.DTOs;
using FluentValidation;

namespace Ecommerce.Core.Validators;

/// <summary>
/// Provides validation rules for <see cref="LoginRequestDto"/>, ensuring that the email and password fields meet required criteria.
/// </summary>
public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestValidator()
    {
        // Rule for email.
        RuleFor(r => r.Email).NotEmpty().WithMessage("We need email, please share with us")
            .EmailAddress().WithMessage("Email provided by you isn't valid, please let us know your email");

        // Rule for password.
        RuleFor(r => r.Password).NotEmpty().WithMessage("Ooopss! invalid password, please recall it!");
    }
}
