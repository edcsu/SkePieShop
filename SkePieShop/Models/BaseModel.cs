using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SkePieShop.Models;

public class BaseModel
{
    [BindNever]
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
    
    public DateTime? UpdatedAt { get; set; }
}