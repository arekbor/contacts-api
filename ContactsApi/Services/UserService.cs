using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ContactsApi.Dtos;
using ContactsApi.Interfaces;
using ContactsApi.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ContactsApi.Services;

public class UserService:IUserService
{
    private readonly IConfiguration _configuration;
    private readonly DatabaseContext _context;

    public UserService(
        DatabaseContext context, 
        IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<BaseResponse<LogginUserResultDto>> Login(LoginUserDto userDto)
    {
        var validator = new LoginUserDtoValidator();
        var validationResult = await validator.ValidateAsync(userDto);

        if (validationResult.Errors.Any())
        {
            return new BaseResponse<LogginUserResultDto>(validationResult);
        }

        var user = await _context
            .Users
            .FirstOrDefaultAsync(x => x.Username == userDto.Username);

        if (user == null)
        {
            return new BaseResponse<LogginUserResultDto>("Nieprawidłowa nazwa użytkownika lub hasło");
        }

        var verifyPasswords = BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password);
        if (!verifyPasswords)
        {
            return new BaseResponse<LogginUserResultDto>("Nieprawidłowa nazwa użytkownika lub hasło");
        }
        
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        var privateKey = _configuration["AccessTokenPrivateKey"];
        if (privateKey == null)
        {
            throw new Exception("Private key not found from configuration.");
        }
        
        var audience = _configuration["AccessTokenAudience"];
        if (audience == null)
        {
            throw new Exception("Audience not found from configuration.");
        }
        
        var issuer = _configuration["AccessTokenIssuer"];
        if (issuer == null)
        {
            throw new Exception("Issuer not found from configuration.");
        }
        
        var exp = _configuration["AccessTokenExpInMinutes"];
        if (exp == null)
        {
            throw new Exception("Issuer not found from configuration.");
        }

        if (!double.TryParse(exp, out double expMinutes))
        {
            throw new Exception("Failed to parse the 'exp' environment variable as a double.");
        }

        byte[] keyBytes = Encoding.UTF8.GetBytes(privateKey);
        
        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Name, user.Username),
            }),
            Expires = DateTime.UtcNow.AddMinutes(expMinutes),
            Audience = audience,
            Issuer = issuer,
            SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        var tokenString = jwtSecurityTokenHandler.WriteToken(token);
        
        var result = new LogginUserResultDto
        {
            AccessToken = tokenString,
        };

        return new BaseResponse<LogginUserResultDto>(result);
    }
}