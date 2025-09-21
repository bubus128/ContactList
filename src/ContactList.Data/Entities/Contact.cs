namespace ContactList.Data.Entities;

public class Contact
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    
    public required DateTime Birthday { get; set; }
    public Guid CategoryId { get; set; }
    public required Category Category { get; set; }

    public Guid? SubcategoryId { get; set; }
    public Category? Subcategory { get; set; }
}