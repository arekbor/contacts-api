namespace ContactsApi.Configuration;

public static class DataSeederBuilder
{
    public static IApplicationBuilder UseDataSeeder(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
        dataSeeder.Seed();
        return app;
    }
}