using ContactsApi.Enums;
using ContactsApi.Interfaces;

namespace ContactsApi.Entities;

public class CategoryDictionary:BaseEntity, IDictionaryEntity<Category>
{
    public string Name { get; set; }
    public Category EnumId { get; set; }
}