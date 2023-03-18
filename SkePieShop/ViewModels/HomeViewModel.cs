using SkePieShop.Models;

namespace SkePieShop.ViewModels;

public class HomeViewModel
{
    public IEnumerable<Pie> PiesOfTheWeek { get; set; } = default!;
}