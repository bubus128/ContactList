namespace ContactList.Business.DTOs;

public class SimplyContactDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}