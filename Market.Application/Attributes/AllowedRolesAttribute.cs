using System.ComponentModel.DataAnnotations;

public class AllowedRolesAttribute : ValidationAttribute
{
    private readonly string[] _allowed;

    public AllowedRolesAttribute(params string[] allowed)
    {
        _allowed = allowed;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string strValue)
        {
            return _allowed.Contains(strValue, StringComparer.OrdinalIgnoreCase)
                ? ValidationResult.Success
                : new ValidationResult($"Role must be one of the following: {string.Join(", ", _allowed)}");
        }

        return new ValidationResult("Invalid role name.");
    }
}