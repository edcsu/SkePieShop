using SkePieShop.Models;

namespace SkePieShop.Repositories.CategoryRepo;

public class MockCategoryRepository : ICategoryRepository
{
    public IEnumerable<Category> AllCategories => new List<Category>
    {
        new Category
        {
            Id = Guid.NewGuid(),
            Name = "Fruit pies",
            Description = "All fruity pies"
        },
        new Category
        {
            Id = Guid.NewGuid(),
            Name = "Cheese Cake",
            Description = "Cheesy all the way"
        },
        new Category
        {
            Id = Guid.NewGuid(),
            Name = "Shepard's pie",
            Description = "Shepard pie"
        },
    };
}