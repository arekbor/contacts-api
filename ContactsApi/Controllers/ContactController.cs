using ContactsApi.Dtos;
using ContactsApi.Helpers;
using ContactsApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers;

[Authorize]
[ApiController]
public class ContactController:ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }
    
    [HttpGet]
    [AllowAnonymous]
    [Route(PathHelper.GetContactsPath)]
    public async Task<IActionResult> GetContacts(int page, int pageSize)
    {
        var result =  await _contactService.GetContacts(page, pageSize);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    
    [HttpGet]
    [Route(PathHelper.GetContactDetails)]
    public async Task<IActionResult> GetContactDetails(int contactId)
    {
        var result = await _contactService.GetContactDetails(contactId);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost]
    [Route(PathHelper.CreateContact)]
    public async Task<IActionResult> CreateContact(ContactDetailsDto dto)
    {
        var result = await _contactService.CreateContact(dto);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

   
    [HttpPut]
    [Route(PathHelper.UpdateContact)]
    public async Task<IActionResult> UpdateContact(ContactDetailsDto dto)
    {
        var result = await _contactService.UpdateContact(dto);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    
    [HttpDelete]
    [Route(PathHelper.DeleteContact)]
    public async Task<IActionResult> DeleteContact(int contactId)
    {
        var result = await _contactService.DeleteContact(contactId);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

}