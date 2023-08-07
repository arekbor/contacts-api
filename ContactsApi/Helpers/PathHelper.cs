namespace ContactsApi.Helpers;

/// <summary>
/// Helper class that defines the endpoints for API.
/// </summary>
public static class PathHelper
{
    private const string BasePath = "/api";

    public const string LoginPath = $"{BasePath}/login";

    public const string GetContactsPath = $"{BasePath}/getContacts";
    public const string GetContactDetails = $"{BasePath}/getContactDetails";
    public const string CreateContact = $"{BasePath}/createContact";
    public const string UpdateContact = $"{BasePath}/updateContact";
    public const string DeleteContact = $"{BasePath}/deleteContact";

    public const string GetCategoryDictionaries = $"{BasePath}/getCategoryDictionaries";
    public const string GetSubCategoryDictionaries = $"{BasePath}/getSubCategoryDictionaries";

    public const string GetCategoryDictionaryEnumById = $"{BasePath}/getCategoryDictionaryEnumById";
}