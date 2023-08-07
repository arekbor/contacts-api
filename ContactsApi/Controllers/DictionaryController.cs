using ContactsApi.Helpers;
using ContactsApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers;

[Authorize]
[ApiController]
public class DictionaryController:ControllerBase
{
    private readonly IDictionaryService _dictionaryService;

    public DictionaryController(IDictionaryService dictionaryService)
    {
        _dictionaryService = dictionaryService;
    }
    
    [HttpGet]
    [Route(PathHelper.GetCategoryDictionaries)]
    public async Task<IActionResult> GetCategoryDictionaries()
    {
        var result = await _dictionaryService.GetCategoryDictionaries();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    
    [HttpGet]
    [Route(PathHelper.GetSubCategoryDictionaries)]
    public async Task<IActionResult> GetSubCategoryDictionaries()
    {
        var result = await _dictionaryService.GetSubCategoryDictionaries();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
    
    [HttpGet]
    [Route(PathHelper.GetCategoryDictionaryEnumById)]
    public async Task<IActionResult> GetCategoryDictionaryEnumById(int categoryId)
    {
        var result = await _dictionaryService
            .GetCategoryDictionaryEnumById(categoryId);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}