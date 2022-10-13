namespace EzTransaction.Repositories.Interfaces;

using EzTransaction.Models.User;

public interface IAuthenticationRepository
{
    public Task<User?> SignUp(UserDbDTO user);

    public Task<bool> IsRegistered(string email);

    public Task<T?> GetUser<T>(string email)
        where T : class;
}