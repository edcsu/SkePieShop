using SkePieShop.Data;
using SkePieShop.Models;

namespace SkePieShop.Repositories.CategoryRepo;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;

    public CategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Category> AllCategories => _dbContext.Categories;
}