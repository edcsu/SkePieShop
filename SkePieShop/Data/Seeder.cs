namespace SkePieShop.Data;

public class Seeder
{
    public static void TrySeeding(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>()!);
    }

    private static void SeedData(AppDbContext context)
    {
        if (!context.Pies.Any())
        {
            var pies = GenerateData.GetPiesList();
            context.Pies.AddRange(pies);
            context.SaveChanges();
        }
        
        if (!context.Categories.Any())
        {
            var categories = GenerateData.GetCategories();
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
    }
}