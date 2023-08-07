namespace ContactsApi.Dtos;

/// <summary>
/// Dto class representing a contact.
/// </summary>
public class ContactDetailsDto
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ContactPassword { get; set; }

    public int? CategoryDictionaryId { get; set; }
    public int? SubCategoryDictionaryId { get; set; }
    public string? CustomSubCategory { get; set; }
}