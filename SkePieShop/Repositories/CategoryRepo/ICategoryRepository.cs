using SkePieShop.Models;

namespace SkePieShop.Repositories.CategoryRepo;

public interface ICategoryRepository
{
    IEnumerable<Category> AllCategories { get; }
}