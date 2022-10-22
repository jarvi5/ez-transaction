namespace EzTransaction.Services.Validators;

using System.Security.Cryptography;
using EzTransaction.Models;
using EzTransaction.Models.User;
using EzTransaction.Repositories.Interfaces;
using FluentValidation;

internal class UserLoginValidator : AbstractValidator<UserLoginDTO>
{
    internal UserLoginValidator(IAuthenticationRepository repository)
    {
        this.RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage(EzTransactionConstants.NotEmptyErrorMessage);

        this.RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage(EzTransactionConstants.NotEmptyErrorMessage)
            .MinimumLength(EzTransactionConstants.PasswordMinLength)
            .WithMessage(EzTransactionConstants.PassMinLengthErrorMessage);

        this.RuleFor(user => user)
            .MustAsync(async (user, cancellation) => await repository.IsRegistered(user.Email))
            .WithMessage(EzTransactionConstants.UserNotExistsErrorMessage)
            .MustAsync(async (user, cancellation) =>
            {
                UserDbOutDTO? userdb = await repository.GetUser<UserDbOutDTO>(user.Email);
                return userdb is null || this.VerifyPasswordHash(userdb!, user.Password);
            })
            .WithMessage(EzTransactionConstants.InvalidPassErrorMessage);
    }

    private bool VerifyPasswordHash(UserDbOutDTO user, string password)
    {
        using var hmac = new HMACSHA512(user.PasswordSalt);
        var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return passwordHash.SequenceEqual(user.PasswordHash);
    }
}