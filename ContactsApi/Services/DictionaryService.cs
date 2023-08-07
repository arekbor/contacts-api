using AutoMapper;
using ContactsApi.Dtos;
using ContactsApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Services;

public class DictionaryService:IDictionaryService
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public DictionaryService(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves the category dictionaries. 
    /// </summary>
    /// <returns>The list of category dictionaries.</returns>
    public async Task<BaseResponse<List<CategoryDictionaryDto>>> GetCategoryDictionaries()
    {
        var categories = await _context
            .CategoryDictionaries
            .ToListAsync();

        var dto = _mapper.Map<List<CategoryDictionaryDto>>(categories);
        return new BaseResponse<List<CategoryDictionaryDto>>(dto);
    }

    
    /// <summary>
    /// Retrieves the sub-category dictionaries. 
    /// </summary>
    /// <returns>The list of sub category dictionaries.</returns>
    public async Task<BaseResponse<List<SubCategoryDictionaryDto>>> GetSubCategoryDictionaries()
    {
        var subCategories = await _context
            .SubCategoryDictionaries
            .ToListAsync();

        var dto = _mapper.Map<List<SubCategoryDictionaryDto>>(subCategories);
        return new BaseResponse<List<SubCategoryDictionaryDto>>(dto);
    }

    /// <summary>
    /// Retrieves a category dictionary enum by category id.
    /// </summary>
    /// <param name="categoryId">The category id.</param>
    /// <returns>A enum Id of the specified category dictionary.</returns>
    public async Task<BaseResponse<CategoryDictionaryEnumDto>> GetCategoryDictionaryEnumById(int categoryId)
    {
        var category = await _context.CategoryDictionaries
            .FirstOrDefaultAsync(x => x.Id == categoryId);
        if (category == null)
        {
            return new BaseResponse<CategoryDictionaryEnumDto>($"Kategoria o ID: {categoryId} nie istnieje.");
        }

        var result = new CategoryDictionaryEnumDto
        {
            EnumId = (int)category.EnumId,
        };

        return new BaseResponse<CategoryDictionaryEnumDto>(result);
    }
}