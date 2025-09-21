using AutoMapper;
using ContactList.Data.Entities;
using ContactList.Web.ViewModels;

namespace ContactList.Web.MapperProfiles;

public class ViewMapperProfiles : Profile
{
    public ViewMapperProfiles()
    {
        CreateMap<Contact, ContactDetailViewModel>();
        CreateMap<Contact, ContactEditViewModel>();
    }
}