using AutoMapper;
using ContactList.Business.Contracts;
using ContactList.Business.Services.Interfaces;
using ContactList.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController(IContactService contactService, IMapper mapper): Controller
{

    [HttpGet("list-view")]
    public async Task<IActionResult> ListViewListView([FromQuery] Guid? categoryId, CancellationToken ct)
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
            return PartialView("_ContactListPartial", model);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("detail-view/{id:guid}")]
    public async Task<IActionResult> DetailView(Guid id, CancellationToken ct)
    {
        try
        {
            var contact = await contactService.GetContactByIdAsync(id, ct);
            if (contact == null) return NotFound();
            
            var contactDetailModel = mapper.Map<ContactDetailViewModel>(contact);
            contactDetailModel.CategoryName = contact.Category.Name;
            contactDetailModel.IsLoggedIn = User.Identity?.IsAuthenticated ?? false;
            return PartialView("_ContactDetailPartial", contactDetailModel);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    
    [Authorize]
    [HttpGet("create-view")]
    public async Task<IActionResult> CreateView(CancellationToken ct)
    {
        try
        {
            var categories = await contactService.GetCategoriesAsync(ct);
            var model = new ContactEditViewModel
            {
                Categories = categories.ToList()
            };
            return PartialView("_ContactFormPartial", model);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateContactRequest contactRequest, CancellationToken ct)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            await contactService.AddContactAsync(contactRequest, ct);
            return Ok(new { message = "Contact created" });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    
    [Authorize]
    [HttpGet("edit-view/{id:guid}")]
    public async Task<IActionResult> EditView(Guid id, CancellationToken ct)
    {
        try
        {
            var contact = await contactService.GetContactByIdAsync(id, ct);
            if (contact == null) return NotFound();

            var categories = await contactService.GetCategoriesAsync(ct);
            
            var contactEditModel = mapper.Map<ContactEditViewModel>(contact);
            contactEditModel.SelectedCategoryId = contact.Category.Id;
            contactEditModel.Categories = categories.ToList();

            return PartialView("_ContactFormPartial", contactEditModel);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [Authorize]
    [HttpPost("edit/{id:guid}")]
    public async Task<IActionResult> Edit(Guid id, CreateContactRequest contactRequest, CancellationToken ct)
    {
        try
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            
            await contactService.UpdateContactAsync(contactRequest, ct);
            Ok(new { message = "Contact updated" });
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    
    [Authorize]
    [HttpPost("delete/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        try
        {
            await contactService.DeleteContactAsync(id, ct);
            return Ok(new { message = "Contact deleted" });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}