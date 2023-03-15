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
        if (!context.Categories.Any())
        {
            var categories = GenerateData.GetCategories();
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        if (context.Pies.Any()) return;
        {
            if (!context.Categories.Any()) return;
            var categories = context.Categories.ToList();
            var pies = GenerateData.GetPiesList().ToList();
            foreach (var pie in pies)
            {
                pie.Category = categories[0];
            }
            context.Pies.AddRange(pies);
            context.SaveChanges();
        }
    }
}