using Bogus;
using SkePieShop.Models;

namespace SkePieShop.Data;

public static class GenerateData
{
    public static IEnumerable<Pie> GetPiesList()
    {
        return new Faker<Pie>()
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.ShortDescription, f => f.Random.Words(3))
            .RuleFor(p => p.LongDescription, f => f.Random.Words(25))
            .RuleFor(p => p.Price, f => f.Random.Decimal())
            .RuleFor(p => p.ImageUrl, f => f.Image.PicsumUrl())
            .RuleFor(p => p.CreatedAt, f => f.Date.Past().ToUniversalTime())
            .Generate(10);
    }
    
    public static IEnumerable<Category> GetCategories()
    {
        return new Faker<Category>()
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Random.Words(3))
            .RuleFor(p => p.CreatedAt, f => f.Date.Past().ToUniversalTime())
            .Generate(6);
    }
}