using AutoMapper;
using ContactsApi.Dtos;
using ContactsApi.Entities;

namespace ContactsApi.Configuration;

public class MapperProfiles: Profile
{
    public MapperProfiles()
    {
        CreateMap<Contact, ContactResultDto>();
        
        CreateMap<Contact, ContactDetailsDto>()
            .ReverseMap();

        CreateMap<CategoryDictionary, CategoryDictionaryDto>();
        CreateMap<SubCategoryDictionary, SubCategoryDictionaryDto>();
    }
}