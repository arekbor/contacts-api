using ContactsApi.Dtos;
using ContactsApi.Helpers;
using ContactsApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers;

[Authorize]
[ApiController]
public class UserController:ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route(PathHelper.LoginPath)]
    public async Task<IActionResult> Login(LoginUserDto userDto)
    {
       var result = await _userService.Login(userDto);
       if (!result.Success)
       {
           return BadRequest(result);
       }
       return Ok(result);
    }
}