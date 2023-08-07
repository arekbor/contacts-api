using ContactsApi.Enums;
using ContactsApi.Interfaces;

namespace ContactsApi.Dtos;

public class SubCategoryDictionaryDto:IDictionaryEntity<SubCategory>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public SubCategory EnumId { get; set; }
}