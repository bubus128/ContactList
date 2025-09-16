using ContactList.Business.DTOs;

namespace ContactList.Business.Services.Interfaces;

public interface IContactService
{
    public Task<IEnumerable<ContactDto>> GetAllAsync();
    public Task<ContactDetailDto?> GetByIdAsync(Guid id);
}