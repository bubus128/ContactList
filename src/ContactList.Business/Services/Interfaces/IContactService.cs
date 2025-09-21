using ContactList.Business.Contracts;
using ContactList.Business.DTOs;
using ContactList.Data.Entities;

namespace ContactList.Business.Services.Interfaces;

public interface IContactService
{
    Task<IEnumerable<SimplyContactDto>> GetContactsAsync(Guid? categoryId, CancellationToken ct = default);
    Task<Contact?> GetContactByIdAsync(Guid id, CancellationToken ct = default);
    Task<List<Category>>  GetCategoriesAsync(CancellationToken ct = default);
    Task DeleteContactAsync(Guid id, CancellationToken ct);
    Task UpdateContactAsync(CreateContactRequest contactRequest, CancellationToken ct);
    Task<Category?> GetCategoryByIdAsync(Guid categoryId, CancellationToken ct);
    Task AddCategoryAsync(Category category, CancellationToken ct);
    Task AddContactAsync(CreateContactRequest contactRequest, CancellationToken ct);
}