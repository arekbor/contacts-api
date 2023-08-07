namespace ContactsApi.Interfaces;

public interface IDictionaryEntity<TEnum>
    where TEnum:Enum
{
    public string Name { get; set; }
    public TEnum EnumId { get; set; }
}