namespace EzTransaction.Services.Interfaces;

using EzTransaction.Models.User;
using EzTransaction.Services.Models;

public interface IAuthenticationService
{
    public Task<ServiceResult<User>> SignUp(UserRegistrationDTO user);

    public Task<ServiceResult<User>> Login(UserLoginDTO user);
}