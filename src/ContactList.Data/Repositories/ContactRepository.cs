using ContactList.Data.DbContexts;
using ContactList.Data.Entities;
using ContactList.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Data.Repositories;

public class ContactRepository(AppDbContext context) : IContactRepository
{
    public async Task<IEnumerable<Contact>> GetByCategoryIdAsync(Guid? categoryId, CancellationToken ct = default)
    {
        return await context.Contacts
            .Include(c => c.Category)
            .Where(c =>  
                    categoryId == null ||
                    c.Category.Id == categoryId || 
                    (c.Subcategory != null && c.Subcategory.Id == categoryId)
                )
            .ToListAsync(ct);
    }

    public async Task<Contact?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await context.Contacts
            .Include(c => c.Category)
            .FirstOrDefaultAsync(c => c.Id == id, ct);
    }

    public async Task AddAsync(Contact contact, CancellationToken ct = default)
    {
        context.Contacts.Add(contact);
        await context.SaveChangesAsync(ct);
    }
    
    public async Task DeleteAsync(Guid id, CancellationToken ct)
    {
        await context.Contacts
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync(cancellationToken: ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Contact contact, CancellationToken ct)
    {
        context.Contacts.Update(contact);
        await context.SaveChangesAsync(ct);
    }
}