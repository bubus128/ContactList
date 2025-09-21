using System.ComponentModel.DataAnnotations;
using ContactList.Data.Entities;

namespace ContactList.Web.ViewModels;

public class ContactEditViewModel
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Password { get; set; }
    public DateTime? Birthday { get; set; }

    public Guid SelectedCategoryId { get; set; }
    public string? OtherCategoryName { get; set; }

    public List<Category> Categories { get; set; } = new();
}