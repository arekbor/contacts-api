namespace ContactsApi.Interfaces;

/// <summary>
/// Interface for dictionary entities.
/// </summary>
/// <typeparam name="TEnum">The enum used as the dictionary identifier.</typeparam>
public interface IDictionaryEntity<TEnum>
    where TEnum:Enum
{
    public string Name { get; set; }
    public TEnum EnumId { get; set; }
}