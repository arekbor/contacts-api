using ContactsApi.Dtos;

namespace ContactsApi.Interfaces;

public interface IUserService
{
    public Task<BaseResponse<LogginUserResultDto>> Login(LoginUserDto userDto);
}