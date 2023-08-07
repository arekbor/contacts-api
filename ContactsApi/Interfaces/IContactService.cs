using ContactsApi.Dtos;

namespace ContactsApi.Interfaces;

public interface IContactService
{ 
    Task<BaseResponse<PageResult<ContactResultDto>>> GetContacts(int page, int pageSize);
    Task<BaseResponse<ContactDetailsDto>> GetContactDetails(int contactId);
    Task<BaseResponse> CreateContact(ContactDetailsDto dto);
    Task<BaseResponse> UpdateContact(ContactDetailsDto dto);
    Task<BaseResponse> DeleteContact(int contactId);
}