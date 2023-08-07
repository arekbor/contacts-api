This is a contacts API. To run the API you need .NET Core version 6.0 and PostgreSQL 15.3.

![image](https://github.com/arekbor/contacts-api/assets/86869559/410d8050-a59d-4d2b-95ba-857835b550b1)

>How to run:
1. Clone project from repo.
2. Open `ContactsApi.sln` in favourite IDE.
3. Go to the ContactApi folder and remove the dot at the beginning of the `.appsettings.json` file.
4. Complete the environment variables in the `appsettings.json` file.

**All the variables listed below are required**

| Environment | Meaning |
| ------- | --- |
| DefaultContactPassword | This variable represents the default password for a created contact in the seeder. |
| DefaultUserLogin | This variable indicates the default login for a created user in the seeder. |
| DefaultUserPassword | This variable indicates the default password for a created user in the seeder. |
| ConnectionString | This variable specifies the connection string to the PostgreSQL database. |
| AccessTokenIssuer | The variable specifies the issuer for the JWT token generator. |
| AccessTokenAudience | This variable specifies the audience for the JWT token generator. |
| AccessTokenPrivateKey | This variable holds the private key for the JWT token generator. |
| AccessTokenExpInMinutes | This variable sets the expiration time of the JWT token in minutes. |
| AngularUrl | This variable specifies the URL to angular App. |

Example PostgresSQL connection string:
```
Host=localhost; Port=5432; Database=postgres; Username=postgres; Password=password; timeout=1000
```
4. Build and run api.

>Used packages:
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Swashbuckle.AspNetCore
- AutoMapper
- AutoMapper.Extensions.Microsoft.DependencyInjection
- BCrypt.Net-Next
- FluentValidation
- Npgsql.EntityFrameworkCore.PostgreSQL

