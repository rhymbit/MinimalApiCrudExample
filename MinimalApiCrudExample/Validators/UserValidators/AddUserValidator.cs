namespace MinimalApiCrudExample.Validators.UserValidators;

public class AddUserValidator : AbstractValidator<AddUserRequestModel>
{
    public AddUserValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(30)
            .Matches(@"^[a-zA-Z0-9\s]*$")
            .WithMessage("Name must be alphanumeric and between 4 and 30 characters");

        RuleFor(x => (int)x.Age)
            .NotNull()
            .InclusiveBetween(10, 99);

        RuleFor(x => x.Email)
            .NotNull()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotNull()
            .MinimumLength(8)
            .MaximumLength(30)
            .Matches(@"^[a-zA-Z0-9@$#!%^&*]*$")
            .WithMessage(@"Password must be alphanumeric and between 8 and 30 characters.
                    It can also contain the following special characters: @$#!%^&*");

    }
}
