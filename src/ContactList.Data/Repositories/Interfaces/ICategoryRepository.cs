using ContactList.Data.Entities;

namespace ContactList.Data.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync(CancellationToken ct = default);
    Task<Category?> GetByIdAsync(Guid categoryId, CancellationToken ct);
    Task AddAsync(Category category, CancellationToken ct);
}