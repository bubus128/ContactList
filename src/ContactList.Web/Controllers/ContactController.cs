using AutoMapper;
using ContactList.Business.Contracts;
using ContactList.Business.Services.Interfaces;
using ContactList.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController(IContactService contactService): Controller
{
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
    [HttpPost("edit/{id:guid}")]
    public async Task<IActionResult> Edit(Guid id, CreateContactRequest contactRequest, CancellationToken ct)
    {
        try
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            contactRequest.Id = id;
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