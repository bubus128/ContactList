using ContactList.Business.DTOs;
using ContactList.Data.Entities;

namespace ContactList.Web.ViewModels;

public class ContactListViewModel
{
    public bool IsLoggedIn { get; set; }
    public IEnumerable<SimplyContactDto> Contacts { get; set; } = [];
    public IEnumerable<Category> Categories { get; set; } = [];
    public Guid? SelectedCategoryId { get; set; }
}
