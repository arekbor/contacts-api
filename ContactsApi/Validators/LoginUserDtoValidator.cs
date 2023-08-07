using ContactsApi.Dtos;
using FluentValidation;

namespace ContactsApi.Validators;

/// <summary>
/// Validator for user login credentials.
/// </summary>
public class LoginUserDtoValidator:AbstractValidator<LoginUserDto>
{
    public LoginUserDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Nazwa użytkownika jest wymagana");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Hasło jest wymagane");
    }
}