using AutoMapper;
using ContactList.Business.DTOs;
using ContactList.Business.Services.Interfaces;
using ContactList.Data.Repositories;

namespace ContactList.Business.Services;

public class ContactService: IContactService
{
    private readonly IContactRepository _repo;
    private readonly IMapper _mapper;
    public async Task<IEnumerable<ContactDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ContactDetailDto?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}