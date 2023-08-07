using ContactsApi.Entities;
using ContactsApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi;

public class DatabaseContext:DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        :base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<CategoryDictionary> CategoryDictionaries { get; set; }
    public DbSet<SubCategoryDictionary> SubCategoryDictionaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
            .HasIndex(c => c.Email)
            .IsUnique();

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (entityType.ClrType.GetInterfaces().Any(x =>
                    x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IDictionaryEntity<>)))
            {
                var enumIdPropertyName = nameof(IDictionaryEntity<Enum>.EnumId);
                
                var property = entityType.FindProperty(enumIdPropertyName);
                if (property == null)
                {
                    throw new Exception($"{enumIdPropertyName} property not found");
                }

                modelBuilder.Entity(entityType.ClrType)
                    .HasIndex(enumIdPropertyName)
                    .IsUnique();
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}