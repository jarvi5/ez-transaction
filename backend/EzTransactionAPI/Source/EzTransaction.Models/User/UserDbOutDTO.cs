namespace EzTransaction.Models.User;

public class UserDbOutDTO
{
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string DNI { get; set; } = string.Empty;

    public byte[] PasswordHash { get; set; } = new byte[] { };

    public byte[] PasswordSalt { get; set; } = new byte[] { };
}