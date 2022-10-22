namespace EzTransaction.Services;

using System.Security.Cryptography;
using System.Threading.Tasks;
using EzTransaction.Models.User;
using EzTransaction.Repositories.Interfaces;
using EzTransaction.Services.Interfaces;
using EzTransaction.Services.Models;
using EzTransaction.Services.Validators;
using FluentValidation.Results;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRepository repository;

    public AuthenticationService(IAuthenticationRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ServiceResult<User>> SignUp(UserRegistrationDTO user)
    {
        UserRegistrationValidator validator = new (this.repository);
        ValidationResult results = await validator.ValidateAsync(user);
        if (!results.IsValid)
        {
            return results.Errors;
        }

        (byte[] passwordSalt, byte[] passwordHash) = this.CreatePasswordHash(user.Password);
        return await this.repository.SignUp(new UserDbDTO(user, passwordHash, passwordSalt));
    }

    public async Task<ServiceResult<User>> Login(UserLoginDTO user)
    {
        UserLoginValidator validator = new (this.repository);
        ValidationResult results = await validator.ValidateAsync(user);
        if (!results.IsValid)
        {
            return results.Errors;
        }

        return await this.repository.GetUser<User>(user.Email);
    }

    private (byte[] passwordSalt, byte[] passwordHash) CreatePasswordHash(string password)
    {
        using var hmac = new HMACSHA512();
        var passwordSalt = hmac.Key;
        var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return (passwordSalt, passwordHash);
    }
}