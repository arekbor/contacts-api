namespace ContactsApi.Dtos;

/// <summary>
/// Dto class representing a basic information about a contact.
/// </summary>
public class ContactResultDto
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
}