namespace EzTransaction.Services.Validators;

using EzTransaction.Models;
using EzTransaction.Models.User;
using EzTransaction.Repositories.Interfaces;
using FluentValidation;

internal class UserRegistrationValidator : AbstractValidator<UserRegistrationDTO>
{
    public UserRegistrationValidator(IAuthenticationRepository repository)
    {
        this.RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage(EzTransactionConstants.NotEmptyErrorMessage)
            .EmailAddress()
            .WithMessage(EzTransactionConstants.InvalidEmailErrorMessage)
            .MaximumLength(EzTransactionConstants.EmailLength)
            .WithMessage(EzTransactionConstants.EmailMaxLengthErrorMessage)
            .MustAsync(async (email, cancellation) => !await repository.IsRegistered(email))
            .WithMessage(EzTransactionConstants.UserAlreadyRegisteredErrorMessage);

        this.RuleFor(user => user.FirstName)
            .NotEmpty()
            .WithMessage(EzTransactionConstants.NotEmptyErrorMessage)
            .MaximumLength(EzTransactionConstants.NameLength)
            .WithMessage(EzTransactionConstants.NameMaxLengthErrorMessage);

        this.RuleFor(user => user.LastName)
            .NotEmpty()
            .WithMessage(EzTransactionConstants.NotEmptyErrorMessage)
            .MaximumLength(EzTransactionConstants.NameLength)
            .WithMessage(EzTransactionConstants.NameMaxLengthErrorMessage);

        this.RuleFor(user => user.DNI)
            .NotEmpty()
            .WithMessage(EzTransactionConstants.NotEmptyErrorMessage)
            .MaximumLength(EzTransactionConstants.DniLength)
            .WithMessage(EzTransactionConstants.DniMaxLengthErrorMessage);

        this.RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage(EzTransactionConstants.NotEmptyErrorMessage)
            .MinimumLength(EzTransactionConstants.PasswordMinLength)
            .WithMessage(EzTransactionConstants.PassMinLengthErrorMessage);

        this.RuleFor(user => user.PasswordConfirm)
            .Equal(x => x.Password)
            .WithMessage(EzTransactionConstants.PasswordsNotMatchErrorMessage);
    }
}