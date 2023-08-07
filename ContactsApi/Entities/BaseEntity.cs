namespace ContactsApi.Entities;

/// <summary>
/// Abstract class for entity classes.
/// </summary>
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}