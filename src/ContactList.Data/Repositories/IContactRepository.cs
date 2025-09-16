using ContactList.Data.Entities;

namespace ContactList.Data.Repositories;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllAsync(CancellationToken ct = default);
    Task<Contact?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Contact contact, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}