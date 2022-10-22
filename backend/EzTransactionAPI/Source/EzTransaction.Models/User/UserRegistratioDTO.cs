namespace EzTransaction.Models.User;

public class UserRegistrationDTO
{
    public string Email { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string DNI { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string PasswordConfirm { get; set; } = string.Empty;
}