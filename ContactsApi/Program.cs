using System.Text;
using ContactsApi;
using ContactsApi.Configuration;
using ContactsApi.Interfaces;
using ContactsApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularClientPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["AccessTokenIssuer"],
        ValidAudience = builder.Configuration["AccessTokenAudience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["AccessTokenPrivateKey"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var connectionString = builder.Configuration["ConnectionString"];
    if (connectionString == null)
    {
        throw new Exception("Connection string to database not found");
    }

    options.UseNpgsql(connectionString, o => 
        o.SetPostgresVersion(9, 6));
});
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    }); 
});

builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IDictionaryService, DictionaryService>();

var app = builder.Build();

app.UseCors("AngularClientPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseDataSeeder();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();