using ContactsApi.Enums;
using ContactsApi.Interfaces;

namespace ContactsApi.Entities;

/// <summary>
/// Represents an entity class for the subcategory dictionary.
/// </summary>
public class SubCategoryDictionary:BaseEntity, IDictionaryEntity<SubCategory>
{
    public string Name { get; set; }
    public SubCategory EnumId { get; set; }
}