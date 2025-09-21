using AutoMapper;
using ContactList.Business.Services.Interfaces;
using ContactList.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Web.Controllers;

[Route("[controller]")]
public class ViewController(IContactService contactService, IAuthService authService, IMapper mapper) : Controller
{
    [HttpGet("nav")]
    public IActionResult NavRight() => PartialView("/Views/Shared/_Nav.cshtml");
    
    [HttpGet("contact/list")]
    public async Task<IActionResult> ContactList([FromQuery] Guid? categoryId, CancellationToken ct)
    {
        try
        {
            var contacts = await contactService.GetContactsAsync(categoryId, ct);
            var model = new ContactListViewModel
            {
                IsLoggedIn = User.Identity?.IsAuthenticated ?? false,
                Contacts = contacts,
                Categories = await contactService.GetCategoriesAsync(ct),
                SelectedCategoryId = categoryId
            };
            return PartialView("/Views/Contact/_ContactListPartial.cshtml", model);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("contact/detail/{id:guid}")]
    public async Task<IActionResult> ContactDetail(Guid id, CancellationToken ct)
    {
        try
        {
            var contact = await contactService.GetContactByIdAsync(id, ct);
            if (contact == null) return NotFound();

            var model = mapper.Map<ContactDetailViewModel>(contact);
            model.CategoryName = contact.Category.Name;
            model.IsLoggedIn = User.Identity?.IsAuthenticated ?? false;

            return PartialView("/Views/Contact/_ContactDetailPartial.cshtml", model);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("contact/edit/{id:guid}")]
    public async Task<IActionResult> ContactEditView(Guid id, CancellationToken ct)
    {
        try
        {
            var contact = await contactService.GetContactByIdAsync(id, ct);
            if (contact == null) return NotFound();

            var categories = await contactService.GetCategoriesAsync(ct);

            var model = mapper.Map<ContactEditViewModel>(contact);
            model.SelectedCategoryId = contact.Category.Id;
            model.Categories = categories.ToList();

            return PartialView("/Views/Contact/_ContactFormPartial.cshtml", model);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("contact/create")]
    public async Task<IActionResult> ContactCreateView(CancellationToken ct)
    {
        try
        {
            var categories = await contactService.GetCategoriesAsync(ct);
            var model = new ContactEditViewModel
            {
                Categories = categories.ToList()
            };
            return PartialView("/Views/Contact/_ContactFormPartial.cshtml", model);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    
    [HttpGet("auth/login")]
    public IActionResult Login() => PartialView("/Views/Auth/Login.cshtml");

    [HttpGet("auth/register")]
    public IActionResult Register() => PartialView("/Views/Auth/Register.cshtml");
}