using SkePieShop.Models;

namespace SkePieShop.ViewModels;

public class PiesListViewModel
{
    public IEnumerable<Pie> Pies { get; set; } = default!;

    public string CurrentCategory { get; set; } = default!;
}