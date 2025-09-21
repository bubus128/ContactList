using System.ComponentModel.DataAnnotations;

namespace ContactList.Business.Contracts;

public class CreateContactRequest : IValidatableObject
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required DateTime Birthday { get; set; }
    public required string Password { get; set; }
    public string? CategoryName { get; set; }
    public Guid CategoryId { get; set; }
    
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (CategoryId == Guid.Empty && string.IsNullOrWhiteSpace(CategoryName))
        {
            yield return new ValidationResult(
                "CategoryName is required when CategoryId is empty.",
                [nameof(CategoryName)]
            );
        }
    }
}