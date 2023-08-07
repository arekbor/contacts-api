using ContactsApi.Dtos;
using FluentValidation;

namespace ContactsApi.Validators;

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