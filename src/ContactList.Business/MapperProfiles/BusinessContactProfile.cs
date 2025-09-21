using AutoMapper;
using ContactList.Business.Contracts;
using ContactList.Business.DTOs;
using ContactList.Data.Entities;

namespace ContactList.Business.MapperProfiles;

public class BusinessContactProfile : Profile
{
    public BusinessContactProfile()
    {
        CreateMap<Contact, SimplyContactDto>();
        CreateMap<Contact, ContactDetailDto>();
        CreateMap<CreateContactRequest, Contact>();
    }
}