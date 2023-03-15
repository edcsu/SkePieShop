using Microsoft.EntityFrameworkCore;
using SkePieShop.Data;
using SkePieShop.Models;

namespace SkePieShop.Repositories.PieRepo;

public class PieRepository : IPieRepository
{
    private readonly AppDbContext _dbContext;

    public PieRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Pie> GetAllPies
    {
        get
        {
            return _dbContext.Pies.Include(c => c.Category);
        }
    }

    public IEnumerable<Pie> PiesOfTheWeek
    {
        get
        {
            return _dbContext.Pies.Include(c => c.Category)
                .Where(p => p.IsPieOfTheWeek);
        }
    }
    
    public Pie? GetPieById(Guid pieId)
    {
        return _dbContext.Pies.FirstOrDefault(p => p.Id == pieId);
    }
}