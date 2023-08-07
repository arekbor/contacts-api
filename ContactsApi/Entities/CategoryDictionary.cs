using ContactsApi.Enums;
using ContactsApi.Interfaces;

namespace ContactsApi.Entities;

/// <summary>
/// Represents an entity class for the category dictionary.
/// </summary>
public class CategoryDictionary:BaseEntity, IDictionaryEntity<Category>
{
    public string Name { get; set; }
    public Category EnumId { get; set; }
}