using ContactsApi.Dtos;

namespace ContactsApi.Interfaces;

public interface IDictionaryService
{
    Task<BaseResponse<List<CategoryDictionaryDto>>> GetCategoryDictionaries();
    Task<BaseResponse<List<SubCategoryDictionaryDto>>> GetSubCategoryDictionaries();

    Task<BaseResponse<CategoryDictionaryEnumDto>> GetCategoryDictionaryEnumById(int categoryId);
}