using ContactsApi.Enums;
using ContactsApi.Interfaces;

namespace ContactsApi.Dtos;

/// <summary>
/// Dto class representing a category dictionary.
/// </summary>
public class CategoryDictionaryDto:IDictionaryEntity<Category>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Category EnumId { get; set; }
}