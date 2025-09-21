using ContactList.Data.Entities;

namespace ContactList.Business.DTOs;

public class ContactDetailDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string Password { get; set; } = null!;
    public Category Category { get; set; } = null!;
}