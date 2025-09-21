using AutoMapper;
using ContactList.Business.Contracts;
using ContactList.Business.DTOs;
using ContactList.Business.Services.Interfaces;
using ContactList.Data.Entities;
using ContactList.Data.Repositories.Interfaces;

namespace ContactList.Business.Services;

public class ContactService(IContactRepository contactRepository, ICategoryRepository categoryRepository, IMapper mapper) : IContactService
{
    public async Task<IEnumerable<SimplyContactDto>> GetContactsAsync(Guid? categoryId, CancellationToken ct = default)
    {
        var contacts = await contactRepository.GetByCategoryIdAsync(categoryId, ct);
        return mapper.Map<IEnumerable<SimplyContactDto>>(contacts);
    }

    public async Task<ContactDetailDto?> GetContactByIdAsync(Guid id, CancellationToken ct = default)
    {
        var contact = await contactRepository.GetByIdAsync(id, ct);
        return mapper.Map<ContactDetailDto?>(contact);
    }

    public async Task<List<Category>> GetCategoriesAsync(CancellationToken ct = default)
    {
        return await categoryRepository.GetAllAsync(ct);
    }

    public async Task DeleteContactAsync(Guid id, CancellationToken ct)
    {
        await contactRepository.DeleteAsync(id, ct);
    }

    public async Task UpdateContactAsync(CreateContactRequest contactRequest, CancellationToken ct)
    {
        await contactRepository.UpdateAsync(mapper.Map<Contact>(contactRequest), ct);
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid categoryId, CancellationToken ct)
    {
        return await categoryRepository.GetByIdAsync(categoryId, ct);;
    }

    public async Task AddCategoryAsync(Category category, CancellationToken ct)
    {
        await categoryRepository.AddAsync(category, ct);
    }

    public async Task AddContactAsync(CreateContactRequest contactRequest, CancellationToken ct)
    {
        if (contactRequest.CategoryId == Guid.Empty)
        {
            var newCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = contactRequest.CategoryName
            };
            await AddCategoryAsync(newCategory, ct);
                
            contactRequest.CategoryId=newCategory.Id;
        }
        var contact = mapper.Map<Contact>(contactRequest);
        contact.Id = Guid.NewGuid();
        contact.Category = await GetCategoryByIdAsync(contactRequest.CategoryId, ct);
        await contactRepository.AddAsync(mapper.Map<Contact>(contact), ct);
    }
}