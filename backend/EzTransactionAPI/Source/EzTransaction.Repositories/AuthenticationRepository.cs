namespace EzTransaction.Repositories;

using System.Data;
using System.Threading.Tasks;
using Dapper;
using EzTransaction.Models;
using EzTransaction.Models.Config;
using EzTransaction.Models.User;
using EzTransaction.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly string connectionString;

    public AuthenticationRepository(IOptions<MySqlConfig> mySqlConfig)
    {
        this.connectionString = mySqlConfig.Value.ConnectionString;
    }

    public async Task<User?> SignUp(UserDbDTO user)
    {
        using IDbConnection db = new MySqlConnection(this.connectionString);
        string storeProc = "SP_Users_Insert";
        DynamicParameters parameters = new ();
        parameters.Add("email", user.Email.ToLower(), DbType.String, ParameterDirection.Input, EzTransactionConstants.EmailLength);
        parameters.Add("lastName", user.LastName, DbType.String, ParameterDirection.Input, EzTransactionConstants.NameLength);
        parameters.Add("firstName", user.FirstName, DbType.String, ParameterDirection.Input, EzTransactionConstants.NameLength);
        parameters.Add("dni", user.DNI, DbType.String, ParameterDirection.Input, EzTransactionConstants.DniLength);
        parameters.Add("passwordHash", user.PasswordHash, DbType.Binary, ParameterDirection.Input, EzTransactionConstants.PasswordLength);
        parameters.Add("passwordSalt", user.PasswordSalt, DbType.Binary, ParameterDirection.Input, EzTransactionConstants.PasswordLength);
        return (await db.QueryAsync<User>(storeProc, parameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }

    public async Task<bool> IsRegistered(string email)
    {
        using IDbConnection db = new MySqlConnection(this.connectionString);
        string storeProc = "SP_Users_IsRegistered";
        DynamicParameters parameters = new ();
        parameters.Add("email", email.ToLower(), DbType.String, ParameterDirection.Input, EzTransactionConstants.EmailLength);
        int result = (await db.QueryAsync<int>(storeProc, parameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();
        return result > 0;
    }

    public async Task<T?> GetUser<T>(string email)
        where T : class
    {
        using IDbConnection db = new MySqlConnection(this.connectionString);
        string storeProc = "SP_Users_GetUser";
        DynamicParameters parameters = new ();
        parameters.Add("email", email.ToLower(), DbType.String, ParameterDirection.Input, EzTransactionConstants.EmailLength);
        return (await db.QueryAsync<T>(storeProc, parameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }
}