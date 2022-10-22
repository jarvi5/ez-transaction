namespace EzTransaction.Models;

public class EzTransactionConstants
{
    public const int EmailLength = 250;

    public const int PasswordLength = 250;

    public const int NameLength = 125;

    public const int DniLength = 20;

    public const int PasswordMinLength = 8;

    public const string NotEmptyErrorMessage = "{PropertyName} must not be empty";

    public const string PassMinLengthErrorMessage = "{PropertyName} must have at least 8 characters";

    public const string EmailMaxLengthErrorMessage = "{PropertyName} must have at least 250 characters";

    public const string InvalidEmailErrorMessage = "{PropertyName} must be a valid email address";

    public const string NameMaxLengthErrorMessage = "{PropertyName} must have at least 250 characters";

    public const string DniMaxLengthErrorMessage = "{PropertyName} must have at least 250 characters";

    public const string PasswordsNotMatchErrorMessage = "{PropertyName} does not match with Password";

    public const string UserNotExistsErrorMessage = "User not registered";

    public const string UserAlreadyRegisteredErrorMessage = "{PropertyName} is already registered";

    public const string InvalidPassErrorMessage = "Invalid password";
}