using AutoMapper;
using ContactsApi.Dtos;
using ContactsApi.Entities;
using ContactsApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Services;

public class ContactService:IContactService
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public ContactService(DatabaseContext context, IMapper mapper)
    
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves a paginated list of contacts.
    /// </summary>
    /// <param name="page">The page number.</param>
    /// <param name="pageSize">The number of result per page.</param>
    /// <returns>A paginated list of contacts.</returns>
    public async Task<BaseResponse<PageResult<ContactResultDto>>> GetContacts(int page, int pageSize)
    {
        var countContacts = await _context.Contacts.CountAsync();
        var paginationResult = new PageResult<ContactResultDto>(page, pageSize, countContacts);
        
        var contacts = await _context
            .Contacts.Skip((paginationResult.PageIndex - 1) * pageSize)
            .Take(paginationResult.PageSize)
            .ToListAsync();

        paginationResult.Items = _mapper.Map<List<ContactResultDto>>(contacts);
        
        return new BaseResponse<PageResult<ContactResultDto>>(paginationResult);
    }

    
    /// <summary>
    /// Retrieves a contact details.
    /// </summary>
    /// <param name="contactId">The id of the contact.</param>
    /// <returns>The contact details.</returns>
    ///
    public async Task<BaseResponse<ContactDetailsDto>> GetContactDetails(int contactId)
    {
        var contact = await _context
            .Contacts
            .FirstOrDefaultAsync(x => x.Id == contactId);
        if (contact == null)
        {
            return new BaseResponse<ContactDetailsDto>($"Nie odnaleźiono kontaktu pod ID: {contactId}");
        }
        
        var result = _mapper.Map<ContactDetailsDto>(contact);
        return new BaseResponse<ContactDetailsDto>(result);
    }

    /// <summary>
    /// Creates a contact.
    /// </summary>
    /// <param name="dto">Dto object containing information for creating the contact.</param>
    /// <returns></returns>
    public async Task<BaseResponse> CreateContact(ContactDetailsDto dto)
    {
        var contact = _mapper.Map<Contact>(dto);
        
        var emailExists = await _context.Contacts.AnyAsync(c => c.Email == dto.Email);
        if (emailExists)
        {
            return new BaseResponse("Użytkownik z podanym e-mailem już ustnieje.");
        }
        
        contact.Password = BCrypt.Net.BCrypt.HashPassword(dto.ContactPassword);

        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();

        return new BaseResponse();
    }

    /// <summary>
    /// Updates a contact.
    /// </summary>
    /// <param name="dto">Dto object containing information for updating the contact.</param>
    /// <returns></returns>
    public async Task<BaseResponse> UpdateContact(ContactDetailsDto dto)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (contact == null)
        {
            return new BaseResponse("Edytowany użytkownik nie został odnaleźiony w bazie danych");
        }
        
        var emailExists = await _context.Contacts.AnyAsync(c => c.Email == dto.Email && c.Id != dto.Id);
        if (emailExists)
        {
            return new BaseResponse("Użytkownik z podanym e-mailem już ustnieje.");
        }

        contact.Firstname = dto.Firstname;
        contact.Lastname = dto.Lastname;
        contact.Password = BCrypt.Net.BCrypt.HashPassword(dto.ContactPassword);
        contact.Email = dto.Email;
        contact.PhoneNumber = dto.PhoneNumber;
        contact.DateOfBirth = dto.DateOfBirth;
        contact.CategoryDictionaryId = dto.CategoryDictionaryId;
        contact.SubCategoryDictionaryId = dto.SubCategoryDictionaryId;
        contact.CustomSubCategory = dto.CustomSubCategory;

        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();

        return new BaseResponse();
    }

    /// <summary>
    /// Deletes a contact.
    /// </summary>
    /// <param name="contactId">The id of the contact.</param>
    /// <returns></returns>
    public async Task<BaseResponse> DeleteContact(int contactId)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == contactId);
        if (contact == null)
        {
            return new BaseResponse("Kontakt o podanym ID nie istnieje");
        }

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();

        return new BaseResponse();
    }
}