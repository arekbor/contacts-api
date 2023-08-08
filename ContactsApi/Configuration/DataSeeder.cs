using ContactsApi.Entities;
using ContactsApi.Enums;

namespace ContactsApi.Configuration;

public class DataSeeder
{
    private readonly DatabaseContext _context;
    private readonly IConfiguration _configuration;

    public DataSeeder(
        DatabaseContext context, 
        IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    
    public void Seed()
    {
        if (!_context.Users.Any())
        {
            var defaultUserPassword = _configuration["DefaultUserPassword"];
            if (defaultUserPassword == null)
            {
                throw new Exception("Default user password not found from configuration.");
            }
            
            var defaultUserLogin = _configuration["DefaultUserLogin"];
            if (defaultUserLogin == null)
            {
                throw new Exception("Default user login not found from configuration.");
            }
            
            var users = new List<User>
            {
                new()
                {
                    Username = defaultUserLogin,
                    Password = BCrypt.Net.BCrypt.HashPassword(defaultUserPassword)
                }
            };
            
            _context.Users.AddRange(users);
            _context.SaveChanges();
        }

        if (!_context.CategoryDictionaries.Any())
        {
            var categories = new List<CategoryDictionary>
            {
                new()
                {
                    Name = "Służbowy",
                    EnumId = Category.Business
                },
                new()
                {
                    Name = "Prywatny",
                    EnumId = Category.Private
                },
                new()
                {
                    Name = "Inny",
                    EnumId = Category.Other
                }
            };
            
            _context.CategoryDictionaries.AddRange(categories);
            _context.SaveChanges();
        }

        if (!_context.SubCategoryDictionaries.Any())
        {
            var subCategories = new List<SubCategoryDictionary>
            {
                new()
                {
                    Name = "Szef",
                    EnumId = SubCategory.Chief
                },
                new()
                {
                    Name = "Manager",
                    EnumId = SubCategory.Manager
                },
                new()
                {
                    Name = "Klient",
                    EnumId = SubCategory.Client
                },
                new()
                {
                    Name = "Pracownik",
                    EnumId = SubCategory.Worker
                }
            };
            
            _context.SubCategoryDictionaries.AddRange(subCategories);
            _context.SaveChanges();
        }
        
        if (!_context.Contacts.Any())
        {
            var defaultContactPassword = _configuration["DefaultContactPassword"];
            if (defaultContactPassword == null)
            {
                throw new Exception("Default contact password not found from configuration.");
            }

            var contacts = new List<Contact>
            {
                new()
                {
                    Firstname = "Marek",
                    Lastname = "Kowalski",
                    Email = "marek.kowalski@gmail.com",
                    PhoneNumber = "543655100",
                    DateOfBirth = DateTime.Parse("1995-05-05"),
                    Password = BCrypt.Net.BCrypt.HashPassword(defaultContactPassword),
                    CategoryDictionaryId = 1,
                    SubCategoryDictionaryId = 2,
                    CustomSubCategory = null,
                },
                new()
                {
                    Firstname = "Jolanta",
                    Lastname = "Truszkowska",
                    Email = "jolanta.truszkowska@gmail.com",
                    PhoneNumber = "522560322",
                    DateOfBirth = DateTime.Parse("1999-02-03"),
                    Password = BCrypt.Net.BCrypt.HashPassword(defaultContactPassword),
                    CategoryDictionaryId = 1,
                    SubCategoryDictionaryId = 4,
                    CustomSubCategory = null,
                },
                new()
                {
                    Firstname = "Adam",
                    Lastname = "Jaworski",
                    Email = "adam.jaworski@gmail.com",
                    PhoneNumber = "544500644",
                    DateOfBirth = DateTime.Parse("2002-08-17"),
                    Password = BCrypt.Net.BCrypt.HashPassword(defaultContactPassword),
                    CategoryDictionaryId = 2,
                    SubCategoryDictionaryId = null,
                    CustomSubCategory = null
                },
                new()
                {
                    Firstname = "Konrad",
                    Lastname = "Wybicki",
                    Email = "konrad.wybicki@gmail.com",
                    PhoneNumber = "600455634",
                    DateOfBirth = DateTime.Parse("1975-05-25"),
                    Password = BCrypt.Net.BCrypt.HashPassword(defaultContactPassword),
                    CategoryDictionaryId = 3,
                    SubCategoryDictionaryId = null,
                    CustomSubCategory = "Polityk"
                },
                new()
                {
                    Firstname = "Marzena",
                    Lastname = "Szczypacka",
                    Email = "marzena.szczypacka@gmail.com",
                    PhoneNumber = "554885665",
                    DateOfBirth = DateTime.Parse("2000-05-08"),
                    Password = BCrypt.Net.BCrypt.HashPassword(defaultContactPassword),
                    CategoryDictionaryId = 3,
                    SubCategoryDictionaryId = null,
                    CustomSubCategory = "Ksiądz"
                },
                new()
                {
                    Firstname = "Aleksandra",
                    Lastname = "Czajnik",
                    Email = "ola.czajnik@gmail.com",
                    PhoneNumber = "566465768",
                    DateOfBirth = DateTime.Parse("1982-09-14"),
                    Password = BCrypt.Net.BCrypt.HashPassword(defaultContactPassword),
                    CategoryDictionaryId = 2,
                    SubCategoryDictionaryId = null,
                    CustomSubCategory = null,
                },
                new()
                {
                    Firstname = "Marian",
                    Lastname = "Januszewski",
                    Email = "marian.januszewski@gmail.com",
                    PhoneNumber = "700566544",
                    DateOfBirth = DateTime.Parse("1965-01-25"),
                    Password = BCrypt.Net.BCrypt.HashPassword(defaultContactPassword),
                    CategoryDictionaryId = 1,
                    SubCategoryDictionaryId = 1,
                    CustomSubCategory = null,
                },
                new()
                {
                    Firstname = "Felicjan",
                    Lastname = "Kaczorowski",
                    Email = "fel.kaczorowski@gmail.com",
                    PhoneNumber = "700566544",
                    DateOfBirth = DateTime.Parse("1991-12-05"),
                    Password = BCrypt.Net.BCrypt.HashPassword(defaultContactPassword),
                    CategoryDictionaryId = 1,
                    SubCategoryDictionaryId = 3,
                    CustomSubCategory = null,
                },
                new()
                {
                    Firstname = "Hanna",
                    Lastname = "Kowalska",
                    Email = "kowalska@gmail.com",
                    PhoneNumber = "455655443",
                    DateOfBirth = DateTime.Parse("1995-11-08"),
                    Password = BCrypt.Net.BCrypt.HashPassword(defaultContactPassword),
                    CategoryDictionaryId = 1,
                    SubCategoryDictionaryId = 4,
                    CustomSubCategory = null,
                },
                new()
                {
                    Firstname = "Damian",
                    Lastname = "Jasnogórski",
                    Email = "jasnogorski@gmail.com",
                    PhoneNumber = "700564556",
                    DateOfBirth = DateTime.Parse("1996-05-12"),
                    Password = BCrypt.Net.BCrypt.HashPassword(defaultContactPassword),
                    CategoryDictionaryId = 2,
                    SubCategoryDictionaryId = null,
                    CustomSubCategory = null,
                },
            };
            
            _context.Contacts.AddRange(contacts);
            _context.SaveChanges();
        }
    }
}