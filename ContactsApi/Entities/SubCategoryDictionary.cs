using ContactsApi.Enums;
using ContactsApi.Interfaces;

namespace ContactsApi.Entities;

public class SubCategoryDictionary:BaseEntity, IDictionaryEntity<SubCategory>
{
    public string Name { get; set; }
    public SubCategory EnumId { get; set; }
}