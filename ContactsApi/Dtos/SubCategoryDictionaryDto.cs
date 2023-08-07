using ContactsApi.Enums;
using ContactsApi.Interfaces;

namespace ContactsApi.Dtos;

/// <summary>
/// Dto class representing a sub category dictionary.
/// </summary>
public class SubCategoryDictionaryDto:IDictionaryEntity<SubCategory>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public SubCategory EnumId { get; set; }
}