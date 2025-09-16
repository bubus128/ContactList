using ContactList.Data.Entities;

namespace ContactList.Data.Repositories;

public class ContactRepository : IContactRepository
{
    public async Task<IEnumerable<Contact>> GetAllAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Contact?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Contact contact, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}