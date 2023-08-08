using ContactsApi.Dtos;
using FluentValidation;

namespace ContactsApi.Validators;

public class ContactDetailsDtoValidator:AbstractValidator<ContactDetailsDto>
{
    public ContactDetailsDtoValidator()
    {
        RuleFor(x => x.ContactPassword)
            .NotEmpty().WithMessage("Hasło musi zostać wprowadzone.")
            .MinimumLength(5).WithMessage("Długośc hasła musi wynosić przynajmniej 5 znaków.")
            .Matches(@"[\!\?\*\.]+").WithMessage("Hasło musi składać się pzynajmniej z jednego specjalnego znaku")
            .Matches(@"[0-9]+").WithMessage("Hasło musi składać się przynajmniej z jednej liczby.");
    }
}