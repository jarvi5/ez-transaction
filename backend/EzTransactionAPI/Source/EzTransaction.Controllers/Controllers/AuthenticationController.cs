namespace EzTransaction.Controllers.Controllers;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EzTransaction.Controllers.Models;
using EzTransaction.Models.User;
using EzTransaction.Services.Interfaces;
using EzTransaction.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService service;
    private readonly IConfiguration configuration;

    public AuthenticationController(IConfiguration configuration, IAuthenticationService service)
    {
        this.service = service;
        this.configuration = configuration;
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp([FromBody] UserRegistrationDTO user)
    {
        ServiceResult<User> result = await this.service.SignUp(user);
        if (result.Errors is not null)
        {
            return this.BadRequest(new ApiResult<User>(result.Errors));
        }

        return this.Ok(new ApiResult<User>(result.Result!));
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO user)
    {
        ServiceResult<User> result = await this.service.Login(user);
        if (result.Errors is not null)
        {
            return this.BadRequest(new ApiResult<string>(result.Errors));
        }

        string token = this.CreateToken(result.Result!);
        return this.Ok(new ApiResult<string>(token));
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new ()
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
        };

        SymmetricSecurityKey key = new (
            System.Text.Encoding.UTF8.GetBytes(
                this.configuration.GetSection("AuthenticationSettings:Token")
                .Value));
        SigningCredentials credentials = new (key, SecurityAlgorithms.HmacSha512Signature);
        JwtSecurityToken token = new (
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}