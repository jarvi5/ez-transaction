namespace EzTransaction.Models.User;

public class UserDbDTO
{
    public UserDbDTO(UserRegistrationDTO user, byte[] passwordHash, byte[] passwordSalt)
    {
        this.Email = user.Email;
        this.FirstName = user.FirstName;
        this.LastName = user.LastName;
        this.DNI = user.DNI;
        this.PasswordHash = passwordHash;
        this.PasswordSalt = passwordSalt;
    }

    public string Email { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string DNI { get; set; } = string.Empty;

    public byte[] PasswordHash { get; set; } = new byte[] { };

    public byte[] PasswordSalt { get; set; } = new byte[] { };
}