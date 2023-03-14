namespace SkePieShop.Models;

public class Pie : BaseModel
{
    public string Name { get; set; } = default!;

    public string? ShortDescription { get; set; }
    
    public string? LongDescription { get; set; }
    
    public string? AllergyInformation { get; set; }
    
    public decimal Price { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public bool IsPieOfTheWeek { get; set; }
    
    public bool InStock { get; set; }
    
    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = default!;
}