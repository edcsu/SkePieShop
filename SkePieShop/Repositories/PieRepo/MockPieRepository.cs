using SkePieShop.Models;
using SkePieShop.Repositories.CategoryRepo;

namespace SkePieShop.Repositories.PieRepo;

public class MockPieRepository : IPieRepository
{
    public readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

    public IEnumerable<Pie> GetAllPies =>
        new List<Pie>
        {
            new Pie
            {
              Id  = Guid.NewGuid(),
              Name = "Strawberry Pie",
              Price = 15.95M,
              ShortDescription = "Lorem ipsum",
              LongDescription = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit.",
              InStock = true,
            },new Pie
            {
              Id  = Guid.NewGuid(),
              Name = "Cheese Cake",
              Price = 18.95M,
              ShortDescription = "Lorem ipsum",
              LongDescription = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit.",
              InStock = true,
            },new Pie
            {
              Id  = Guid.NewGuid(),
              Name = "Rhubarb Pie",
              Price = 15.95M,
              ShortDescription = "Lorem ipsum",
              LongDescription = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit.",
              InStock = true,
            },new Pie
            {
              Id  = Guid.NewGuid(),
              Name = "Pumpkin Pie",
              Price = 12.95M,
              ShortDescription = "Lorem ipsum",
              LongDescription = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit.",
              InStock = true,
            },
        };
    public IEnumerable<Pie> PiesOfTheWeek { get; }
    public Pie? GetPieById(Guid pieId)
    {
        return GetAllPies.FirstOrDefault(p => p.Id == pieId);
    }
}