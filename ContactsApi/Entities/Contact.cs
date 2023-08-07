namespace ContactsApi.Entities;

public class Contact:BaseEntity
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }

    public int? CategoryDictionaryId { get; set; }
    public virtual CategoryDictionary? CategoryDictionary { get; set; }

    public int? SubCategoryDictionaryId { get; set; }
    public virtual SubCategoryDictionary? SubCategoryDictionary { get; set; }

    public string? CustomSubCategory { get; set; }
}