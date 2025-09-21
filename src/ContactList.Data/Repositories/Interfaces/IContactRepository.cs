using ContactList.Data.Entities;

namespace ContactList.Data.Repositories.Interfaces;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetByCategoryIdAsync(Guid? categoryId, CancellationToken ct = default);
    Task<Contact?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Contact contact, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct);
    Task UpdateAsync(Contact contact, CancellationToken ct);
}