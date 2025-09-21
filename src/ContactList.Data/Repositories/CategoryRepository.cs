using ContactList.Data.DbContexts;
using ContactList.Data.Entities;
using ContactList.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Data.Repositories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public async Task<List<Category>> GetAllAsync(CancellationToken ct = default)
    {
        return await context.Category.ToListAsync(cancellationToken: ct);
    }

    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await context.Category
            .FirstOrDefaultAsync(c => c.Id == id, ct);
    }

    public async Task AddAsync(Category category, CancellationToken ct)
    {
        context.Category.Add(category);
        await context.SaveChangesAsync(ct);
    }
}