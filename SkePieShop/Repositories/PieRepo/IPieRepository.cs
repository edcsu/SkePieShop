using SkePieShop.Models;

namespace SkePieShop.Repositories.PieRepo;

public interface IPieRepository
{
    IEnumerable<Pie> GetAllPies { get; }
    
    IEnumerable<Pie> PiesOfTheWeek { get; }

    Pie? GetPieById(Guid pieId);
}