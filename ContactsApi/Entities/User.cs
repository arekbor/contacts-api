namespace ContactsApi.Entities;

/// <summary>
/// Represents an entity class for the user.
/// </summary>
public class User:BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
}