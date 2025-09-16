using Microsoft.AspNetCore.Identity;

namespace ContactList.Data.Entities;

public class AppUser : IdentityUser
{
    public required string Name { get; set; }
}