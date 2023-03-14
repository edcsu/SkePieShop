namespace SkePieShop.Models;

public class Category : BaseModel
{
    public string Name { get; set; } = default!;
    
    public string? Description { get; set; }

    public List<Pie> Pies { get; set; } = default!;
}